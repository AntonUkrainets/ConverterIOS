using Converter;
using Converter.Interacts.Implements;
using NUnit.Framework;
using Moq;
using Converter.IsoCodeHelpers.Interfaces;
using System.Reflection;
using System.Threading.Tasks;

namespace ConverterTest
{
    public class RateInteractorTests
    {
        private IInteractor _rateInteractor;
        private Mock<IIsoCodeHelper> _isoCodeHelperMoq;
        private Mock<IRequester> _requesterMoq;

        [SetUp]
        public void SetUp()
        {
            _isoCodeHelperMoq = new Mock<IIsoCodeHelper>(MockBehavior.Strict);
            _requesterMoq = new Mock<IRequester>(MockBehavior.Strict);
            _rateInteractor = new RateInteractor(_isoCodeHelperMoq.Object, _requesterMoq.Object);
        }

        [TestCase("_requester")]
        public void CtorRequesterTest(string mockObject)
        {
            var actualValue = typeof(RateInteractor)
                    .GetField(mockObject, BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(_rateInteractor);

            Assert.AreEqual(_requesterMoq.Object, actualValue);
        }

        [TestCase("_isoCodeHelper")]
        public void CtorIsoCodeHelperTest(string mockObject)
        {
            var actualValue = typeof(RateInteractor)
                    .GetField(mockObject, BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(_rateInteractor);

            Assert.AreEqual(_isoCodeHelperMoq.Object, actualValue);
        }

        [TestCase("100", "200", "100")]
        public async Task RateInteractorGetRateAsyncTest(string curFrom, string curTo, string input)
        {
            var expectedValue = 500M;

            _isoCodeHelperMoq.Setup(i => i.GetIsoCode(curFrom))
                             .Returns(10);
            _isoCodeHelperMoq.Setup(i => i.GetIsoCode(curTo))
                             .Returns(20);

            _requesterMoq.Setup(r => r.GetRate(10, 20))
                         .Returns(Task.FromResult(5M));

            var actualValue = await _rateInteractor.GetRate(curFrom, curTo, input);

            Assert.AreEqual(expectedValue, actualValue);

            _requesterMoq.Verify(r => r.GetRate(10, 20), Times.Once);
            _isoCodeHelperMoq.Verify(i => i.GetIsoCode(curFrom), Times.Once);
            _isoCodeHelperMoq.Verify(i => i.GetIsoCode(curTo), Times.Once);
        }

        [TestCase("USD", "UAH", "100")]
        public async Task GetRateUSDAsyncTest(string curFrom, string curTo, string input)
        {
            var expectedValue = 2442.00M;

            _isoCodeHelperMoq.Setup(i => i.GetIsoCode(curFrom))
                             .Returns(980);

            _isoCodeHelperMoq.Setup(i => i.GetIsoCode(curTo))
                             .Returns(840);

            _requesterMoq.Setup(r => r.GetRate(980, 840))
                         .Returns(Task.FromResult(24.42M));

            var actualValue = await _rateInteractor.GetRate(curFrom, curTo, input);

            Assert.AreEqual(expectedValue, actualValue);

            _requesterMoq.Verify(r => r.GetRate(980, 840), Times.Once);
            _isoCodeHelperMoq.Verify(i => i.GetIsoCode(curFrom), Times.Once);
            _isoCodeHelperMoq.Verify(i => i.GetIsoCode(curTo), Times.Once);
        }
    }
}
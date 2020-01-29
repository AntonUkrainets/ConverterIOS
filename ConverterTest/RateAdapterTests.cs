using Converter.Adapters.Implements;
using Converter.Adapters.Interfaces;
using Converter.Interacts.Implements;
using Moq;
using NUnit.Framework;
using System.Reflection;
using System.Threading.Tasks;

namespace ConverterTest
{
    public class RateAdapterTests
    {
        private Mock<IInteractor> _mockInteractor;
        private IAdapter _rateAdapter;

        [SetUp]
        public void Setup()
        {
            _mockInteractor = new Mock<IInteractor>(MockBehavior.Strict);
            _rateAdapter = new RateAdapter(_mockInteractor.Object);
        }

        [Test]
        public void CtorAdapterTest()
        {
            var actualValue = typeof(RateAdapter)
                .GetField("_interactor", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(_rateAdapter);

            Assert.AreEqual(_mockInteractor.Object, actualValue);
        }

        [TestCase("10", "20", "10", "5.123", 5.12354)]
        [TestCase("1", "2", "10", "50", 50)]
        public async Task GetRoundResultAsyncTest(
            string curFrom,
            string curTo,
            string input,
            string expectedValue,
            decimal result
        )
        {
            _mockInteractor.Setup(i => i.GetRate(curFrom, curTo, input))
                           .Returns(Task.FromResult(result));
            var actualValue = await _rateAdapter.GetRate(curFrom, curTo, input);

            Assert.AreEqual(expectedValue, actualValue);

            _mockInteractor.Verify(i => i.GetRate(curFrom, curTo, input), Times.Once);
        }
    }
}
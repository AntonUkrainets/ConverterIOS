using Converter.Adapters.Implements;
using Converter.Adapters.Interfaces;
using Converter.Interacts.Implements;
using Converter.IsoCodeHelpers.Implements;
using Converter.IsoCodeHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace Converter
{
    public partial class ViewController : UIViewController
    {
        private IAdapter _rateAdapter;
        private IIsoCodeHelper _isoCodeHelper;
        private IInteractor _rateInteractor;
        private IRequester _requester;

        private IList<string> _currencyValues;
        private ConverterPickerViewModel _converterPickerViewModel;

        private Action _selectFirstCurrencyLabel;
        private Action _selectSecondCurrencyLabel;

        public ViewController (IntPtr handle) : base (handle)
        {
            GetConverterDependencies();
            GetCurrencyLabelDependencies();
        }

        private void GetConverterDependencies()
        {
            _isoCodeHelper = new IsoCodeHelper();
            _requester = new RateRequester();

            _rateInteractor = new RateInteractor(_isoCodeHelper, _requester);
            _rateAdapter = new RateAdapter(_rateInteractor);
        }

        private void GetCurrencyLabelDependencies()
        {
            _selectFirstCurrencyLabel = new Action(SelectFirstCurrency);
            _selectSecondCurrencyLabel = new Action(SelectSecondCurrency);
        }

        private void FillCurrencyValues()
        {
            _currencyValues = new List<string>
            {
                "UAH",
                "USD",
                "EUR"
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            FillCurrencyValues();

            SetConverterPickerViewModel();

            SelectFirstCurrency();
            SelectSecondCurrency();

            InvokeFirstCurrencyLabelTap();
            InvokeSecondCurrencyLabelTap();
        }

        #region Init PickerView

        private void InvokeFirstCurrencyLabelTap()
        {
            var uITapGestureRecognizer = new UITapGestureRecognizer();
            uITapGestureRecognizer.AddTarget(FirstLabelSelected);
            FirstCurrencyLabel.AddGestureRecognizer(uITapGestureRecognizer);
        }

        private void InvokeSecondCurrencyLabelTap()
        {
            var uITapGestureRecognizer = new UITapGestureRecognizer();
            uITapGestureRecognizer.AddTarget(SecondLabelSelected);
            SecondCurrencyLabel.AddGestureRecognizer(uITapGestureRecognizer);
        }

        private void FirstLabelSelected()
        {
            BarabanView.Hidden = false;

            _converterPickerViewModel._setCurrencyLabel = _selectFirstCurrencyLabel;
        }

        private void SecondLabelSelected()
        {
            BarabanView.Hidden = false;

            _converterPickerViewModel._setCurrencyLabel = _selectSecondCurrencyLabel;
        }

        private void SetConverterPickerViewModel()
        {
            _converterPickerViewModel = new ConverterPickerViewModel(_currencyValues);
            BarabanView.Model = _converterPickerViewModel;
        }

        private void SelectFirstCurrency()
        {
            FirstCurrencyLabel.Text = _converterPickerViewModel.SelectedItem;
            BarabanView.Hidden = true;
        }

        private void SelectSecondCurrency()
        {
            SecondCurrencyLabel.Text = _converterPickerViewModel.SelectedItem;
            BarabanView.Hidden = true;
        }

        #endregion

        partial void CalculateButton_Tapped(UIButton sender)
        {
            var currencyFirst = FirstCurrencyLabel.Text;
            var currencySecond = SecondCurrencyLabel.Text;

            var firstValue = FirstValueTextField.Text;

            var result = Task.Run(() => CountResult(currencyFirst, currencySecond, firstValue)).Result;

            SecondValueLabel.Text = result;
        }

        private string CountResult(string currencyFirst, string currencySecond, string firstValue)
        {
            var roundedResult = _rateAdapter.GetRate(currencyFirst, currencySecond, firstValue).Result;

            return roundedResult;
        }

        public override void DidReceiveMemoryWarning ()
                => base.DidReceiveMemoryWarning();
    }
}
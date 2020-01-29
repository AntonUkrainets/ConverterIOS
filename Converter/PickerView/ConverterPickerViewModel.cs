using System;
using System.Collections.Generic;
using UIKit;

namespace Converter
{
    public class ConverterPickerViewModel : UIPickerViewModel
    {
        private IList<string> _currencyValues;
        protected int _selectedIndex = 0;

        public Action _setCurrencyLabel { get; set; }

        public ConverterPickerViewModel(IList<string> currencyValues)
        {
            _currencyValues = currencyValues;
        }

        public string SelectedItem
        {
            get 
            { 
                return _currencyValues[_selectedIndex]; 
            }
        }

        public override nint GetComponentCount(UIPickerView pickerView)
                => 1;

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
                => _currencyValues.Count;

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
                => _currencyValues[(int)row];

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            _selectedIndex = (int)row;

            _setCurrencyLabel.Invoke();
        }
    }
}
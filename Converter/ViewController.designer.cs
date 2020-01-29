// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Converter
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView BarabanView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CalculateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FirstCurrencyLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FirstValueTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SecondCurrencyLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SecondValueLabel { get; set; }

        [Action ("CalculateButton_Tapped:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CalculateButton_Tapped (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BarabanView != null) {
                BarabanView.Dispose ();
                BarabanView = null;
            }

            if (CalculateButton != null) {
                CalculateButton.Dispose ();
                CalculateButton = null;
            }

            if (FirstCurrencyLabel != null) {
                FirstCurrencyLabel.Dispose ();
                FirstCurrencyLabel = null;
            }

            if (FirstValueTextField != null) {
                FirstValueTextField.Dispose ();
                FirstValueTextField = null;
            }

            if (MainView != null) {
                MainView.Dispose ();
                MainView = null;
            }

            if (SecondCurrencyLabel != null) {
                SecondCurrencyLabel.Dispose ();
                SecondCurrencyLabel = null;
            }

            if (SecondValueLabel != null) {
                SecondValueLabel.Dispose ();
                SecondValueLabel = null;
            }
        }
    }
}
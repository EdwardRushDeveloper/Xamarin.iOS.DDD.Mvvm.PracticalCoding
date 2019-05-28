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

namespace MySpectrum
{
    [Register ("AddUserViewController")]
    partial class AddUserViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CancelButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FirstNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FirstNameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LastNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LastNameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PasswordLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StatusMessageLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView UserInputContainerView { get; set; }

        [Action ("OnCancel:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnCancel (UIKit.UIButton sender);

        [Action ("OnSubmit:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnSubmit (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CancelButton != null) {
                CancelButton.Dispose ();
                CancelButton = null;
            }

            if (FirstNameLabel != null) {
                FirstNameLabel.Dispose ();
                FirstNameLabel = null;
            }

            if (FirstNameText != null) {
                FirstNameText.Dispose ();
                FirstNameText = null;
            }

            if (LastNameLabel != null) {
                LastNameLabel.Dispose ();
                LastNameLabel = null;
            }

            if (LastNameText != null) {
                LastNameText.Dispose ();
                LastNameText = null;
            }

            if (PasswordLabel != null) {
                PasswordLabel.Dispose ();
                PasswordLabel = null;
            }

            if (PasswordText != null) {
                PasswordText.Dispose ();
                PasswordText = null;
            }

            if (StatusMessageLabel != null) {
                StatusMessageLabel.Dispose ();
                StatusMessageLabel = null;
            }

            if (SubmitButton != null) {
                SubmitButton.Dispose ();
                SubmitButton = null;
            }

            if (UserInputContainerView != null) {
                UserInputContainerView.Dispose ();
                UserInputContainerView = null;
            }
        }
    }
}
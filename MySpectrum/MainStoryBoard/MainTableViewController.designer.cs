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
    [Register ("MainTableViewController")]
    partial class MainTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddUserButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView MainScreenImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView TableContainerView { get; set; }

        [Action ("OnTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnTouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AddUserButton != null) {
                AddUserButton.Dispose ();
                AddUserButton = null;
            }

            if (MainScreenImageView != null) {
                MainScreenImageView.Dispose ();
                MainScreenImageView = null;
            }

            if (TableContainerView != null) {
                TableContainerView.Dispose ();
                TableContainerView = null;
            }
        }
    }
}
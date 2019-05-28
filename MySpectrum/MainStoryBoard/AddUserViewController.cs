using ApplicationServices.ViewModels;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using System;
using UIKit;

namespace MySpectrum
{
    public partial class AddUserViewController : UIViewController
    {

        UsersViewModel _vm = null;
        private Binding _firstNameBinding;
        private Binding _lastNameBinding;
        private Binding _passwordBinding;
        private Binding _statusMessage;

        public AddUserViewController (IntPtr handle) : base (handle)
        {
            //get the current UsersViewModel instance
            _vm = UsersViewModel.GetCurrentUsersViewModel();

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PasswordText.SecureTextEntry = true;

            ///////////////////////////
            //set our MVVM bindings
                _firstNameBinding = this.SetBinding(
                    () => FirstNameText.Text)
                    .ObserveSourceEvent("EditingDidEnd")
                    .WhenSourceChanges(() => _vm.FirstName = FirstNameText.Text);


                _lastNameBinding = this.SetBinding(
                    () => LastNameText.Text)
                    .ObserveSourceEvent("EditingDidEnd")
                    .WhenSourceChanges(() => _vm.LastName = LastNameText.Text);


                _passwordBinding = this.SetBinding(
                    () => PasswordText.Text)
                    .ObserveSourceEvent("EditingChanged")
                    .WhenSourceChanges(() => _vm.Password = PasswordText.Text);

                _statusMessage = this.SetBinding(
                    () => _vm.StatusMessage,
                    () => StatusMessageLabel.Text);
            ///////////////////////////
        }



        partial void OnSubmit(UIButton sender)
        {

           if(_vm.SubmitUser())
            {
                DismissViewController(true, null);
            }

        }

        partial void OnCancel(UIButton sender)
        {
            DismissViewController(true, null);
        }
    }
}
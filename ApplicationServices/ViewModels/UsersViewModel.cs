using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ApplicationServices.SimpleIoC;
using Domain.DatabaseModelInterface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Domain.ValueObjects;
using Domain;
using DomainServices.DatabaseModel;

namespace ApplicationServices.ViewModels
{
    public class UsersViewModel : ViewModelBase, IUsersViewModel
    {
        Domain.Application.IApplication currentApplication;
        DomainServices.UserEntityRepository _repository;
        private RelayCommand _submitUserCommand;

        public UsersViewModel()
        {
            currentApplication = SimpleIocContainer.Current.Resolve<Domain.Application.IApplication>();
            UserCollection = new ObservableCollection<IUser>();
            _repository = new DomainServices.UserEntityRepository(currentApplication.GetRepositoryStorage());

           //SubmitUserCommand = new RelayCommand(SubmitUser, () => CanSubmitUser);
        }

        public ObservableCollection<IUser> UserCollection { get; }

        public void LoadUserCollection()
        {
            List<IUser> list = _repository.GetAllUsers();

            foreach (var current in list)
            {
                UserCollection.Add(current);
            }
        }


        /// <summary>
        /// Helper Static Method to Register View Model with our Simple IoC Container
        /// </summary>
        public static UsersViewModel GetCurrentUsersViewModel()
        {
            UsersViewModel returnValue = null;

            returnValue = (UsersViewModel)SimpleIocContainer.Current.Resolve<IUsersViewModel>();

            if(returnValue == null)
            {
                returnValue = new UsersViewModel();
                SimpleIocContainer.Current.Register<IUsersViewModel>(returnValue);
            }


            return returnValue;

        }

        string _firstName;
        string _lastName;
        string _password;
        string _statusMessage;


        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                RaisePropertyChanged(() => StatusMessage);
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged(() => FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                RaisePropertyChanged(() => LastName);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value == _password) return;
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public RelayCommand SubmitUserCommand
        {
            get
            {
                return _submitUserCommand;
            }
            private set
            {
                _submitUserCommand = value;
            }
        }
        public bool CanSubmitUser
        {
            get;
            set;
        }


        /// <summary>
        /// Validates the user input
        /// </summary>
        /// <returns><c>true</c>, if user was submited, <c>false</c> otherwise.</returns>
        public bool SubmitUser()
        {
            bool returnValue = true;

            CanSubmitUser = false;
            StatusMessage = string.Empty;

            try
            {
                //the value object creation validates the input and throws an exception if any fails
                Domain.ValueObjects.FirstName fn = new Domain.ValueObjects.FirstName(_firstName);

                Domain.ValueObjects.LastName ln = new Domain.ValueObjects.LastName(_lastName);

                Domain.ValueObjects.Password pw = new Domain.ValueObjects.Password(_password);

                //if no error occurs on the value object creation, we can insert our user.
                IUserEntity user = new UserEntity(fn, ln, pw);
                if(_repository.AddUser(user))
                {
                    UserCollection.Add(new User { FirstName = fn.Value, LastName = ln.Value, Password = pw.Value });
                }


            } catch(Exception ex)
            {
                StatusMessage = ex.Message;
                returnValue = false;
            }
                


            CanSubmitUser = true;

            return returnValue;
        }
    }
}

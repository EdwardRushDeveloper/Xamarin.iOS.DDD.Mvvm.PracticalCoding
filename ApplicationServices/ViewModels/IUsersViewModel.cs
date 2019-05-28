using System.Collections.ObjectModel;
using Domain.DatabaseModelInterface;

namespace ApplicationServices.ViewModels
{
    public interface IUsersViewModel
    {
        ObservableCollection<IUser> UserCollection { get; }

        void LoadUserCollection();
    }
}
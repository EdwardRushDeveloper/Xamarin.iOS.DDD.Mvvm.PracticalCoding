
using Domain;
using Foundation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using ApplicationServices.SimpleIoC;
using Domain.DatabaseModelInterface;
using GalaSoft.MvvmLight.Helpers;
using ApplicationServices.ViewModels;

namespace MySpectrum
{
    public partial class MainTableViewController : UIViewController
    {
        private ObservableTableViewController<IUser> _currentTableViewController;
        private UITableView AssociateTableView;
        Domain.Application.IApplication currentApplication;
        UsersViewModel _vm = null;

        public MainTableViewController (IntPtr handle) : base (handle)
        {
            currentApplication = SimpleIocContainer.Current.Resolve<Domain.Application.IApplication>();
            _vm = UsersViewModel.GetCurrentUsersViewModel();
        }


        /// <summary>
        /// Does the initial data load of the table 
        /// </summary>
        public void LoadTable()
        {
            AssociateTableView = new UITableView(new CoreGraphics.CGRect(0, 0, TableContainerView.Bounds.Width, TableContainerView.Bounds.Height));
           
            AssociateTableView.RegisterClassForCellReuse(typeof(MainCustomCell), nameof(MainCustomCell));

            AssociateTableView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            AssociateTableView.CellLayoutMarginsFollowReadableWidth = false;

           

            //generate our repository instance to access our list of users.

            //MainTableViewTableSource tableSource = new MainTableViewTableSource(list);

            AssociateTableView.TranslatesAutoresizingMaskIntoConstraints = false;


            var parentMargins = View.LayoutMarginsGuide;

            //AssociateTableView.Source = tableSource;
            TableContainerView.AddSubview(AssociateTableView);


            _currentTableViewController = _vm.UserCollection.GetController(CreatePersonCell, BindCellDelegate);

            _currentTableViewController.TableView = AssociateTableView;

            _currentTableViewController.GetViewForHeaderDelegate   = MainCustomCell.GetViewForHeader;
            _currentTableViewController.GetHeightForHeaderDelegate = MainCustomCell.GetHeightForHeader;

            _vm.LoadUserCollection();

        }

        private UITableViewCell CreatePersonCell(NSString cellIdentifier)
        {
            return AssociateTableView.DequeueReusableCell(nameof(MainCustomCell));
        }

        private void BindCellDelegate(UITableViewCell cell, IUser userItem, NSIndexPath path)
        {
            var bindableCell = (MainCustomCell)cell;
            bindableCell.Configure(userItem);
        }

        public override void ViewDidLoad()
        {
            LoadTable();
            base.ViewDidLoad();
        }

        partial void OnTouchUpInside(UIButton sender)
        {
            UIStoryboard storyBoard = this.Storyboard;

            AddUserViewController controller = (AddUserViewController)storyBoard.InstantiateViewController("AddUserViewController");
            this.PresentViewController(controller, true, null);
        }


    }
}
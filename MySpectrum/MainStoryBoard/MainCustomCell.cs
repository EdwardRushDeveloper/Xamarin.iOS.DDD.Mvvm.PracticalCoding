using System;
using UIKit;
using GalaSoft.MvvmLight.Helpers;
using Domain.DatabaseModelInterface;

namespace MySpectrum
{
    public class MainCustomCell : UITableViewCell
    {

        IUser _cellItem;
        UILabel _firstNameLabel;
        UILabel _lastNameLabel;

        public MainCustomCell(IntPtr handler) : base(handler)
        {
            CreateCell();
        }

        public MainCustomCell()
        {
            CreateCell();
        }

        public Binding<string, string> _firstNameBinding;
        public Binding<string, string> _lastNameBinding;



        internal void Configure(IUser userItem)
        {
            _cellItem = userItem;

            _firstNameBinding = this.SetBinding(() => _cellItem.FirstName, () => _firstNameLabel.Text);
            _lastNameBinding = this.SetBinding(() => _cellItem.LastName, () => _lastNameLabel.Text);

        }

        public override void PrepareForReuse()
        {
            base.PrepareForReuse();
            _firstNameBinding?.Detach();
            _lastNameBinding?.Detach();
        }
        private void CreateCell()
        {


            //RemainingTimeLabel = new UILabel();
            //AddSubview(RemainingTimeLabel);
            //RemainingTimeLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            //RemainingTimeLabel.CenterYAnchor.ConstraintEqualTo(LayoutMarginsGuide.CenterYAnchor).Active = true;
            //RemainingTimeLabel.LeftAnchor.ConstraintEqualTo(LayoutMarginsGuide.LeftAnchor, 8).Active = true;



            _firstNameLabel = new UILabel(new CoreGraphics.CGRect(0, 5, 100f, 22f));
            AddSubview(_firstNameLabel);
            _firstNameLabel.Font = UIFont.SystemFontOfSize(16f);
            _firstNameLabel.TextAlignment = UITextAlignment.Left;
            _firstNameLabel.TextColor = UIColor.Black;


            _lastNameLabel = new UILabel(new CoreGraphics.CGRect(101, 5, 300f, 22f));
            AddSubview(_lastNameLabel);
            _lastNameLabel.Font = UIFont.SystemFontOfSize(16f);
            _lastNameLabel.TextAlignment = UITextAlignment.Left;
            _lastNameLabel.TextColor = UIColor.Black;
       

        }



        /// <summary>
        /// Definition for the Header of the MVVM ObservableTable object
        /// </summary>
        /// <returns>The view for header.</returns>
        /// <param name="tableView">Table view.</param>
        /// <param name="section">Section.</param>
        public static UIView GetViewForHeader(UIKit.UITableView tableView, nint section)
        {
          
            var headerView = new UITableViewHeaderFooterView();
            headerView.BackgroundColor = UIColor.FromRGB(173, 203, 209);


            UILabel fn = new UILabel(new CoreGraphics.CGRect(0, 5, 100f, 22f));
            fn.Font = UIFont.SystemFontOfSize(14f);
            fn.TextAlignment = UITextAlignment.Left;
            fn.TextColor = UIColor.Black;
            fn.Text = "First Name";

            UILabel ln = new UILabel(new CoreGraphics.CGRect(101, 5, 300f, 22f));
            ln.Font = UIFont.SystemFontOfSize(14f);
            ln.TextAlignment = UITextAlignment.Left;
            ln.TextColor = UIColor.Black;
            ln.Text = "Last Name";

            headerView.Add(fn);
            headerView.Add(ln);
            return headerView;
        }

        /// <summary>
        /// The Height of the Header
        /// </summary>
        /// <returns>The height for header.</returns>
        /// <param name="tableView">Table view.</param>
        /// <param name="section">Section.</param>
        public static nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 35;
        }
    }
}

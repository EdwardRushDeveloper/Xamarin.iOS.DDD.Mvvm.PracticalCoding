using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain;
using Domain.DatabaseModelInterface;
using Foundation;
using UIKit;

namespace MySpectrum
{
    public class MainTableViewTableSource : UITableViewSource
    {

        string CellIdentifier = "SpectrumCell";
       //List<IUser> _list = null;
        ObservableCollection<IUser> _list = null;

        public MainTableViewTableSource(ObservableCollection<IUser> userList)
        {
            _list = userList;
        }


        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _list.Count;
        }


        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            IUser current = _list[indexPath.Row];

        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

            IUser item = _list[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier);
            }


            if (cell.Subviews.Length > 0)
            {
                foreach (var sv in cell.Subviews)
                {
                    sv.RemoveFromSuperview();
                }
            }

            cell.BackgroundColor = UIColor.White;


            UILabel fn = new UILabel(new CoreGraphics.CGRect(0, 5, 100f, 22f));
            fn.Font = UIFont.SystemFontOfSize(16f);
            fn.TextAlignment = UITextAlignment.Left;
            fn.TextColor = UIColor.Black;
            fn.Text = item.FirstName;

            UILabel ln = new UILabel(new CoreGraphics.CGRect(101, 5, 300f, 22f));
            ln.Font = UIFont.SystemFontOfSize(16f);
            ln.TextAlignment = UITextAlignment.Left;
            ln.TextColor = UIColor.Black;
            ln.Text =  item.LastName;



            cell.Add(fn);
            cell.Add(ln);


            //cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;

            return cell;

        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
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

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 30f;
        }
    }
}

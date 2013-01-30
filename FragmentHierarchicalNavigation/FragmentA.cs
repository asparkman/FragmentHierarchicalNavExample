using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using ActionbarSherlock.App;

namespace FragmentHierarchicalNavigation
{
    public class FragmentA : AbstractFragment
    {
        public FragmentA()
        {
            this.Value = 0;
            this.Layout = Resource.Layout.Fragment;
            this.SetHasOptionsMenu(true);
        }

        public FragmentA(int value)
        {
            this.Value = value;
            this.Layout = Resource.Layout.Fragment;
            this.SetHasOptionsMenu(true);
        }

        public override void OnPrepareOptionsMenu(ActionbarSherlock.View.IMenu p0)
        {
            base.OnPrepareOptionsMenu(p0);

            this.AppLog("Begin OnPrepareOptionsMenu()");

            var goDeeper = p0.Add(Resource.String.go_deeper_action_bar_label);
            goDeeper.SetIntent(new Intent(this.GetMenuActionId(Resource.String.go_deeper_action_bar_label)));
            goDeeper.SetIcon(Resource.Drawable.ic_action_inc_seed);
            goDeeper.SetShowAsAction(ActionbarSherlock.View.MenuItem.ShowAsActionAlways);

            var viewDetails = p0.Add(Resource.String.view_details_action_bar_label);
            viewDetails.SetIntent(new Intent(this.GetMenuActionId(Resource.String.view_details_action_bar_label)));
            viewDetails.SetIcon(Resource.Drawable.ic_action_search);
            viewDetails.SetShowAsAction(ActionbarSherlock.View.MenuItem.ShowAsActionAlways);
        }

        public override bool OnOptionsItemSelected(ActionbarSherlock.View.IMenuItem p0)
        {
            if (p0.Intent == null)
                return false;

            if (this.GetMenuActionId(Resource.String.go_deeper_action_bar_label).Equals(p0.Intent.Action))
            {
                OnGoDeeperButtonClick();

                return true;
            }
            else if (this.GetMenuActionId(Resource.String.view_details_action_bar_label).Equals(p0.Intent.Action))
            {
                OnViewDetailsButtonClick();

                return true;
            }
            return false;
        }

        public void OnGoDeeperButtonClick()
        {
            this.AppLog("goDeeperBtn.Click");

            this.AppLog("Begin go deeper view transaction.");
            var goDeeperTransaction = GetTransaction();

            this.AppLog("Replace go deeper view transaction.");
            goDeeperTransaction.Replace(Resource.Id.fragment, new FragmentA(this.Value + 1));

            this.AppLog("Add go deeper view transaction to back stack.");
            goDeeperTransaction.AddToBackStack(null);

            this.AppLog("Commit go deeper view transaction.");
            goDeeperTransaction.Commit();
        }

        public void OnViewDetailsButtonClick()
        {
            this.AppLog("viewDetailsBtn.Click");


            this.AppLog("Begin details view transaction.");
            var detailsViewTransaction = GetTransaction();
            if (this.Activity.FindViewById(Resource.Id.fragment2) == null)
            {
                this.AppLog("Replace details view transaction.");
                detailsViewTransaction.Replace(Resource.Id.fragment, new FragmentB(this.Value));

                this.AppLog("Add details view transaction to back stack.");
                detailsViewTransaction.AddToBackStack(null);

                this.AppLog("Commit details view transaction.");
                detailsViewTransaction.Commit();
            }
            else
            {
                this.AppLog("Replace details view transaction.");
                detailsViewTransaction.Replace(Resource.Id.fragment2, new FragmentB(this.Value));

                this.AppLog("Commit details view transaction.");
                detailsViewTransaction.Commit();
            }
        }

        public override string GetOutput()
        {
            var outputMessage = string.Format("Value = {0}", this.Value.ToString());
            this.AppLog(outputMessage);
            return outputMessage;
        }

        public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2)
        {
            this.AppLog("Begin FragmentA OnCreateView");

            var createdView = base.OnCreateView(p0, p1, p2);

            this.AppLog("End FragmentA OnCreateView");
            return createdView;
        }
    }
}
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
        }

        public FragmentA(int value)
        {
            this.Value = value;
            this.Layout = Resource.Layout.Fragment;
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

            var viewDetailsBtn = createdView.FindViewById<Button>(Resource.Id.view_details_button);

            viewDetailsBtn.Click += (o, e) =>
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
            };

            var goDeeperBtn = createdView.FindViewById<Button>(Resource.Id.go_deeper_button);

            goDeeperBtn.Click += (o, e) =>
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
                };

            this.AppLog("End FragmentA OnCreateView");
            return createdView;
        }
    }
}
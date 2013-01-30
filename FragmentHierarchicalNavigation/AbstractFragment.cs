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
using Android.Support.V4.App;

namespace FragmentHierarchicalNavigation
{
    public abstract class AbstractFragment : SherlockFragment
    {
        public int Value;
        public int Layout;
        protected TextView _OutputView;

        public abstract string GetOutput();

        public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2)
        {
            this.AppLog("Begin AbstractFragment OnCreateView");

            var createdView = p0.Inflate(Layout, p1, false);

            _OutputView = createdView.FindViewById<TextView>(Resource.Id.output);

            _OutputView.Text = GetOutput();

            return createdView;
        }

        public void AppLog(string message)
        {
            var outputMessage = string.Format("class:{0} <<< message:{1}", this.GetType().ToString(), message);

            Log.Debug("FragmentNavEx", outputMessage);
        }

        public String GetMenuActionId(int label)
        {
            return this.GetType().ToString() + ":" + label.ToString();
        }

        public FragmentTransaction GetTransaction()
        {
            var transaction = this.FragmentManager.BeginTransaction();
            transaction.SetTransition(FragmentTransaction.TransitFragmentClose);

            return transaction;
        }
    }
}
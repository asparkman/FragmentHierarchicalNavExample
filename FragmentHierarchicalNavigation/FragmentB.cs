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
    public class FragmentB : AbstractFragment
    {
        private Random _Random;

        public FragmentB()
        {
            this.Value = 0;
            this.Layout = Resource.Layout.FragmentB;
            _Random = new Random(this.Value);
            this.SetHasOptionsMenu(true);
        }

        public FragmentB(int value)
        {
            this.Value = value;
            this.Layout = Resource.Layout.FragmentB;
            _Random = new Random(this.Value);
            this.SetHasOptionsMenu(true);
        }

        public override void OnPrepareOptionsMenu(ActionbarSherlock.View.IMenu p0)
        {
            base.OnPrepareOptionsMenu(p0);

            this.AppLog("Begin OnPrepareOptionsMenu()");

            var nextValue = p0.Add(Resource.String.next_value_action_bar_label);
            nextValue.SetIntent(new Intent(this.GetMenuActionId(Resource.String.next_value_action_bar_label)));
            nextValue.SetIcon(Resource.Drawable.ic_action_send);
            nextValue.SetShowAsAction(ActionbarSherlock.View.MenuItem.ShowAsActionAlways);
        }

        public override bool OnOptionsItemSelected(ActionbarSherlock.View.IMenuItem p0)
        {
            if (p0.Intent == null)
                return false;

            if (this.GetMenuActionId(Resource.String.next_value_action_bar_label).Equals(p0.Intent.Action))
            {
                this._OutputView.Text = GetOutput();

                return true;
            }
            return false;
        }

        public override string GetOutput()
        {
            var randInt = _Random.Next().ToString();
            var outputMessage = string.Format("Value = {0}, RandInt = {1}", this.Value, randInt);
            this.AppLog(outputMessage);
            return outputMessage;
        }

        public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2)
        {
            this.AppLog("Begin FragmentB OnCreateView");
            var createdView = base.OnCreateView(p0, p1, p2);

            this.AppLog("End FragmentB OnCreateView");
            return createdView;
        }
    }
}
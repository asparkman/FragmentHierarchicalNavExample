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
        public FragmentB()
        {
            this.Value = 0;
            this.Layout = Resource.Layout.FragmentB;
        }

        public FragmentB(int value)
        {
            this.Value = value;
            this.Layout = Resource.Layout.FragmentB;
        }

        public override string GetOutput()
        {
            var rand = new Random(this.Value);
            var randInt = rand.Next().ToString();
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
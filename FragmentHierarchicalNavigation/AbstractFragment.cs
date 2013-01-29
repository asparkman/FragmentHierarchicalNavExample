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
    public abstract class AbstractFragment : SherlockFragment
    {
        public int Value;

        public abstract string GetOutput();

        public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2)
        {
            this.AppLog("Begin AbstractFragment OnCreateView");

            var createdView = p0.Inflate(Resource.Layout.Fragment, p1, false);

            var outputView = createdView.FindViewById<TextView>(Resource.Id.output);

            outputView.Text = GetOutput();

            return createdView;
        }

        public void AppLog(string message)
        {
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
            var outputMessage = string.Format("caller:{0}\n", t.GetFrames()[1]);
            outputMessage += string.Format("class:{0}\n", this.GetType().ToString());
            outputMessage += string.Format("message:{0}\n", message);

            Log.Debug("FragmentNavEx", message);
        }
    }
}
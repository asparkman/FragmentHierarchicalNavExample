using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Support.V4.App;

using ActionbarSherlock.App;
using Android.Text;
using Android.Util;
namespace FragmentHierarchicalNavigation
{
    [Activity(Label = "FragmentHierarchicalNavigation", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.Sherlock")]
    public class Main : SherlockFragmentActivity
    {
        public void AppLog(string message)
        {
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
            var outputMessage = string.Format("caller:{0}\n", t.GetFrames()[1]);
            outputMessage += string.Format("class:{0}\n", this.GetType().ToString());
            outputMessage += string.Format("message:{0}\n", message);

            Log.Debug("FragmentNavEx", message);
        }

        public override bool OnCreateOptionsMenu(ActionbarSherlock.View.IMenu p0)
        {
            this.AppLog("Begin OnCreateOptionsMenu");
            return base.OnCreateOptionsMenu(p0);
        }

        public override bool OnOptionsItemSelected(ActionbarSherlock.View.IMenuItem p0)
        {
            this.AppLog(string.Format("Begin OnOptionsItemSelected, ItemId = {0}, Icon = {1}", p0.ItemId, (p0.TitleFormatted ?? new SpannedString("null")).ToString()));
            switch (p0.ItemId)
            {
                case Resource.Id.homeAsUp:
                    this.AppLog("OnOptionsItemSelected Resource.Id.homeAsUp");
                    this.SupportFragmentManager.PopBackStack();
                    break;
                default:
                    this.AppLog("OnOptionsItemSelected ???");
                    break;
            }
            return base.OnOptionsItemSelected(p0);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            try
            {
                SetContentView(Resource.Layout.Main);
            }
            catch(NotSupportedException ex)
            {
                this.AppLog(ex.Message);
                this.AppLog(ex.ToString());
            }

            /*
            this.AppLog("Set Display Home As Up Enabled");
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            this.AppLog("Beginning initial FragmentA transaction.");
            var transaction = this.SupportFragmentManager.BeginTransaction();

            this.AppLog("Performing replace for initial FragmentA transaction.");
            transaction.Replace(Resource.Id.fragment, new FragmentA(0));

            this.AppLog("AddToBackStack for initial FragmentA transaction.");
            transaction.AddToBackStack(null);

            this.AppLog("Commit for initial FragmentA transaction.");
            transaction.Commit();
            */
        }
    }
}


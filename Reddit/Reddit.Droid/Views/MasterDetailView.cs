using System;

using Android.App;
using Android.Views;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V7.App;
using Reddit.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;
using Android.Support.V4.Widget;

namespace Reddit.Droid
{
	[Activity (Label = "Reddit.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MasterDetailView : MvxCachingFragmentCompatActivity<MasterDetailViewModel>
    {
        private ActionBarDrawerToggle _drawerToggle;
        private ListView _drawerListView;
        private DrawerLayout _drawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MasterDetailView);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            _drawerListView = FindViewById<ListView>(Resource.Id.drawerListView);
            _drawerListView.ItemClick += (s, e) => ShowFragmentAt(e.Position);
            _drawerListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1, ViewModel.MenuItems.ToArray());
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            _drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, Resource.String.OpenDrawerString, Resource.String.CloseDrawerString);
            _drawerLayout.AddDrawerListener(_drawerToggle);

            ShowFragmentAt(0);
        }

        void ShowFragmentAt(int position)
        {
            ViewModel.NavigateTo(position);
            Title = ViewModel.MenuItems[position];
            _drawerLayout.CloseDrawer(_drawerListView);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            _drawerToggle.SyncState();
            base.OnPostCreate(savedInstanceState);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return _drawerToggle.OnOptionsItemSelected(item) ? true : base.OnOptionsItemSelected(item);
        }
    }
}



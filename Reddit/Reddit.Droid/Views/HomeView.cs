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
using MvvmCross.Droid.Support.V4;
using Reddit.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.BindingContext;

namespace Reddit.Droid
{
    [MvxFragmentAttribute(typeof(MasterDetailViewModel), Resource.Id.frameLayout)]
    [Register("reddit.droid.HomeView")]
    public class HomeView : MvxFragment<HomeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(savedInstanceState);
            return this.BindingInflate(Resource.Layout.HomeView, null);
        }
    }
}
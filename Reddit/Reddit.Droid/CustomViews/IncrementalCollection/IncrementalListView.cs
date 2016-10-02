using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using Android.Util;

namespace Reddit.Droid.CustomViews.IncrementalCollection
{
    public class IncrementalListView : MvxListView
    {
        public IncrementalListView(Context context, IAttributeSet attrs) : base(context, attrs, new IncrementalAdapter(context)) { }
        protected IncrementalListView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }
    }
}
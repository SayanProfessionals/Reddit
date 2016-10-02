using System;
using System.Collections;
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
using Reddit.CustomViews.IncrementalCollection;
using System.Threading.Tasks;
using Nito.AsyncEx;
using MvvmCross.Binding.Droid.BindingContext;

namespace Reddit.Droid.CustomViews.IncrementalCollection
{
    public class IncrementalAdapter : MvxAdapter
    {
        private int _lastCount;
        private int _maxPositionReached;

        public IncrementalAdapter(Context context) : base(context) { }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if ((position >= _maxPositionReached) && (position >= _lastCount))
            {
                _maxPositionReached = position;
                LoadMoreItems();
            }

            return base.GetView(position, convertView, parent);
        }

        protected override void SetItemsSource(IEnumerable value)
        {
            base.SetItemsSource(value);
            _lastCount = 0;
            _maxPositionReached = 0;
            LoadMoreItems();
        }

        private void LoadMoreItems()
        {
            NotifyTaskCompletion.Create(LoadMoreItemsAsync());
        }

        public async Task LoadMoreItemsAsync()
        {
            var source = ItemsSource as ICoreSupportIncrementalLoading;

            if (source != null)
            {
                _lastCount = Count;
                await source.LoadMoreItemsAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.CustomViews.IncrementalCollection
{
    public class IncrementalCollection<T> : ObservableCollection<T>, ICoreSupportIncrementalLoading
    {
        private readonly Func<int, int, Task<ObservableCollection<T>>> _sourceDataFunc;

        public IncrementalCollection(Func<int, int, Task<ObservableCollection<T>>> sourceDataFunc, int pageSize)
        {
            _sourceDataFunc = sourceDataFunc;
            PageSize = pageSize;
        }

        public async Task LoadMoreItemsAsync()
        {
            var sourceData = await _sourceDataFunc(Count, PageSize);

            foreach (T item in sourceData)
            {
                Add(item);
            }
        }

        public int PageSize { get; }
    }

    public interface ICoreSupportIncrementalLoading
    {
        Task LoadMoreItemsAsync();
    }

    public interface IIncrementalCollectionFactory
    {
        ObservableCollection<T> GetCollection<T>(Func<int, int, Task<ObservableCollection<T>>> sourceDataFunc, int pageSize = 10);
    }

    public class IncrementalCollectionFactory : IIncrementalCollectionFactory
    {
        public ObservableCollection<T> GetCollection<T>(Func<int, int, Task<ObservableCollection<T>>> sourceDataFunc, int pageSize = 10)
        {
            return new IncrementalCollection<T>(sourceDataFunc, pageSize);
        }
    }
}

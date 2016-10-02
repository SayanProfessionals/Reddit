using MvvmCross.Core.ViewModels;
using Reddit.CustomViews.IncrementalCollection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IIncrementalCollectionFactory _incrementalCollectionFactory;
        private readonly int _numberListPageSize = 30;
        private ObservableCollection<NumberViewModel> _redditItems;

        public HomeViewModel(IIncrementalCollectionFactory incrementalCollectionFactory)
        {
            _incrementalCollectionFactory = incrementalCollectionFactory;
        }

        public ObservableCollection<NumberViewModel> RedditItems
        {
            get
            {
                if (_redditItems == null)
                {
                    // The IncrementalCollectionFactory returns a generic ObservableCollection. In this example, 
                    // it returns ObservableCollection<NumberViewModel>. Replace this with your own ViewModel.

                    _redditItems = _incrementalCollectionFactory.GetCollection(async (count, pageSize) =>
                    {
                        ObservableCollection<NumberViewModel> newNumbers = new ObservableCollection<NumberViewModel>();

                        // Call an async method here to load the data from a data source that supports paging.
                        // This is a dummy implementaion.

                        await Task.Run(() =>
                        {
                            for (int n = count; n < (count + pageSize); n++)
                            {
                                NumberViewModel numberViewModel = new NumberViewModel();
                                numberViewModel.Value = n;
                                newNumbers.Add(numberViewModel);
                            }
                        });

                        return newNumbers;
                    }, _numberListPageSize);
                }

                return _redditItems;
            }
        }
    }

    public class NumberViewModel
    {
        public int Value { get; set; }
    }
}

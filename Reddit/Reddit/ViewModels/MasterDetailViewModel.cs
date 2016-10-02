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
    public class MasterDetailViewModel : MvxViewModel
    {
        private readonly IList<Type> _menuItemTypes;
        public List<string> MenuItems { get; }

        public MasterDetailViewModel(IIncrementalCollectionFactory incrementalCollectionFactory)
        {
            _menuItemTypes = new List<Type>
            {
                typeof(HomeViewModel)
            };

            MenuItems = new List<string>
            {
                "Home"
            };
        }

        public void ShowDefaultMenuItem()
        {
            NavigateTo(0);
        }

        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }
}

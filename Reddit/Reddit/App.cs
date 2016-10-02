using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Reddit.CustomViews.IncrementalCollection;
using Reddit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            RegisterAppStart<MasterDetailViewModel>();
        }
    }
}

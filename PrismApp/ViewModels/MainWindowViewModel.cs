using PrismApp.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.ViewModels
{
    public class MainWindowViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        private string title = "测试程序";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        public MainWindowViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;
        }
    }
}

using Prism.Regions;
using PrismApp.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Views.Controller.ViewModels
{
    public class HomeViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public HomeViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;
        }
    }
}

using Prism.Regions;
using PrismApp.Core.Mvvm;
using PrismApp.Interfaces;
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

        private string? message= "不行";

        public string? Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }


        public HomeViewModel(IRegionManager regionManager,IMessageService messageService) : base(regionManager)
        {

            _regionManager = regionManager;
            
            Message = messageService.GetMessage();

        }
    }
}

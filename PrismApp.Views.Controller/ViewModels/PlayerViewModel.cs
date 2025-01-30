using PrismApp.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Views.Controller.ViewModels
{

        public class PlayerViewModel : RegionViewModelBase
        {
            #region 字段

            private readonly IRegionManager _regionManager;

            #endregion

            #region 属性

            #endregion

            #region 命令

            #endregion

            #region 方法

            public PlayerViewModel(IRegionManager regionManager) : base(regionManager)
            {
                _regionManager = regionManager;
            }

            #endregion
        }
    }


﻿using PrismApp.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismApp.ViewModels
{
    public class MainWindowViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        private string title = "测试程序";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        // 工作区高度
        public double WorkAreaHeight { get { return SystemParameters.WorkArea.Height; } }
        // 工作区宽度
        public double WorkAreaWidth { get { return SystemParameters.WorkArea.Width; } }

        #endregion


        public MainWindowViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;
        }
    }
}

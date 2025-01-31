using PrismApp.Core.Constants;
using PrismApp.Core.Mvvm;
using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Views.Controller.ViewModels
{
    public class SettingViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;
        private readonly IFloderService _floderService;

        #endregion

        #region 属性

        private string musicPath;
        /// <summary>
        /// 音乐读取地址
        /// </summary>
        public string MusicPath
        {
            get { return musicPath; }
            set { SetProperty(ref musicPath, value); }
        }


        #endregion

        #region 命令

        public DelegateCommand<string> DelegateCommand { get; set; }

        #endregion

        #region 方法

        public SettingViewModel(IRegionManager regionManager, IFloderService floderService) : base(regionManager)
        {
            _regionManager = regionManager;
            _floderService = floderService;
            DelegateCommand = new DelegateCommand<string>(DelegateMethod);

            GlobalVariable.IsMusicFolderHas();
            // 获取音乐文件夹路径
            MusicPath = GlobalVariable.FolderPath;

        }

        private void DelegateMethod(string switch_on)
        {
            switch (switch_on)
            {
                default:
                    break;
            }
        }

        #endregion
    }
}

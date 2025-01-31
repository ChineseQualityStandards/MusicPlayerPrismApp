using PrismApp.Core.Constants;
using PrismApp.Core.Mvvm;
using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismApp.Views.Controller.ViewModels
{
    public class HomeViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        private string? message;

        public string? Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        #endregion

        #region 命令

        public DelegateCommand<string> DelegateCommand { get; set; }

        #endregion

        #region 方法

        public HomeViewModel(IRegionManager regionManager,IMessageService messageService) : base(regionManager)
        {

            _regionManager = regionManager;

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);

            Message = "Hello from HomeViewModel";

        }

        private void DelegateMethod(string switch_on)
        {
            switch (switch_on)
            {
                // 退出程序
                case "Exit":
                    Exit();
                    break;
                // 最大化窗口
                case "MaximizeOrNormal":
                    MaximizeOrNormal();
                    break;
                // 最小化窗口
                case "Minimize":
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                    break;
                // 默认操作
                case "Setting":
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.SettingView);
                    break;
                default:
                    Message = $"按下按钮{switch_on}";
                    break;
            }
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        private void Exit()
        {
            if (MessageBox.Show("确认退出应用？", "请选择", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 最大化或者正常化窗口
        /// </summary>
        private void MaximizeOrNormal()
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        #endregion
    }
}

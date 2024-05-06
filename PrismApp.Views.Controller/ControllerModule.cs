using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismApp.Views.Controller.ViewModels;
using PrismApp.Views.Controller.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Views.Controller
{
    public class ControllerModule : IModule
    {
        /// <summary>
        /// 区域管理器
        /// </summary>
        private readonly IRegionManager _regionManager;

        public ControllerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// 进行初始化模块通知
        /// </summary>
        /// <param name="containerProvider">容器服务解析函数</param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate("MainRegion", "HomeView");
        }

        /// <summary>
        /// 告知应用程序对应注册容器的类型
        /// </summary>     
        /// <param name="containerRegistry">注册容器</param>
        /// <remarks>如果属性没更新看下这里</remarks>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeView,HomeViewModel>();
        }
    }
}

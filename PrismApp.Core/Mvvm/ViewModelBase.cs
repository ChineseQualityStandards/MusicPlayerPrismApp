using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Mvvm
{
    public class ViewModelBase : BindableBase, IDestructible
    {
        #region 函数

        /// <summary>
        /// ViewModelBase构造函数
        /// </summary>
        public ViewModelBase()
        {
        }

        /// <summary>
        /// 销毁函数
        /// </summary>
        public void Destroy()
        {
            //throw new NotImplementedException();
        }

        #endregion

    }
}

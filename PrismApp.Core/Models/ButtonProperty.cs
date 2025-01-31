using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Models
{
    /// <summary>
    /// 按钮相关属性
    /// </summary>
    public class ButtonProperty : BindableBase
    {
        private IconProperty? icon;
        /// <summary>
        /// 图标属性
        /// </summary>
        public IconProperty? Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        private EButtonType? type;
        /// <summary>
        /// 按钮类型
        /// </summary>
        public EButtonType? Type
        {
            get { return type; }
            set { SetProperty(ref type,value); }
        }
        private string? typeName;
        /// <summary>
        /// 按钮类型名
        /// </summary>
        public string? TypeName
        {
            get { return typeName; }
            set { SetProperty(ref typeName, value); }
        }

        private string? toolTip;
        /// <summary>
        /// 按键提示
        /// </summary>
        public string? ToolTip
        {
            get { return toolTip; }
            set { SetProperty(ref toolTip, value); }
        }

    }
}

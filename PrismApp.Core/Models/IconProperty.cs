using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Models
{
    /// <summary>
    /// 图标属性
    /// </summary>
    public class IconProperty
    {
        public IconProperty(string? code, EButtonType? type)
        {
            Code = code;
            Type = type;
        }

        public IconProperty(string? code, int? height, EButtonType? type, int? width)
        {
            Code = code;
            Height = height;
            Type = type;
            Width = width;
        }

        /// <summary>
        /// 图标代码
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// 图标高
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// 按键类型
        /// </summary>
        public EButtonType? Type { get; set; }
        /// <summary>
        /// 图标宽
        /// </summary>
        public int? Width { get; set; }
    }
}

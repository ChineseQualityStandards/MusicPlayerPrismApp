using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismApp.Views.Controller.Views
{
    /// <summary>
    /// LyricView.xaml 的交互逻辑
    /// </summary>
    public partial class LyricView : UserControl
    {
        public LyricView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当歌词选中时跳到该位置
        /// </summary>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LyricListBox != null)
                LyricListBox.ScrollIntoView(LyricListBox.SelectedItem);
        }
    }
}

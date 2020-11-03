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
using Utils;

namespace Utils.Test.Wpf
{
    /// <summary>
    /// 工具类测试
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 构造函数
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region 测试TryInvoke
        private void btnTryInvoke_Click(object sender, RoutedEventArgs e)
        {
            TaskHelper.UITask.Run(() =>
            {
                this.TryInvokeAsync(() =>
                {
                    Log("测试TryInvoke");
                    throw new Exception("TryBeginInvoke中产生异常");
                });
            });

        }
        #endregion

        #region 测试TextBox
        private void btnTestTextBox_Click(object sender, RoutedEventArgs e)
        {
            TaskHelper.RequestTask.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    this.TryInvokeAsync(() =>
                    {
                        Log("测试TryInvoke");
                    });
                }
            });
        }
        #endregion

    }
}

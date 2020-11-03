using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Test.Wpf
{
    public partial class MainWindow
    {
        #region 输出到文本框
        /// <summary>
        /// 输出到文本框
        /// </summary>
        /// <param name="msg"></param>
        private void Log(string msg)
        {
            this.Dispatcher.InvokeAsync(new Action(() =>
            {
                txt.Text += msg + "\r\n";
                txt.ScrollToEnd();
            }));
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Utils
{
    /// <summary>
    /// Action工具类
    /// </summary>
    public static class ActionUtil
    {
        #region TryDoAction
        /// <summary>
        /// 带异常处理的Action
        /// </summary>
        public static void TryDoAction(Action action, Action<Exception> errorAction = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (errorAction != null) errorAction(ex);
                LogUtil.Error(ex);
            }
        }
        #endregion

        #region TryDoFunc
        /// <summary>
        /// 带异常处理的Func
        /// </summary>
        public static TResult TryDoFunc<TResult>(Func<TResult> func, Action<Exception> errorAction = null)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                if (errorAction != null) errorAction(ex);
                LogUtil.Error(ex);
                return default(TResult);
            }
        }
        #endregion

        #region Winform TryBeginInvoke
        /// <summary>
        /// Winform使用的带异常处理的BeginInvoke
        /// </summary>
        public static void TryBeginInvoke(this Control ctrl, Action action, Action<Exception> errorAction = null)
        {
            ctrl.BeginInvoke(new Action(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    if (errorAction != null) errorAction(ex);
                    LogUtil.Error(ex);
                }
            }));
        }
        #endregion

        #region Winform TryBeginInvoke
        /// <summary>
        /// Winform使用的带异常处理的BeginInvoke
        /// </summary>
        public static void TryBeginInvoke2(this Control ctrl, Action action, Action<Exception> errorAction = null)
        {
            ctrl.BeginInvoke(new Action(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    if (errorAction != null) errorAction(ex);
                    LogUtil.Error(ex);
                }
            }));
        }
        #endregion

        #region WPF TryInvokeAsync
        /// <summary>
        /// WPF使用的带异常处理的InvokeAsync
        /// </summary>
        public static void TryInvokeAsync(this DispatcherObject ctrl, Action action, Action<Exception> errorAction = null)
        {
            ctrl.Dispatcher.InvokeAsync(new Action(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    if (errorAction != null) errorAction(ex);
                    LogUtil.Error(ex);
                }
            }));
        }
        #endregion

        #region WPF TryBeginInvoke
        /// <summary>
        /// WPF使用的带异常处理的BeginInvoke
        /// </summary>
        public static void TryBeginInvoke(this DispatcherObject ctrl, Action action, Action<Exception> errorAction = null)
        {
            ctrl.Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    if (errorAction != null) errorAction(ex);
                    LogUtil.Error(ex);
                }
            }));
        }
        #endregion

    }
}

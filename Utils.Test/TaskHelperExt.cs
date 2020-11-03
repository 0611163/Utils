using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class TaskHelperExt : TaskHelper
    {
        #region 临时任务
        private static LimitedTaskScheduler _TempTask;
        /// <summary>
        /// 临时任务(4个线程)
        /// </summary>
        public static LimitedTaskScheduler TempTask
        {
            get
            {
                if (_TempTask == null) _TempTask = new LimitedTaskScheduler(4);
                return _TempTask;
            }
        }
        #endregion

    }
}

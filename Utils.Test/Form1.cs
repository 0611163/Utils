using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils.Test
{
    /// <summary>
    /// 工具类测试
    /// </summary>
    public partial class Form1 : Form
    {
        #region 变量
        private TaskSchedulerEx _task0806 = null;
        #endregion

        #region Form1构造函数
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadPool.SetMaxThreads(5001, 5001);
            ThreadPool.SetMinThreads(5000, 5000);

            Task.Run(() =>
            {
                if (_task0806 == null) _task0806 = new TaskSchedulerEx(100, 5000);
            });

            ServiceHelper.RegisterAssembly("Utils.Test");
            ServiceHelper.RegisterAssembly("Utils");
        }
        #endregion

        #region 日志
        private void btnLog_Click(object sender, EventArgs e)
        {
            LogUtil.Log("测试日志工具类");
        }
        #endregion

        #region 异常日志
        private void btnLogError_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse("测试");
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
            }
        }
        #endregion

        #region 线程
        private void btnThread_Click(object sender, EventArgs e)
        {
            TaskHelper.UITask.Run(() =>
            {
                this.TryBeginInvoke(() =>
                {
                    Log("测试线程");
                });
            });
        }
        #endregion

        #region 测试TryInvoke
        private void btnTryInvoke_Click(object sender, EventArgs e)
        {
            TaskHelper.UITask.Run(() =>
            {
                this.TryBeginInvoke(() =>
                {
                    Log("测试TryInvoke");
                    //throw new Exception("TryBeginInvoke中产生异常");
                });
            });
        }
        #endregion

        #region 测试CacheUtil
        private void btnCacheUtil_Click(object sender, EventArgs e)
        {
            int n = 10;
            //测试数据
            List<PtCameraInfo> list = new List<PtCameraInfo>();
            for (int i = 0; i < n; i++)
            {
                PtCameraInfo info = new PtCameraInfo();
                info.ID = "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk" + i;
                info.CAMERA_NAME = "习友路和玉兰大道交口北100米枪机1" + i;
                info.CAMERA_NO = "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" + i;
                info.LATITUDE = "31.8888888888" + i;
                info.LONGITUDE = "117.8888888888" + i;
                info.CAMERA_STATE = "1";
                info.ADDRESS = "习友路和玉兰大道交口北100米" + i;
                info.CAMERA_TYPE = 100;
                info.ORG_ID = 10303;
                info.CAMERA_DIRECTION = "6";
                info.SHORT_MSG = "试数据测试数据测试数据数据测试数据试数据测试数据测试数据数据测试数据据试数据测试数据测试数据数据测试数据" + i;
                list.Add(info);
            }

            TaskHelper.DBTask.Run(() =>
            {
                //CacheUtil.GetValue("测试key");
                //CacheUtil.SetValue("测试key", list);
                this.TryBeginInvoke(() =>
                {
                    //List<PtCameraInfo> result = CacheUtil.GetValue("测试key") as List<PtCameraInfo>;
                    //Log("读出缓存数据量：" + result.Count.ToString());
                });
            });

            TaskHelper.DBTask.Run(() =>
            {
                //CacheUtil2已删除
                /* 
                CacheUtil2.GetValue<List<PtCameraInfo>>("测试key2");
                CacheUtil2.SetValue<List<PtCameraInfo>>("测试key2", list);
                this.TryBeginInvoke(() =>
                {
                    List<PtCameraInfo> result = CacheUtil2.GetValue<List<PtCameraInfo>>("测试key2");
                    Log("读出缓存数据量：" + result.Count.ToString());
                });
                */
            });
        }
        #endregion

        #region 测试TaskHelper异常
        private void btnTask_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            TaskHelper.UITask.Run(() =>
            {
                if (rnd.Next(0, 2) == 0)
                {
                    throw new Exception("产生异常");
                }

                this.TryBeginInvoke(() =>
                {
                    Log("正常");
                });
            }, (ex) =>
            {
                this.TryBeginInvoke(() =>
                {
                    Log("异常信息：" + ex.Message);
                });
            });
        }
        #endregion

        #region 测试TaskHelper
        private int _clickCount = 0;

        private void btnTask2_Click(object sender, EventArgs e)
        {
            int n = 10000;

            Task.Factory.StartNew(() =>
            {
                _clickCount++;
                int count = 0;
                object lockCount = new object();
                this.TryBeginInvoke(() =>
                {
                    txt.Text = string.Empty;
                });

                TaskHelper.RequestTask.CancelAll();

                for (int i = 0; i < n; i++)
                {
                    TaskHelper.RequestTask.Run((obj) =>
                    {
                        int clickCount = (int)obj;

                        Thread.Sleep(50);

                        this.TryBeginInvoke(() =>
                        {
                            lock (lockCount)
                            {
                                count++;
                                if (count == 1 || count % 50 == 0)
                                {
                                    Log("点击次数：" + clickCount + "    处理数量：" + count.ToString() + " / " + n.ToString());
                                }
                            }
                        });
                    }, _clickCount);
                }
            });
        }
        #endregion

        #region Task扩展类测试
        private void btnTaskExt_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                this.TryBeginInvoke(() =>
                {
                    //txt.Text = string.Empty;
                });

                List<Task> taskList = new List<Task>();
                for (int i = 0; i < 10; i++)
                {
                    Task task = TaskHelperExt.TempTask.Run(() =>
                    {
                        this.TryBeginInvoke2(() =>
                        {
                            Log("Task扩展类测试TempTask");
                        });
                    });
                    taskList.Add(task);
                }

                Task.WaitAll(taskList.ToArray());

                Log(string.Empty);

                List<Task> taskList2 = new List<Task>();
                for (int i = 0; i < 10; i++)
                {
                    Task task2 = TaskHelperExt.IOTask.Run(() =>
                    {
                        this.TryBeginInvoke2(() =>
                        {
                            Log("Task扩展类测试IOTask");
                        });
                    });
                    taskList2.Add(task2);
                }

                Task.WaitAll(taskList2.ToArray());

                Log(string.Empty);
            });
        }
        #endregion

        #region LimitedTaskScheduler测试
        private void btnScheduler_Click(object sender, EventArgs e)
        {
            TaskHelper.UITask.Run(() =>
            {
                Log("开始");
                LimitedTaskScheduler scheduler = new LimitedTaskScheduler(100);

                List<Task> taskList = new List<Task>();
                for (int i = 0; i < 10; i++)
                {
                    Task task = scheduler.Run(() =>
                    {
                        //Thread.Sleep(100);
                        this.TryBeginInvoke2(() =>
                        {
                            Log("LimitedTaskScheduler测试");
                        });
                    });
                    taskList.Add(task);
                }

                Task.WaitAll(taskList.ToArray());

                scheduler.Dispose();
            });
        }


        #endregion

        #region 缓存测试
        private void btnCacheTest_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    TaskHelper.RequestTask.Run(() =>
                    {
                        Log("开始");
                        List<string> result = CacheUtil.TryGetValue<List<string>>("key", () =>
                        {
                            List<string> data = new List<string>();
                            for (int k = 0; k < 100; k++)
                            {
                                data.Add("测试数据");
                            }
                            Thread.Sleep(5000);
                            return data;
                        }, false, 5);
                        Log(result[0]);
                    });

                    Thread.Sleep(100);
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    TaskHelper.RequestTask.Run(() =>
                    {
                        Log("开始2");
                        List<string> result = CacheUtil.TryGetValue<List<string>>("key2", () =>
                        {
                            List<string> data = new List<string>();
                            for (int k = 0; k < 100; k++)
                            {
                                data.Add("测试数据2");
                            }
                            Thread.Sleep(5000);
                            return data;
                        }, false, 5);
                        Log(result[0] + "2");
                    });

                    Thread.Sleep(100);
                }
            });
        }
        #endregion

        #region 缓存并发测试
        private void btnCacheConcurrentTest_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    TaskHelper.RequestTask.Run(() =>
                    {
                        Log("开始");
                        //object value = CacheUtil.GetValue("key");
                        //if (value != null)
                        //{
                        //    List<string> result = value as List<string>;
                        //    Log("读取到缓存key：" + result[0]);
                        //}
                        //else
                        //{
                        //    Log("缓存key尚不存在");
                        //}
                    });

                    Thread.Sleep(100);
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    TaskHelper.RequestTask.Run(() =>
                    {
                        //Log("开始2");
                        //object value = CacheUtil.GetValue("key2");
                        //if (value != null)
                        //{
                        //    List<string> result = value as List<string>;
                        //    Log("读取到缓存key2：" + result[0] + "2");
                        //}
                        //else
                        //{
                        //    Log("缓存key2尚不存在");
                        //}
                    });

                    Thread.Sleep(100);
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    TaskHelper.RequestTask.Run(() =>
                    {
                        Log("开始");
                        List<string> result = CacheUtil.TryGetValue<List<string>>("key", () =>
                        {
                            List<string> data = new List<string>();
                            for (int k = 0; k < 10000000; k++)
                            {
                                data.Add("测试数据");
                            }
                            Thread.Sleep(5000);
                            return data;
                        }, false, 0);
                        Log("读取并写入缓存key：" + result[0]);
                    });

                    Thread.Sleep(100);
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    TaskHelper.RequestTask.Run(() =>
                    {
                        Log("开始2");
                        List<string> result = CacheUtil.TryGetValue<List<string>>("key2", () =>
                        {
                            List<string> data = new List<string>();
                            for (int k = 0; k < 10000000; k++)
                            {
                                data.Add("测试数据2");
                            }
                            Thread.Sleep(5000);
                            return data;
                        }, false, 0);
                        Log("读取并写入缓存key：" + result[0] + "2");
                    });

                    Thread.Sleep(100);
                }
            });
        }
        #endregion

        #region Task<T>测试
        private void btnTestTaskT_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Log("开始");

                Task<string> t1 = TaskHelper.UITask.Run<string>(() =>
                {
                    Thread.Sleep(1000);
                    return "123";
                });

                string str = "abc";
                Task<string> t2 = TaskHelper.UITask.Run<string>((obj) =>
                {
                    Thread.Sleep(1000);
                    return obj + "123";
                }, str);

                Task.WaitAll(t1, t2);

                Log("输出：" + t1.Result);
                Log("输出：" + t2.Result);
            });
        }
        #endregion

        #region Task<T>测试2
        private void btnTestTaskT2_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Log("开始");

                Task<string> t1 = TaskHelper.UITask.RunAsync<string>(() =>
                {
                    Thread.Sleep(1000);
                    return "123";
                });

                string str = "abc";
                Task<string> t2 = TaskHelper.UITask.RunAsync<string>((obj) =>
                {
                    Thread.Sleep(1000);
                    return obj + "123";
                }, str);

                string r1 = await t1;
                string r2 = await t2;

                Log("输出：" + r1);
                Log("输出：" + r2);
            });
        }
        #endregion

        #region ModelHelper测试
        private void btnModelHelper_Click(object sender, EventArgs e)
        {
            try
            {
                Log("开始");

                PtCameraInfo info1 = new PtCameraInfo();
                info1.CAMERA_NAME = "测试名称";
                info1.CAMERA_NO = "00123";
                info1.KeyUnit = 3;

                PtCameraInfo2 info2 = ModelHelper.Convert<PtCameraInfo2>(info1);
                PtCameraInfo info3 = ModelHelper.Convert<PtCameraInfo>(info2);

                Log("成功");
            }
            catch (Exception ex)
            {
                Log("失败：" + ex.Message);
            }
        }
        #endregion

        #region 测试RunAsync
        private void button1_Click(object sender, EventArgs e)
        {
            TaskSchedulerEx _task = new TaskSchedulerEx(2, 2);
            string str = null;

            BackWork.RunAsync(() =>
            {
                Thread.Sleep(1);
                str = "001";
            }, () =>
            {
                Log("输出" + str);
            });

            BackWork.RunAsync(() =>
            {
                Thread.Sleep(1);
                Log("输出002");
            });

            Task t = _task.RunAsync(() =>
            {
                Log("输出" + "003");
                Thread.Sleep(3000);
                Log("输出" + "003_1");
            });
        }
        #endregion

        #region 测试CacheUtil
        private bool testRefreshCache = false;

        private void btnCacheUtil2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                List<PtCameraInfo> list = GetData2();
                Log("list 数量：" + list.Count);
            });
        }

        private List<PtCameraInfo> GetData1()
        {
            return CacheUtil.TryGetValue<List<PtCameraInfo>>("testkey1", () =>
            {
                Log("调用 GetData1 的 func");

                if (!testRefreshCache)
                {
                    return CreateCacheTestData(10);
                }
                else
                {
                    return CreateCacheTestData(20);
                }
            }, false, 0, false) ?? new List<PtCameraInfo>();
        }

        private List<PtCameraInfo> GetData2()
        {
            return CacheUtil.TryGetValue<List<PtCameraInfo>>("testkey2", () =>
            {
                Log("调用 GetData2 的 func");

                List<PtCameraInfo> result = new List<PtCameraInfo>();

                result.AddRange(GetData1());

                if (!testRefreshCache)
                {
                    result.AddRange(CreateCacheTestData(100));
                }
                else
                {
                    result.AddRange(CreateCacheTestData(200));
                }

                return result;
            }, false, 0, false) ?? new List<PtCameraInfo>();
        }

        #region 创建缓存测试数据
        /// <summary>
        /// 创建缓存测试数据
        /// </summary>
        private List<PtCameraInfo> CreateCacheTestData(int n = 10)
        {
            List<PtCameraInfo> list = new List<PtCameraInfo>();
            for (int i = 0; i < n; i++)
            {
                PtCameraInfo info = new PtCameraInfo();
                info.ID = "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk" + i;
                info.CAMERA_NAME = "习友路和玉兰大道交口北100米枪机1" + i;
                info.CAMERA_NO = "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" + i;
                info.LATITUDE = "31.8888888888" + i;
                info.LONGITUDE = "117.8888888888" + i;
                info.CAMERA_STATE = "1";
                info.ADDRESS = "习友路和玉兰大道交口北100米" + i;
                info.CAMERA_TYPE = 100;
                info.ORG_ID = 10303;
                info.CAMERA_DIRECTION = "6";
                info.SHORT_MSG = "试数据测试数据测试数据数据测试数据试数据测试数据测试数据数据测试数据据试数据测试数据测试数据数据测试数据" + i;
                list.Add(info);
            }
            Thread.Sleep(1000); //模拟延迟
            return list;
        }
        #endregion

        #endregion

        #region 测试刷新缓存
        private void btnRefreshCache_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                testRefreshCache = true;

                CacheUtil.DeleteAll();

                List<PtCameraInfo> list = GetData2();
                Log("list 数量：" + list.Count);

                testRefreshCache = false;
            });
        }
        #endregion

        #region 测试LogTime
        private void btnLogTime_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                LogTimeUtil log = new LogTimeUtil();
                Thread.Sleep(500);
                log.LogTime("等待1", true);
                Thread.Sleep(600);
                log.LogTime("等待2", true);
                Thread.Sleep(300);
                log.LogTime("等待3");
            });
        }
        #endregion

        #region Task扩展类测试
        private void btnTask3_Click(object sender, EventArgs e)
        {
            int n = 10000;

            Task.Factory.StartNew(() =>
            {
                if (_task0806 == null) _task0806 = new TaskSchedulerEx(100, 5000);

                Thread.Sleep(100);

                _clickCount++;
                this.TryBeginInvoke(() =>
                {
                    txt.Text = string.Empty;
                });

                _task0806.CancelAll();

                for (int i = 1; i <= n; i++)
                {
                    _task0806.Run((obj) =>
                    {
                        dynamic data = (dynamic)obj;

                        if (data.i % 100 == 0)
                        {
                            Log("开始 点击次数：" + data.clickCount + "    处理数量：" + data.i.ToString() + " / " + n.ToString());
                        }

                        Thread.Sleep(5000);

                        if (data.i % 100 == 0)
                        {
                            //Log("结束 点击次数：" + data.clickCount + "    处理数量：" + data.i.ToString() + " / " + n.ToString());
                        }
                    }, new { clickCount = _clickCount, i = i });
                }
            });
        }
        #endregion

        #region Task扩展类测试对比
        private void btnTask4_Click(object sender, EventArgs e)
        {
            int n = 10000;

            Task.Factory.StartNew(() =>
            {
                _clickCount++;
                this.TryBeginInvoke(() =>
                {
                    txt.Text = string.Empty;
                });

                for (int i = 1; i <= n; i++)
                {
                    Task.Factory.StartNew((obj) =>
                    {
                        dynamic data = (dynamic)obj;

                        if (data.i % 100 == 0)
                        {
                            Log("开始 点击次数：" + data.clickCount + "    处理数量：" + data.i.ToString() + " / " + n.ToString());
                        }

                        Thread.Sleep(5000);

                        if (data.i % 100 == 0)
                        {
                            //Log("结束 点击次数：" + data.clickCount + "    处理数量：" + data.i.ToString() + " / " + n.ToString());
                        }
                    }, new { clickCount = _clickCount, i = i });
                }
            });
        }
        #endregion

        #region IOC
        private void btnIoc_Click(object sender, EventArgs e)
        {
            string result = ServiceHelper.Resove<ITestService>().Get("123");
            Log(result);
        }
        #endregion

    }
}

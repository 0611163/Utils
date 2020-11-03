using System;

namespace Utils.Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLog = new System.Windows.Forms.Button();
            this.txt = new System.Windows.Forms.TextBox();
            this.btnThread = new System.Windows.Forms.Button();
            this.btnLogError = new System.Windows.Forms.Button();
            this.btnTryInvoke = new System.Windows.Forms.Button();
            this.btnCacheUtil = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            this.btnTask2 = new System.Windows.Forms.Button();
            this.btnTaskExt = new System.Windows.Forms.Button();
            this.btnScheduler = new System.Windows.Forms.Button();
            this.btnCacheTest = new System.Windows.Forms.Button();
            this.btnCacheConcurrentTest = new System.Windows.Forms.Button();
            this.btnTestTaskT = new System.Windows.Forms.Button();
            this.btnTestTaskT2 = new System.Windows.Forms.Button();
            this.btnModelHelper = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCacheUtil2 = new System.Windows.Forms.Button();
            this.btnRefreshCache = new System.Windows.Forms.Button();
            this.btnLogTime = new System.Windows.Forms.Button();
            this.btnTask3 = new System.Windows.Forms.Button();
            this.btnTask4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(13, 13);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(100, 23);
            this.btnLog.TabIndex = 0;
            this.btnLog.Text = "日志";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(554, 15);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt.Size = new System.Drawing.Size(482, 670);
            this.txt.TabIndex = 1;
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(13, 42);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(100, 23);
            this.btnThread.TabIndex = 2;
            this.btnThread.Text = "线程";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // btnLogError
            // 
            this.btnLogError.Location = new System.Drawing.Point(119, 12);
            this.btnLogError.Name = "btnLogError";
            this.btnLogError.Size = new System.Drawing.Size(100, 23);
            this.btnLogError.TabIndex = 3;
            this.btnLogError.Text = "异常日志";
            this.btnLogError.UseVisualStyleBackColor = true;
            this.btnLogError.Click += new System.EventHandler(this.btnLogError_Click);
            // 
            // btnTryInvoke
            // 
            this.btnTryInvoke.Location = new System.Drawing.Point(119, 42);
            this.btnTryInvoke.Name = "btnTryInvoke";
            this.btnTryInvoke.Size = new System.Drawing.Size(100, 23);
            this.btnTryInvoke.TabIndex = 4;
            this.btnTryInvoke.Text = "TryInvoke";
            this.btnTryInvoke.UseVisualStyleBackColor = true;
            this.btnTryInvoke.Click += new System.EventHandler(this.btnTryInvoke_Click);
            // 
            // btnCacheUtil
            // 
            this.btnCacheUtil.Location = new System.Drawing.Point(13, 71);
            this.btnCacheUtil.Name = "btnCacheUtil";
            this.btnCacheUtil.Size = new System.Drawing.Size(100, 23);
            this.btnCacheUtil.TabIndex = 5;
            this.btnCacheUtil.Text = "CacheUtil";
            this.btnCacheUtil.UseVisualStyleBackColor = true;
            this.btnCacheUtil.Click += new System.EventHandler(this.btnCacheUtil_Click);
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(119, 71);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(100, 23);
            this.btnTask.TabIndex = 6;
            this.btnTask.Text = "Task异常测试";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // btnTask2
            // 
            this.btnTask2.Location = new System.Drawing.Point(13, 100);
            this.btnTask2.Name = "btnTask2";
            this.btnTask2.Size = new System.Drawing.Size(100, 23);
            this.btnTask2.TabIndex = 7;
            this.btnTask2.Text = "Task测试";
            this.btnTask2.UseVisualStyleBackColor = true;
            this.btnTask2.Click += new System.EventHandler(this.btnTask2_Click);
            // 
            // btnTaskExt
            // 
            this.btnTaskExt.Location = new System.Drawing.Point(119, 100);
            this.btnTaskExt.Name = "btnTaskExt";
            this.btnTaskExt.Size = new System.Drawing.Size(100, 23);
            this.btnTaskExt.TabIndex = 8;
            this.btnTaskExt.Text = "Task扩展类";
            this.btnTaskExt.UseVisualStyleBackColor = true;
            this.btnTaskExt.Click += new System.EventHandler(this.btnTaskExt_Click);
            // 
            // btnScheduler
            // 
            this.btnScheduler.Location = new System.Drawing.Point(13, 129);
            this.btnScheduler.Name = "btnScheduler";
            this.btnScheduler.Size = new System.Drawing.Size(100, 23);
            this.btnScheduler.TabIndex = 9;
            this.btnScheduler.Text = "Scheduler";
            this.btnScheduler.UseVisualStyleBackColor = true;
            this.btnScheduler.Click += new System.EventHandler(this.btnScheduler_Click);
            // 
            // btnCacheTest
            // 
            this.btnCacheTest.Location = new System.Drawing.Point(119, 129);
            this.btnCacheTest.Name = "btnCacheTest";
            this.btnCacheTest.Size = new System.Drawing.Size(100, 23);
            this.btnCacheTest.TabIndex = 10;
            this.btnCacheTest.Text = "缓存测试";
            this.btnCacheTest.UseVisualStyleBackColor = true;
            this.btnCacheTest.Click += new System.EventHandler(this.btnCacheTest_Click);
            // 
            // btnCacheConcurrentTest
            // 
            this.btnCacheConcurrentTest.Location = new System.Drawing.Point(12, 158);
            this.btnCacheConcurrentTest.Name = "btnCacheConcurrentTest";
            this.btnCacheConcurrentTest.Size = new System.Drawing.Size(100, 23);
            this.btnCacheConcurrentTest.TabIndex = 11;
            this.btnCacheConcurrentTest.Text = "缓存并发测试";
            this.btnCacheConcurrentTest.UseVisualStyleBackColor = true;
            this.btnCacheConcurrentTest.Click += new System.EventHandler(this.btnCacheConcurrentTest_Click);
            // 
            // btnTestTaskT
            // 
            this.btnTestTaskT.Location = new System.Drawing.Point(118, 158);
            this.btnTestTaskT.Name = "btnTestTaskT";
            this.btnTestTaskT.Size = new System.Drawing.Size(100, 23);
            this.btnTestTaskT.TabIndex = 12;
            this.btnTestTaskT.Text = "Task<T>测试";
            this.btnTestTaskT.UseVisualStyleBackColor = true;
            this.btnTestTaskT.Click += new System.EventHandler(this.btnTestTaskT_Click);
            // 
            // btnTestTaskT2
            // 
            this.btnTestTaskT2.Location = new System.Drawing.Point(12, 187);
            this.btnTestTaskT2.Name = "btnTestTaskT2";
            this.btnTestTaskT2.Size = new System.Drawing.Size(100, 23);
            this.btnTestTaskT2.TabIndex = 13;
            this.btnTestTaskT2.Text = "Task<T>测试2";
            this.btnTestTaskT2.UseVisualStyleBackColor = true;
            this.btnTestTaskT2.Click += new System.EventHandler(this.btnTestTaskT2_Click);
            // 
            // btnModelHelper
            // 
            this.btnModelHelper.Location = new System.Drawing.Point(119, 187);
            this.btnModelHelper.Name = "btnModelHelper";
            this.btnModelHelper.Size = new System.Drawing.Size(100, 23);
            this.btnModelHelper.TabIndex = 14;
            this.btnModelHelper.Text = "ModelHelper";
            this.btnModelHelper.UseVisualStyleBackColor = true;
            this.btnModelHelper.Click += new System.EventHandler(this.btnModelHelper_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "RunAsync";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCacheUtil2
            // 
            this.btnCacheUtil2.Location = new System.Drawing.Point(119, 216);
            this.btnCacheUtil2.Name = "btnCacheUtil2";
            this.btnCacheUtil2.Size = new System.Drawing.Size(100, 23);
            this.btnCacheUtil2.TabIndex = 16;
            this.btnCacheUtil2.Text = "CacheUtil";
            this.btnCacheUtil2.UseVisualStyleBackColor = true;
            this.btnCacheUtil2.Click += new System.EventHandler(this.btnCacheUtil2_Click);
            // 
            // btnRefreshCache
            // 
            this.btnRefreshCache.Location = new System.Drawing.Point(13, 245);
            this.btnRefreshCache.Name = "btnRefreshCache";
            this.btnRefreshCache.Size = new System.Drawing.Size(100, 23);
            this.btnRefreshCache.TabIndex = 17;
            this.btnRefreshCache.Text = "刷新缓存";
            this.btnRefreshCache.UseVisualStyleBackColor = true;
            this.btnRefreshCache.Click += new System.EventHandler(this.btnRefreshCache_Click);
            // 
            // btnLogTime
            // 
            this.btnLogTime.Location = new System.Drawing.Point(119, 245);
            this.btnLogTime.Name = "btnLogTime";
            this.btnLogTime.Size = new System.Drawing.Size(100, 23);
            this.btnLogTime.TabIndex = 18;
            this.btnLogTime.Text = "测试LogTime";
            this.btnLogTime.UseVisualStyleBackColor = true;
            this.btnLogTime.Click += new System.EventHandler(this.btnLogTime_Click);
            // 
            // btnTask3
            // 
            this.btnTask3.Location = new System.Drawing.Point(13, 274);
            this.btnTask3.Name = "btnTask3";
            this.btnTask3.Size = new System.Drawing.Size(100, 23);
            this.btnTask3.TabIndex = 19;
            this.btnTask3.Text = "Task测试";
            this.btnTask3.UseVisualStyleBackColor = true;
            this.btnTask3.Click += new System.EventHandler(this.btnTask3_Click);
            // 
            // btnTask4
            // 
            this.btnTask4.Location = new System.Drawing.Point(119, 274);
            this.btnTask4.Name = "btnTask4";
            this.btnTask4.Size = new System.Drawing.Size(100, 23);
            this.btnTask4.TabIndex = 20;
            this.btnTask4.Text = "Task测试";
            this.btnTask4.UseVisualStyleBackColor = true;
            this.btnTask4.Click += new System.EventHandler(this.btnTask4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 697);
            this.Controls.Add(this.btnTask4);
            this.Controls.Add(this.btnTask3);
            this.Controls.Add(this.btnLogTime);
            this.Controls.Add(this.btnRefreshCache);
            this.Controls.Add(this.btnCacheUtil2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnModelHelper);
            this.Controls.Add(this.btnTestTaskT2);
            this.Controls.Add(this.btnTestTaskT);
            this.Controls.Add(this.btnCacheConcurrentTest);
            this.Controls.Add(this.btnCacheTest);
            this.Controls.Add(this.btnScheduler);
            this.Controls.Add(this.btnTaskExt);
            this.Controls.Add(this.btnTask2);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.btnCacheUtil);
            this.Controls.Add(this.btnTryInvoke);
            this.Controls.Add(this.btnLogError);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.btnLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试Utils工具类库";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region 输出到文本框
        /// <summary>
        /// 输出到文本框
        /// </summary>
        /// <param name="msg"></param>
        private void Log(string msg)
        {
            this.BeginInvoke(new Action(() =>
            {
                txt.AppendText("【" + DateTime.Now.ToString("mm:ss.fff") + "】" + msg + "\r\n");
            }));
        }
        #endregion

        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button btnThread;
        private System.Windows.Forms.Button btnLogError;
        private System.Windows.Forms.Button btnTryInvoke;
        private System.Windows.Forms.Button btnCacheUtil;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Button btnTask2;
        private System.Windows.Forms.Button btnTaskExt;
        private System.Windows.Forms.Button btnScheduler;
        private System.Windows.Forms.Button btnCacheTest;
        private System.Windows.Forms.Button btnCacheConcurrentTest;
        private System.Windows.Forms.Button btnTestTaskT;
        private System.Windows.Forms.Button btnTestTaskT2;
        private System.Windows.Forms.Button btnModelHelper;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCacheUtil2;
        private System.Windows.Forms.Button btnRefreshCache;
        private System.Windows.Forms.Button btnLogTime;
        private System.Windows.Forms.Button btnTask3;
        private System.Windows.Forms.Button btnTask4;
    }
}


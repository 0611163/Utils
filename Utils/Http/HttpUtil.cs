using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Utils
{
    /// <summary>
    /// Http上传下载文件
    /// </summary>
    public class HttpUtil
    {
        #region HttpDownloadFile 下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">下载文件url路径</param>
        /// <param name="cookie">cookie</param>
        public static MemoryStream HttpDownloadFile(string url, CookieContainer cookie = null, WebHeaderCollection headers = null)
        {
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.CookieContainer = cookie;

                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                    {
                        request.Headers.Add(key, headers[key]);
                    }
                }

                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();

                //创建写入流
                MemoryStream stream = new MemoryStream();

                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                stream.Seek(0, SeekOrigin.Begin);
                responseStream.Close();

                return stream;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
                return null;
            }
        }
        #endregion

        #region HttpUploadFile 上传文件
        /// <summary>
        /// Http上传文件
        /// </summary>
        /// <param name="url">上传文件url路径</param>
        /// <param name="bArr">byte数据上传文件</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="cookie">cookie</param>
        public static string HttpUploadFile(string url, byte[] bArr, string fileName, CookieContainer cookie = null, WebHeaderCollection headers = null)
        {
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
                request.ContentType = "text/plain;charset=utf-8";
                request.CookieContainer = cookie;

                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                    {
                        request.Headers.Add(key, headers[key]);
                    }
                }

                Stream postStream = request.GetRequestStream();
                postStream.Write(bArr, 0, bArr.Length);
                postStream.Close();

                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                instream.Close();

                return content;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
                return string.Empty;
            }
        }
        #endregion

        #region HttpPost
        /// <summary>
        /// HttpPost
        /// </summary>
        /// <param name="url">url路径名称</param>
        /// <param name="data">需要传输的数据</param>
        /// <param name="cookie">cookie</param>
        public static string HttpPost(string url, string data, CookieContainer cookie = null, WebHeaderCollection headers = null)
        {
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = cookie;
                request.Method = "POST";
                request.ContentType = "application/json";

                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                    {
                        request.Headers.Add(key, headers[key]);
                    }
                }

                if (data != null)
                {
                    byte[] bArr = ASCIIEncoding.UTF8.GetBytes(data);

                    request.ContentLength = bArr.Length;

                    Stream postStream = request.GetRequestStream();
                    postStream.Write(bArr, 0, bArr.Length);
                    postStream.Close();
                }

                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                instream.Close();

                return content;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
                return string.Empty;
            }
        }
        #endregion

        #region HttpPost
        /// <summary>
        /// HttpPost
        /// </summary>
        /// <param name="url">url路径名称</param>
        /// <param name="cookie">cookie</param>
        public static string HttpPost(string url, CookieContainer cookie = null, WebHeaderCollection headers = null)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.CookieContainer = cookie;
            request.Method = "POST";
            request.ContentType = "application/json";

            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    request.Headers.Add(key, headers[key]);
                }
            }

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            instream.Close();

            return content;
        }
        #endregion

        #region HttpGet
        /// <summary>
        /// HttpGet
        /// </summary>
        /// <param name="url">url路径名称</param>
        /// <param name="cookie">cookie</param>
        public static string HttpGet(string url, CookieContainer cookie = null, WebHeaderCollection headers = null)
        {
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = cookie;
                request.Method = "GET";
                request.ContentType = "text/plain;charset=utf-8";

                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                    {
                        request.Headers.Add(key, headers[key]);
                    }
                }

                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                instream.Close();
                return content;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
                return string.Empty;
            }
        }
        #endregion

        #region HttpGet
        /// <summary>
        /// HttpGet
        /// </summary>
        /// <param name="url">url路径名称</param>
        /// <param name="cookieOut">传出的cookie</param>
        /// <param name="cookie">cookie</param>
        public static string HttpGet(string url, out Cookie cookieOut, CookieContainer cookie = null, WebHeaderCollection headers = null)
        {
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = cookie;
                request.Method = "GET";
                request.ContentType = "text/plain;charset=utf-8";

                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                    {
                        request.Headers.Add(key, headers[key]);
                    }
                }

                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                instream.Close();

                //获取Cookie
                CookieCollection cookieCollection = request.CookieContainer.GetCookies(request.RequestUri);
                if (cookieCollection != null && cookieCollection.Count > 0)
                {
                    cookieOut = cookieCollection[0];
                }
                else
                {
                    cookieOut = null;
                }

                return content;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
                cookieOut = null;
                return string.Empty;
            }
        }
        #endregion

    }
}

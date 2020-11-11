using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

/**
 * 创建者：suxiang
 * 创建日期：2020年05月18日
 */

namespace Utils
{
    /// <summary>
    /// FTP工具类
    /// </summary>
    public class FtpUtil
    {
        #region 文件夹是否存在
        /// <summary>
        /// 文件夹是否存在
        /// </summary>
        /// <param name="ftpPath">ftp路径</param>
        /// <param name="ftpUserId">用户名</param>
        /// <param name="ftpPassword">密码</param>
        /// <param name="folderName">文件夹名称</param>
        public static bool FolderExists(string ftpPath, string ftpUserId, string ftpPassword, string folderName)
        {
            try
            {
                FtpWebRequest request = null;

                request = (FtpWebRequest)WebRequest.Create(new Uri(ftpPath));
                request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                request.Method = "LIST";
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                MemoryStream stream = new MemoryStream();
                byte[] bArr = new byte[1024 * 1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                stream.Seek(0, SeekOrigin.Begin);
                responseStream.Close();

                string str = Encoding.UTF8.GetString(stream.ToArray());
                foreach (string line in str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.ToUpper().Contains("DIR") || line.ToUpper().Contains("DR"))
                    {
                        int pos = line.LastIndexOf(" ");
                        string folder = line.Substring(pos).Trim();
                        if (folder == folderName)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error("FtpUtil.FolderExists 判断文件夹是否存在 错误");
                throw ex;
            }

            return false;
        }
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="ftpPath">ftp路径</param>
        /// <param name="ftpUserId">用户名</param>
        /// <param name="ftpPassword">密码</param>
        /// <param name="folderName">文件夹名称</param>
        public static void CreateFolder(string ftpPath, string ftpUserId, string ftpPassword, string folderName)
        {
            try
            {
                FtpWebRequest request = null;

                request = (FtpWebRequest)WebRequest.Create(new Uri(Path.Combine(ftpPath, folderName).Replace("\\", "/")));
                request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                request.Method = "MKD";
                ((FtpWebResponse)request.GetResponse()).Close();
            }
            catch (Exception ex)
            {
                LogUtil.Error("FtpUtil.CreateFolder 创建文件夹 错误");
                throw ex;
            }
        }
        #endregion

        #region 文件是否存在
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="ftpPath">ftp路径</param>
        /// <param name="ftpUserId">用户名</param>
        /// <param name="ftpPassword">密码</param>
        /// <param name="relativeFilePath">文件相对路径</param>
        public static bool FileExists(string ftpPath, string ftpUserId, string ftpPassword, string relativeFilePath)
        {
            try
            {
                FtpWebRequest request = null;

                string folderName = Path.GetDirectoryName(relativeFilePath);
                string fileName = Path.GetFileName(relativeFilePath);
                request = (FtpWebRequest)WebRequest.Create(new Uri(Path.Combine(ftpPath, folderName).Replace("\\", "/")));
                request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                request.Method = "LIST";
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                MemoryStream stream = new MemoryStream();
                byte[] bArr = new byte[1024 * 1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                stream.Seek(0, SeekOrigin.Begin);
                responseStream.Close();

                string str = Encoding.UTF8.GetString(stream.ToArray());
                foreach (string line in str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!line.ToUpper().Contains("DIR") && !line.ToUpper().Contains("DR"))
                    {
                        int pos = line.LastIndexOf(" ");
                        string strFileName = line.Substring(pos).Trim();
                        if (strFileName == fileName)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error("FtpUtil.FileExists 判断文件是否存在 错误");
                throw ex;
            }

            return false;
        }
        #endregion

        #region 下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="ftpPath">ftp路径</param>
        /// <param name="ftpUserId">用户名</param>
        /// <param name="ftpPassword">密码</param>
        /// <param name="relativeFilePath">文件相对路径</param>
        public static MemoryStream DownloadFile(string ftpPath, string ftpUserId, string ftpPassword, string relativeFilePath)
        {
            try
            {
                FtpWebRequest request = null;

                LogTimeUtil log = new LogTimeUtil();
                request = (FtpWebRequest)WebRequest.Create(new Uri(Path.Combine(ftpPath, relativeFilePath).Replace("\\", "/")));
                request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                request.Method = "RETR";
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                MemoryStream stream = new MemoryStream();
                byte[] bArr = new byte[1024 * 1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                stream.Seek(0, SeekOrigin.Begin);
                responseStream.Close();

                log.LogTime("FtpUtil.DownloadFile 下载 filePath=" + relativeFilePath);
                return stream;
            }
            catch (Exception ex)
            {
                LogUtil.Error("FtpUtil.DownloadFile 下载文件 错误");
                throw ex;
            }
        }
        #endregion

        #region 异步下载文件
        /// <summary>
        /// 异步下载文件
        /// </summary>
        /// <param name="ftpPath">ftp路径</param>
        /// <param name="ftpUserId">用户名</param>
        /// <param name="ftpPassword">密码</param>
        /// <param name="relativeFilePath">文件相对路径</param>
        public static async Task<MemoryStream> DownloadFileAsync(string ftpPath, string ftpUserId, string ftpPassword, string relativeFilePath)
        {
            try
            {
                FtpWebRequest request = null;

                LogTimeUtil log = new LogTimeUtil();
                request = (FtpWebRequest)WebRequest.Create(new Uri(Path.Combine(ftpPath, relativeFilePath).Replace("\\", "/")));
                request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                request.Method = "RETR";
                FtpWebResponse response = (FtpWebResponse)(await request.GetResponseAsync());
                Stream responseStream = response.GetResponseStream();
                MemoryStream stream = new MemoryStream();
                byte[] bArr = new byte[1024 * 1024];
                int size = await responseStream.ReadAsync(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = await responseStream.ReadAsync(bArr, 0, (int)bArr.Length);
                }
                stream.Seek(0, SeekOrigin.Begin);
                responseStream.Close();

                log.LogTime("FtpUtil.DownloadFileAsync 下载 filePath=" + relativeFilePath);
                return stream;
            }
            catch (Exception ex)
            {
                LogUtil.Error("FtpUtil.DownloadFileAsync 异步下载文件 错误");
                throw ex;
            }
        }
        #endregion

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ftpPath">ftp路径</param>
        /// <param name="ftpUserId">用户名</param>
        /// <param name="ftpPassword">密码</param>
        /// <param name="relativeFilePath">文件相对路径</param>
        /// <param name="bArr">文件内容</param>
        public static void UploadFile(string ftpPath, string ftpUserId, string ftpPassword, string relativeFilePath, byte[] bArr)
        {
            try
            {
                FtpWebRequest request = null;

                LogTimeUtil log = new LogTimeUtil();
                request = (FtpWebRequest)WebRequest.Create(new Uri(Path.Combine(ftpPath, relativeFilePath).Replace("\\", "/")));
                request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                request.Method = "STOR";
                Stream postStream = request.GetRequestStream();
                int pageSize = 1024 * 1024;
                int index = 0;
                while (index < bArr.Length)
                {
                    if (bArr.Length - index > pageSize)
                    {
                        postStream.Write(bArr, index, pageSize);
                        index += pageSize;
                    }
                    else
                    {
                        postStream.Write(bArr, index, bArr.Length - index);
                        index = index + (bArr.Length - index);
                    }
                }
                postStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
                string result = sr.ReadToEnd();
                responseStream.Close();
                log.LogTime("FtpUtil.UploadFile 上传 filePath=" + relativeFilePath);
            }
            catch (Exception ex)
            {
                LogUtil.Error("FtpUtil.UploadFile 上传文件 错误");
                throw ex;
            }
        }
        #endregion

        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="ftpPath">ftp路径</param>
        /// <param name="ftpUserId">用户名</param>
        /// <param name="ftpPassword">密码</param>
        /// <param name="relativeFilePath">文件相对路径</param>
        public static void DeleteFile(string ftpPath, string ftpUserId, string ftpPassword, string relativeFilePath)
        {
            try
            {
                FtpWebRequest request = null;

                request = (FtpWebRequest)WebRequest.Create(new Uri(Path.Combine(ftpPath, relativeFilePath).Replace("\\", "/")));
                request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                request.Method = "DELE";
                ((FtpWebResponse)request.GetResponse()).Close();
            }
            catch (Exception ex)
            {
                LogUtil.Error("FtpUtil.DeleteFile 删除文件 错误");
                throw ex;
            }
        }
        #endregion

    }
}
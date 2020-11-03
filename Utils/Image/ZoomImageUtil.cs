using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroStation.Common
{
    /// <summary>
    /// 图片缩放
    /// </summary>
    public class ZoomImageUtil
    {
        #region 图片缩放
        /// <summary>
        /// 图片缩放
        /// </summary>
        /// <param name="bArr">图片字节流</param>
        /// <param name="width">目标宽度，若为0，表示宽度按比例缩放</param>
        /// <param name="height">目标长度，若为0，表示长度按比例缩放</param>
        public static byte[] GetThumbnail(byte[] bArr, int width, int height)
        {
            if (bArr == null) return null;
            MemoryStream ms = new MemoryStream(bArr);
            Bitmap bmp = (Bitmap)Image.FromStream(ms);
            ms.Close();

            bmp = GetThumbnail(bmp, width, height);

            ImageCodecInfo imageCodecInfo = GetEncoder(ImageFormat.Jpeg);
            EncoderParameters encoderParameters = new EncoderParameters(1);
            EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 75L);
            encoderParameters.Param[0] = encoderParameter;

            ms = new MemoryStream();
            bmp.Save(ms, imageCodecInfo, encoderParameters);
            byte[] result = ms.ToArray();
            ms.Close();
            bmp.Dispose();

            return result;
        }
        #endregion

        #region 图片缩放
        /// <summary>
        /// 图片缩放
        /// </summary>
        /// <param name="bmp">图片</param>
        /// <param name="width">目标宽度，若为0，表示宽度按比例缩放</param>
        /// <param name="height">目标长度，若为0，表示长度按比例缩放</param>
        private static Bitmap GetThumbnail(Bitmap bmp, int width, int height)
        {
            if (width == 0 && height == 0)
            {
                width = bmp.Width;
                height = bmp.Height;
            }
            else
            {
                if (width == 0)
                {
                    width = height * bmp.Width / bmp.Height;
                }
                if (height == 0)
                {
                    height = width * bmp.Height / bmp.Width;
                }
            }

            Image imgSource = bmp;
            Bitmap outBmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量     
            g.CompositingQuality = CompositingQuality.Default;
            g.SmoothingMode = SmoothingMode.Default;
            g.InterpolationMode = InterpolationMode.Default;
            g.DrawImage(imgSource, new Rectangle(0, 0, width, height + 1), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            imgSource.Dispose();
            bmp.Dispose();
            return outBmp;
        }
        #endregion

        #region 椭圆形缩放
        /// <summary>
        /// 椭圆形缩放
        /// </summary>
        /// <param name="bArr">图片字节流</param>
        /// <param name="width">目标宽度，若为0，表示宽度按比例缩放</param>
        /// <param name="height">目标长度，若为0，表示长度按比例缩放</param>
        public static byte[] GetEllipseThumbnail(byte[] bArr, int width, int height)
        {
            if (bArr == null) return null;
            MemoryStream ms = new MemoryStream(bArr);
            Bitmap bmp = (Bitmap)Image.FromStream(ms);

            Bitmap newBmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(newBmp))
            {
                using (TextureBrush br = new TextureBrush(bmp))
                {
                    br.ScaleTransform(width / (float)bmp.Width, height / (float)bmp.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, new Size(width, height)));
                }
            }
            MemoryStream newMs = new MemoryStream();
            newBmp.Save(newMs, System.Drawing.Imaging.ImageFormat.Png);
            byte[] result = newMs.ToArray();

            bmp.Dispose();
            newBmp.Dispose();
            ms.Close();
            newMs.Dispose();

            return result;
        }
        #endregion

        #region 方形裁剪
        /// <summary>
        /// 方形裁剪
        /// </summary>
        /// <param name="bArr">图片字节流</param>
        /// <param name="left">左上角横坐标比例</param>
        /// <param name="top">左上角纵坐标比例</param>
        /// <param name="right">右下角横坐标比例</param>
        /// <param name="bottom">右下角纵坐标比例</param>
        public static byte[] CutImage(byte[] bArr, double left, double top, double right, double bottom)
        {
            if (bArr == null) return null;
            MemoryStream ms = new MemoryStream(bArr);
            Bitmap bmp = (Bitmap)Image.FromStream(ms);

            int width = (int)((right - left) * bmp.Width);
            int height = (int)((bottom - top) * bmp.Height);

            Bitmap newBmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(newBmp))
            {
                using (TextureBrush br = new TextureBrush(bmp))
                {
                    Point p = new Point((int)(left * bmp.Width), (int)(top * bmp.Height));
                    g.DrawImage(bmp, new Rectangle(0, 0, width, height), new Rectangle(p.X, p.Y, width, height), GraphicsUnit.Pixel);
                }
            }
            MemoryStream newMs = new MemoryStream();
            newBmp.Save(newMs, System.Drawing.Imaging.ImageFormat.Png);
            byte[] result = newMs.ToArray();

            bmp.Dispose();
            newBmp.Dispose();
            ms.Close();
            newMs.Dispose();

            return result;
        }
        #endregion

        #region GetEncoder
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        #endregion

    }
}

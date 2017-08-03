//bibaoke.com

using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using BetterImageProcessorQuantization;
using Less.Text;
using Less.Network;
using System.Runtime.InteropServices;

namespace Less.Image
{
    /// <summary>
    /// Image 扩展方法
    /// </summary>
    public static class ImageExtensions
    {
        private static OctreeQuantizer Quantizer
        {
            get;
            set;
        }

        static ImageExtensions()
        {
            ImageExtensions.Quantizer = new OctreeQuantizer(255, 8);
        }

        /// <summary>
        /// 是否包括透明像素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <exception cref="Exception">操作失败</exception>
        public static bool HasTransparentPixel(this System.Drawing.Image i)
        {
            using (Bitmap bitmap = new Bitmap(i))
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        if (bitmap.GetPixel(x, y).A < 255)
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 获取图片的 mime type
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="InvalidOperationException">不支持的图像格式</exception>
        public static MimeType GetMimeType(this System.Drawing.Image i)
        {
            return i.RawFormat.ToMimeType();
        }

        /// <summary>
        /// 裁剪
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns>返回裁剪后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Crop(this System.Drawing.Image i, int width, int height)
        {
            return i.Crop(width, height, InterpolationMode.Bilinear);
        }

        /// <summary>
        /// 裁剪
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="interpolationMode"></param>
        /// <returns>返回裁剪后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Crop(this System.Drawing.Image i, int width, int height, InterpolationMode interpolationMode)
        {
            return i.Resize(width, height, ImageExtensions.GetMode(i.Width, i.Height, width, height, true), interpolationMode);
        }

        /// <summary>
        /// 根据最大宽度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="maxWidth">最大宽度</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">最大宽度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeMaxW(this System.Drawing.Image i, int maxWidth)
        {
            if (i.Width > maxWidth)
                return i.ResizeW(maxWidth, InterpolationMode.Bilinear);
            else
                return (System.Drawing.Image)i.Clone();
        }

        /// <summary>
        /// 根据宽度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeW(this System.Drawing.Image i, int width)
        {
            return i.ResizeW(width, InterpolationMode.Bilinear);
        }

        /// <summary>
        /// 根据宽度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="interpolationMode">插值算法</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeW(this System.Drawing.Image i, int width, InterpolationMode interpolationMode)
        {
            return i.ResizeW(width, Color.Empty, interpolationMode);
        }

        /// <summary>
        /// 根据宽度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="background">背景色</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeW(this System.Drawing.Image i, int width, Color background)
        {
            return i.ResizeW(width, background, InterpolationMode.Bilinear);
        }

        /// <summary>
        /// 根据宽度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="background">背景色</param>
        /// <param name="interpolationMode">插值算法</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeW(this System.Drawing.Image i, int width, Color background, InterpolationMode interpolationMode)
        {
            return i.Resize(width, ((float)width / i.Width * i.Height).ToInt(), background, interpolationMode);
        }

        /// <summary>
        /// 根据高度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="height">高度</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeH(this System.Drawing.Image i, int height)
        {
            return i.ResizeH(height, InterpolationMode.Bilinear);
        }

        /// <summary>
        /// 根据高度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="height">高度</param>
        /// <param name="interpolationMode">插值算法</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeH(this System.Drawing.Image i, int height, InterpolationMode interpolationMode)
        {
            return i.ResizeH(height, Color.Empty, interpolationMode);
        }

        /// <summary>
        /// 根据高度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="height">高度</param>
        /// <param name="background">背景色</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeH(this System.Drawing.Image i, int height, Color background)
        {
            return i.ResizeH(height, background, InterpolationMode.Bilinear);
        }

        /// <summary>
        /// 根据高度调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="height">高度</param>
        /// <param name="background">背景色</param>
        /// <param name="interpolationMode">插值算法</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image ResizeH(this System.Drawing.Image i, int height, Color background, InterpolationMode interpolationMode)
        {
            return i.Resize(((float)height / i.Height * i.Width).ToInt(), height, background, interpolationMode);
        }

        /// <summary>
        /// 调整图片尺寸 不裁剪图片 只填充空白
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Resize(this System.Drawing.Image i, int width, int height)
        {
            return i.Resize(width, height, InterpolationMode.Bilinear);
        }

        /// <summary>
        /// 调整图片尺寸 不裁剪图片 只填充空白
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="interpolationMode">插值算法</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Resize(this System.Drawing.Image i, int width, int height, InterpolationMode interpolationMode)
        {
            return i.Resize(width, height, Color.Empty, interpolationMode);
        }

        /// <summary>
        /// 调整图片尺寸 不裁剪图片 只填充空白
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="background">背景色</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Resize(this System.Drawing.Image i, int width, int height, Color background)
        {
            return i.Resize(width, height, background, InterpolationMode.Bilinear);
        }

        /// <summary>
        /// 调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="mode">缩放模式</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Resize(this System.Drawing.Image i, int width, int height, ResizeMode mode)
        {
            return i.Resize(width, height, Color.Empty, mode);
        }

        /// <summary>
        /// 调整图片尺寸 不裁剪图片 只填充空白
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="background">背景色</param>
        /// <param name="interpolationMode">插值算法</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Resize(this System.Drawing.Image i, int width, int height, Color background, InterpolationMode interpolationMode)
        {
            return i.Resize(width, height, background, ImageExtensions.GetMode(i.Width, i.Height, width, height, false), interpolationMode);
        }

        /// <summary>
        /// 调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="mode">缩放模式</param>
        /// <param name="interpolationMode">插值算法</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Resize(this System.Drawing.Image i, int width, int height, ResizeMode mode, InterpolationMode interpolationMode)
        {
            return i.Resize(width, height, Color.Empty, mode, interpolationMode);
        }

        /// <summary>
        /// 调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="background">背景色</param>
        /// <param name="mode">缩放模式</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Resize(this System.Drawing.Image i, int width, int height, Color background, ResizeMode mode)
        {
            return i.Resize(width, height, background, mode, InterpolationMode.Bilinear);
        }

        /// <summary>
        /// 调整图片尺寸
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="background">背景色</param>
        /// <param name="mode">缩放模式</param>
        /// <param name="interpolationMode">插值算法</param>
        /// <returns>返回调整后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">新的图片尺寸的宽度和高度必须大于零</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Resize(
            this System.Drawing.Image i, int width, int height, Color background, ResizeMode mode, InterpolationMode interpolationMode)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException("新的图片尺寸的宽和高必须大于零");

            //如果原图片和新图片尺寸一致，克隆对象返回
            if (i.Width == width && i.Height == height)
                return (System.Drawing.Image)i.Clone();

            if (((float)i.Width / i.Height == (float)width / height))
            {
                //如果原图片和新图片的比例相同，只缩放
                return i.Zoom(width, height, interpolationMode);
            }
            else
            {
                //计算新尺寸
                Size size = ImageExtensions.CalculateSize(i.Width, i.Height, width, height, mode);

                //如果原图片和新图片的比例不同，先裁剪或填充后，再缩放
                using (System.Drawing.Image cropOrFill = i.CropOrFill(size.Width, size.Height, background, interpolationMode))
                {
                    return cropOrFill.Zoom(width, height, interpolationMode);
                }
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="i"></param>
        /// <param name="format">图像格式</param>
        /// <param name="value">图片质量(1-100)</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="InvalidOperationException">不支持的 ImageFormat</exception>
        /// <exception cref="ExternalException">该图像以错误的图像格式保存</exception>
        public static MemoryStream Save(this System.Drawing.Image i, ImageFormat format, int value)
        {
            MemoryStream stream = new MemoryStream();

            if (i.RawFormat == ImageFormat.Gif)
            {
                using (System.Drawing.Image gif = ImageExtensions.Quantizer.Quantize(i))
                {
                    try
                    {
                        gif.Save(stream, format.ToImageCodecInfo(), value.ToEncoderParameters());
                    }
                    catch (ArgumentNullException)
                    {
                        throw new InvalidOperationException("不支持的 ImageFormat");
                    }
                }
            }
            else
            {
                try
                {
                    i.Save(stream, format.ToImageCodecInfo(), value.ToEncoderParameters());
                }
                catch (ArgumentNullException)
                {
                    throw new InvalidOperationException("不支持的 ImageFormat");
                }
            }

            //重置数据流位置
            stream.Position = 0;

            return stream;
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="i"></param>
        /// <param name="path">保存路径</param>
        /// <param name="value">图片质量(1-100)</param>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="ArgumentException">无效的路径</exception>
        /// <exception cref="ExternalException">该图像被保存到创建该图像的文件</exception>
        public static void Save(this System.Drawing.Image i, string path, int value)
        {
            if (i.RawFormat == ImageFormat.Gif)
            {
                using (System.Drawing.Image gif = ImageExtensions.Quantizer.Quantize(i))
                {
                    gif.Save(path, path.ToImageCodecInfo(), value.ToEncoderParameters());
                }
            }
            else
            {
                i.Save(path, path.ToImageCodecInfo(), value.ToEncoderParameters());
            }
        }

        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="mode">插值算法</param>
        /// <returns>返回缩放后的图片</returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="Exception">操作失败</exception>
        public static System.Drawing.Image Zoom(this System.Drawing.Image i, int width, int height, InterpolationMode mode)
        {
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = mode;

                g.Clear(Color.Empty);

                g.DrawImage(i, new Rectangle(0, 0, width, height), new Rectangle(0, 0, i.Width, i.Height), GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        /// <summary>
        /// 获取缩放模式
        /// </summary>
        /// <param name="oldWidth"></param>
        /// <param name="oldHeight"></param>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        /// <param name="crop">是否裁剪图片</param>
        /// <returns></returns>
        private static ResizeMode GetMode(int oldWidth, int oldHeight, int newWidth, int newHeight, bool crop)
        {
            float oldScale = (float)oldWidth / oldHeight;

            float newScale = (float)newWidth / newHeight;

            if (crop)
                return oldScale < newScale ? ResizeMode.WidthFirst : ResizeMode.HeightFirst;
            else
                return oldScale > newScale ? ResizeMode.WidthFirst : ResizeMode.HeightFirst;
        }

        /// <summary>
        /// 裁剪或填充
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="background">背景色</param>
        /// <param name="mode">插值算法</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Image 不能为 null</exception>
        /// <exception cref="Exception">操作失败</exception>
        private static System.Drawing.Image CropOrFill(
            this System.Drawing.Image image, int width, int height, Color background, InterpolationMode mode)
        {
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = mode;

                int srcX = ImageExtensions.GetSrc(image.Width, width);
                int srcY = ImageExtensions.GetSrc(image.Height, height);

                g.Clear(background);

                g.DrawImage(image, new Rectangle(0, 0, width, height), srcX, srcY, width, height, GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        /// <summary>
        /// 根据原边长和新边长计算绘制的起始点坐标
        /// </summary>
        /// <param name="oldLength"></param>
        /// <param name="newLength"></param>
        /// <returns></returns>
        private static int GetSrc(int oldLength, int newLength)
        {
            return ((float)(oldLength - newLength) / 2).ToInt();
        }

        /// <summary>
        /// 计算新的尺寸
        /// </summary>
        /// <param name="oldWidth">原宽</param>
        /// <param name="oldHeight">原高</param>
        /// <param name="newWidth">新宽</param>
        /// <param name="newHeight">新高</param>
        /// <param name="mode">缩放模式</param>
        /// <returns></returns>
        private static Size CalculateSize(int oldWidth, int oldHeight, int newWidth, int newHeight, ResizeMode mode)
        {
            Size size = new Size();

            //新宽高比
            float scale = (float)newWidth / newHeight;

            if (mode == ResizeMode.WidthFirst)
            {
                //等宽，计算高
                size.Width = oldWidth;
                size.Height = (oldWidth / scale).ToInt();
            }
            else
            {
                //等高，计算宽
                size.Height = oldHeight;
                size.Width = (oldHeight * scale).ToInt();
            }

            return size;
        }

        /// <summary>
        /// 根据质量参数获取编码器参数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static EncoderParameters ToEncoderParameters(this int value)
        {
            EncoderParameters encoderParameters = new EncoderParameters();

            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, value);

            return encoderParameters;
        }

        /// <summary>
        /// 根据保存路径获取系统的编码解码器信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">无效的路径</exception>
        private static ImageCodecInfo ToImageCodecInfo(this string path)
        {
            string ext = Path.GetExtension(path).ToUpper();

            if (ext.IsNotEmpty())
            {
                ImageCodecInfo[] infos = ImageCodecInfo.GetImageEncoders();

                foreach (ImageCodecInfo info in infos)
                {
                    if (info.FilenameExtension.Split(';').Contains("*".Combine(ext)))
                        return info;
                }
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// 根据图片格式获取系统的编码解码器信息
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ImageFormat 不能为 null</exception>
        /// <exception cref="InvalidOperationException">不支持的 ImageFormat</exception>
        private static ImageCodecInfo ToImageCodecInfo(this ImageFormat format)
        {
            ImageCodecInfo[] infos = ImageCodecInfo.GetImageEncoders();

            MimeType mimeType = format.ToMimeType();

            foreach (ImageCodecInfo info in infos)
            {
                if (info.MimeType == mimeType)
                    return info;
            }

            throw new InvalidOperationException("不支持的 ImageFormat");
        }
    }
}

//bibaoke.com

using System.Drawing.Imaging;
using Less.Network;
using System.Collections.Generic;

namespace Less.Image
{
    /// <summary>
    /// ImageFormat 扩展方法
    /// </summary>
    public static class ImageFormatExtensions
    {
        private static Dictionary<ImageFormat, MimeType> Map
        {
            get;
            set;
        }

        static ImageFormatExtensions()
        {
            ImageFormatExtensions.Map = new Dictionary<ImageFormat, MimeType>();

            ImageFormatExtensions.Map.Add(ImageFormat.Jpeg, MimeType.Image_Jpeg);
            ImageFormatExtensions.Map.Add(ImageFormat.Png, MimeType.Image_Png);
            ImageFormatExtensions.Map.Add(ImageFormat.Gif, MimeType.Image_Gif);
            ImageFormatExtensions.Map.Add(ImageFormat.Icon, MimeType.Image_Icon);
            ImageFormatExtensions.Map.Add(ImageFormat.Bmp, MimeType.Image_Bmp);
            ImageFormatExtensions.Map.Add(ImageFormat.Tiff, MimeType.Image_Tiff);
            ImageFormatExtensions.Map.Add(ImageFormat.Exif, MimeType.Image_Exif);
            ImageFormatExtensions.Map.Add(ImageFormat.Emf, MimeType.Image_Emf);
            ImageFormatExtensions.Map.Add(ImageFormat.Wmf, MimeType.Image_Wmf);
            ImageFormatExtensions.Map.Add(ImageFormat.MemoryBmp, MimeType.Image_MemoryBmp);
        }

        /// <summary>
        /// 转换为对应的 mime type
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static MimeType ToMimeType(this ImageFormat i)
        {
            return ImageFormatExtensions.Map[i];
        }
    }
}

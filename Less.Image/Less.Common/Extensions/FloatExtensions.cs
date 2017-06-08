//bibaoke.com

using System;

namespace Less
{
    /// <summary>
    /// float 扩展方法
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// 向下取整
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static int Floor(this float f)
        {
            return Math.Floor(f).ToInt();
        }

        /// <summary>
        /// 向上取整
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static int Ceiling(this float f)
        {
            return Math.Ceiling(f).ToInt();
        }

        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static int ToInt(this float f)
        {
            return Convert.ToInt32(f);
        }
    }
}

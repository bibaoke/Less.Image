using Less.Image;
using Less.Windows;
using System.Drawing;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Application.SetupDir.CombinePath("yangmi.jpg");

            Image origin = Image.FromFile(file);

            //test1
            Image test1 = origin.Resize(300, 200);

            test1.Save(Application.SetupDir.CombinePath("yangmi_300_200.jpg"), 90);

            //test2
            Image test2 = origin.Resize(300, 200, ResizeMode.WidthFirst);

            test2.Save(Application.SetupDir.CombinePath("yangmi_300_200_WidthFirst.jpg"), 90);

            //test3
            Image test3 = origin.Crop(180, 180);

            test3.Save(Application.SetupDir.CombinePath("yangmi_180_180.jpg"), 90);

            //test4
            Image test4 = origin.ResizeW(300);

            test4.Save(Application.SetupDir.CombinePath("yangmi_W300.jpg"), 90);

            //test5
            Image test5 = origin.ResizeH(200);

            test5.Save(Application.SetupDir.CombinePath("yangmi_H200.jpg"), 90);

            //
            StringFormat format = new StringFormat();

            format.Alignment = StringAlignment.Center;

            "Q".ToImage(
                32, 32, Color.White, new Font("Arial", 21), Brushes.Black, new RectangleF(0, 0, 32, 32), format).Save(
                Application.SetupDir.CombinePath("Q.jpg"));

            "天".ToImage(
                32, 32, Color.White, new Font("微软雅黑", 17), Brushes.Black, new RectangleF(0, 0, 32, 32), format).Save(
                Application.SetupDir.CombinePath("天.jpg"));
        }
    }
}

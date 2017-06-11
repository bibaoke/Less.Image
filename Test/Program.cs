using Less.Image;
using Less.Windows;
using Less.Text;
using System.Drawing;
using System.Drawing.Imaging;

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
            Image test3 = origin.ResizeW(300);

            test3.Save(Application.SetupDir.CombinePath("yangmi_W300.jpg"), 90);

            //test4
            Image test4 = origin.ResizeH(200);

            test4.Save(Application.SetupDir.CombinePath("yangmi_H200.jpg"), 90);
        }
    }
}

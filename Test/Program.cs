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
            Image test1 = origin.Resize(600, 400);

            test1.Save(Application.SetupDir.CombinePath("yangmi_600_400.jpg"), 90);

            //test2
            Image test2 = origin.Resize(600, 400, ResizeMode.WidthFirst);

            test2.Save(Application.SetupDir.CombinePath("yangmi_600_400_WidthFirst.jpg"), 90);

            //test3
            Image test3 = origin.ResizeW(600);

            test3.Save(Application.SetupDir.CombinePath("yangmi_W600.jpg"), 90);

            //test4
            Image test4 = origin.ResizeW(400);

            test4.Save(Application.SetupDir.CombinePath("yangmi_H400.jpg"), 90);
        }
    }
}

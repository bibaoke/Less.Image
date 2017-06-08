using Less.Image;
using Less.Windows;
using Less.Text;
using System.Drawing;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Application.SetupDir.CombinePath("yangmi.jpg");

            Image origin = Image.FromFile(file);

            Image test1 = origin.Resize(600, 400, Color.Black);

            test1.Save(Application.SetupDir.CombinePath("yangmi_600_400.jpg"));
        }
    }
}

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
            Image test1 = Image.FromFile(Application.SetupDir.CombinePath("yangmi.jpg")).Resize(1024, 768);

            test1.Save(Application.SetupDir.CombinePath("yangmi_1024_768.jpg"));
        }
    }
}

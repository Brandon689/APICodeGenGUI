using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APICodeGen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string dir = "C:\\2024\\1\\WooCommerceAPI\\WooCommerceAPI\\Services\\Foundations";
            string path = @"C:\2024\1\CodeGen\ProductsClient.cs";
            string pokemon = "Breloom";

            string x = SimpleReplace(Clipboard.GetText(), pokemon);
            Clipboard.SetText(x);
            
            //foreach (var folder in Directory.GetDirectories(dir))
            //{
            //    Directory.CreateDirectory(SimpleReplace(folder, pokemon));
            //    foreach (var file in Directory.GetFiles(folder))
            //    {
            //        File.WriteAllText(
            //            SimpleReplace(
            //                file,
            //                pokemon),
            //            SimpleReplace(
            //                File.ReadAllText(file),
            //                pokemon));
            //    }
            //    //2
            //    foreach (var folder2 in Directory.GetDirectories(dir))
            //    {
            //        Directory.CreateDirectory(SimpleReplace(folder2, pokemon));
            //        foreach (var file in Directory.GetFiles(folder2))
            //        {
            //            File.WriteAllText(
            //                SimpleReplace(
            //                    file,
            //                    pokemon),
            //                SimpleReplace(
            //                    File.ReadAllText(file),
            //                    pokemon));
            //        }
            //    }
            //}
            //string originalCode = File.ReadAllText(path);
            //File.WriteAllText(SimpleReplace(path, pokemon), SimpleReplace(originalCode, pokemon));
        }
        private string SimpleReplace(string input, string newTerm)
        {
            return input.Replace("Products", newTerm, StringComparison.Ordinal)
            .Replace("products", newTerm, StringComparison.Ordinal)
            .Replace("Product", newTerm, StringComparison.Ordinal)
            .Replace("product", newTerm, StringComparison.Ordinal);
        }
    }
}


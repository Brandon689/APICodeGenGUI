using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace APICodeGen
{
    public partial class MainWindow : Window
    {
        string pokemon = "Breloom";

        public MainWindow()
        {
            InitializeComponent();

            string dir = "C:\\2024\\1\\WooCommerceAPI\\WooCommerceAPI\\Services\\Foundations";
            string path = @"C:\2024\1\CodeGen\ProductsClient.cs";
 

           
        }
        private string SimpleReplace(string input, string newTerm)
        {
            return input.Replace("Products", newTerm, StringComparison.Ordinal)
            .Replace("products", newTerm, StringComparison.Ordinal)
            .Replace("Product", newTerm, StringComparison.Ordinal)
            .Replace("product", newTerm, StringComparison.Ordinal);
        }

        private void text_clipboard_replace_click(object sender, RoutedEventArgs e)
        {
            string x = SimpleReplace(Clipboard.GetText(), pokemon);
            Clipboard.SetText(x);
        }

        private void filepath_clipboard_replace_click(object sender, RoutedEventArgs e)
        {
            string path = Clipboard.GetText();
            var cs = path.Substring(path.Length - 3, 3);
            if (cs == ".cs")
            {
                string originalCode = File.ReadAllText(path);
                string outdir = SimpleReplace(path, pokemon);
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outdir));
                File.WriteAllText(outdir, SimpleReplace(originalCode, pokemon));
            }
            else
            {

                foreach (var file in Directory.GetFiles(path))
                {
                    File.WriteAllText(
                        SimpleReplace(
                            file,
                            pokemon),
                        SimpleReplace(
                            File.ReadAllText(file),
                            pokemon));
                }
                foreach (var folder in Directory.GetDirectories(path))
                {
                    Directory.CreateDirectory(SimpleReplace(folder, pokemon));
                    foreach (var file in Directory.GetFiles(folder))
                    {
                        File.WriteAllText(
                            SimpleReplace(
                                file,
                                pokemon),
                            SimpleReplace(
                                File.ReadAllText(file),
                                pokemon));
                    }
                    //2
                    //foreach (var folder2 in Directory.GetDirectories(path))
                    //{
                    //    Directory.CreateDirectory(SimpleReplace(folder2, pokemon));
                    //    foreach (var file in Directory.GetFiles(folder2))
                    //    {
                    //        File.WriteAllText(
                    //            SimpleReplace(
                    //                file,
                    //                pokemon),
                    //            SimpleReplace(
                    //                File.ReadAllText(file),
                    //                pokemon));
                    //    }
                    //}
                }
            }
        }
    }
}


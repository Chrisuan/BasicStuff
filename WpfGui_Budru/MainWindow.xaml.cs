using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web.Script.Serialization;
using System.IO;

namespace WpfGui_Budru {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private string inputText;
        List<Product> allProducts = new List<Product>();
        private int page = 0;

        public MainWindow() {
            InitializeComponent();
            loadJSON();
        }

        CommonHelper helper = new CommonHelper("debug");

       
        public void nextPage() {
            if (allProducts.Count > page+1) {
                this.page++;
                this.DataContext = allProducts[page];
            }
        }

        public void previousPage() {
            if(this.page > 0) {
                this.page--;
                this.DataContext = allProducts[page];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            helper.openTargetFile(allProducts[page].AvailableString);
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e) {
            var textBox = sender as TextBox;
            this.inputText = textBox.Text;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            nextPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            previousPage();
        }
        private async void loadJSON() {
            StreamReader sr = new StreamReader(helper.getJSONFilePath());
            try {
                string JSONText = @"" + await sr.ReadToEndAsync() + "";
                
                
                Product vault = new JavaScriptSerializer().Deserialize<Product>(JSONText);
                foreach(var p in vault.Products) {
                    allProducts.Add(p);                    
                }
                this.DataContext = allProducts[page];


            } catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}

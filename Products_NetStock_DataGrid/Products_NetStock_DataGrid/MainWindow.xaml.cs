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

namespace Products_NetStock_DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntities db = null;
        public MainWindow()
        {
            InitializeComponent();
            db = new NorthwindEntities();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
           ProductGrid.ItemsSource  = db.Products.ToList();
        }
    }
}

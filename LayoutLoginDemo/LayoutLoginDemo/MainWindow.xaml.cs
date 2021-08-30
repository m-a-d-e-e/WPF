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

namespace LayoutLoginDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Counter { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Counter = 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(this.txtUname.Text=="Admin" && this.passboxPass.Password=="123")
            {
                Registration registration = new Registration();
                registration.ShowDialog();
            }
            else
            {
                Counter++;
                MessageBox.Show("Incorrect Username and password !!!");
                if (Counter == 3)
                {                  
                    this.Close();
                }
                
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

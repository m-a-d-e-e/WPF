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
using System.Windows.Shapes;
using System.IO;

namespace LayoutLoginDemo
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUname.Text))
            {
                MessageBox.Show("Please enter username !!!");
                return;
            }
            string uname = "Username = " + txtUname.Text;
            string pass = "Password = " + txtPass.Password;
            string addr = "Address = " + txtAdd.Text;
            string country = "Country = " + combxCountry.Text;
            string tel;
            if(this.chkTel.IsChecked==true)
            {
                tel = "Telephone = "  + txtTel.Text;
            }
            else
            {
                tel = "Telephone = No telephone";
            }
            string mob;
            if (chkMob.IsChecked == true)
            {
                mob = "Mobile = " + txtMobile.Text;
            }
            else
            {
                mob = "Mobile = No mobile";
            }
            string gen;
            if (radioFemale.IsChecked==true)
            {
                gen = "Gender = Female";
            }
            else
            {
                gen = "Gender = Male";
            }
            string status;
            if (radioMarried.IsChecked == true)
            {
                status = "Maritial status = Married";
            }
            else
            {
                status = "Maritial status = Single";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Qualification = ");
            foreach (object item in lstbxQual.SelectedItems)
            {
                ListBoxItem listBoxItem = (ListBoxItem)item;
                sb.Append(listBoxItem.Content);
                sb.Append(" ");
            }
            string qual = sb.ToString();

            string lines = uname + "\n" + pass + "\n" + addr + "\n" + country + "\n" + tel + "\n" + mob + "\n" + gen + "\n" + status + "\n" + qual;

            string path = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\Aug30 - Assignment\UserData\" + txtUname.Text + ".txt";


            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(lines);
            writer.Close();
            stream.Close();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {          
            rchtxt.Document.Blocks.Clear();
        }

        private void chkTel_Checked(object sender, RoutedEventArgs e)
        {
            txtTel.Visibility = Visibility.Visible;
        }

        private void chkTel_Unchecked(object sender, RoutedEventArgs e)
        {
            txtTel.Visibility = Visibility.Hidden;
        }

        private void chkMob_Checked(object sender, RoutedEventArgs e)
        {
            txtMobile.Visibility = Visibility.Visible;
        }

        private void chkMob_Unchecked(object sender, RoutedEventArgs e)
        {
            txtMobile.Visibility = Visibility.Hidden;
        }

        private void chkbxDisp_Checked(object sender, RoutedEventArgs e)
        {
            string[] files = Directory.GetFiles(@"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\Aug30 - Assignment\UserData\");
            foreach(string item in files)
            {
                lstFiles.Items.Add(item);
            }
            lstFiles.Visibility = Visibility.Visible;
        }

        private void chkbxDisp_Unchecked(object sender, RoutedEventArgs e)
        {
            lstFiles.Visibility = Visibility.Hidden;
        }

        private void lstFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string path = lstFiles.SelectedItem.ToString();            
            StreamReader reader = new StreamReader(path);
            string lines = reader.ReadToEnd();
            rchtxt.Document.Blocks.Clear();
            rchtxt.AppendText(lines);
            reader.Close();
        }
    }
}

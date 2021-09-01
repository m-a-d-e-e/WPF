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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ContinentCountriesStates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet ds;

        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString);
        }


        private void stckpanel1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString);
                string sql = "select * from continent";
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds, "continent");

                sql = "select * from country";
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(ds, "country");

                sql = "select * from state";
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(ds, "state");

                cmbContinent.ItemsSource = ds.Tables["continent"].DefaultView;
                cmbContinent.DisplayMemberPath = "CONTINENTNAME";
                cmbContinent.SelectedValuePath = "CONTINENTID";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmbContinent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataTable table = ds.Tables["country"];
                table.DefaultView.RowFilter = "CONTINENTID = " + cmbContinent.SelectedValue;
                cmbCountries.ItemsSource = table.DefaultView;
                cmbCountries.DisplayMemberPath = table.Columns["COUNTRYNAME"].ToString();
                cmbCountries.SelectedValuePath = table.Columns["COUNTRYID"].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataTable table = ds.Tables["state"];
                table.DefaultView.RowFilter = "COUNTRYID = '" + cmbCountries.SelectedValue + "'";
                cmbStates.ItemsSource = table.DefaultView;
                cmbStates.DisplayMemberPath = table.Columns["STATENAME"].ToString();
                cmbStates.SelectedValuePath = table.Columns["STATEID"].ToString();

                DataRow dr = ds.Tables["country"].Select("countryid='" + cmbCountries.SelectedValue + "'").FirstOrDefault();
                if (cmbCountries.SelectedItem != null)
                {
                    lblCountry_Capital.Content = dr["CAPITAL"].ToString();
                }
                else
                {
                    lblCountry_Capital.Content = "";
                }

                if (dr["FLAG"] != System.DBNull.Value)
                {
                    byte[] data = (byte[])(dr["flag"]);
                    MemoryStream ms = new MemoryStream(data);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = ms;
                    bi.EndInit();
                    flag1.Source = bi;
                    ms.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cmbStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbStates.SelectedItem != null)
                {
                    DataRow dr = ds.Tables["state"].Select("stateid=" + cmbStates.SelectedValue).FirstOrDefault();
                    lblState_Capital.Content = dr["STATECAPITAL"].ToString();
                }
                else
                {
                    lblState_Capital.Content = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }


}


    


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
        SqlCommand command;
        SqlDataReader reader;

        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString);
        }

        private void stckpanel1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "select * from continent";
                command = new SqlCommand(sql, connection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                string continent;
                while (reader.Read())
                {
                    continent = reader["continentname"].ToString();
                    cmbContinent.Items.Add(continent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void cmbContinent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbContinent.SelectedItem != null)
            {
                string selectedText = cmbContinent.SelectedItem.ToString();

                try
                {
                    string sql = "select * from country where continentid in (select continentid from continent where continentname = @text)";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("text", selectedText);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    reader = command.ExecuteReader();
                    string country;
                    while (reader.Read())
                    {
                        country = reader["countryname"].ToString();
                        cmbCountries.Items.Add(country);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void cmbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCountries.SelectedItem != null)
            {
                string selectedText = cmbCountries.SelectedItem.ToString();
                try
                {                   
                    string sql = "select * from State where countryid in (select countryid from country where countryname = @text)";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("text", selectedText);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    reader = command.ExecuteReader();
                    string state;
                    while (reader.Read())
                    {
                        state = reader["statename"].ToString();
                        cmbStates.Items.Add(state);
                    }
                    connection.Close();
                    
                    sql = "select * from Country where countryname = @text";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("text", selectedText);
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        lblCountry_Capital.Content = reader["capital"].ToString();
                        Stream stream = new MemoryStream((byte[])reader["flag"]);
                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = stream;
                        bi.EndInit();
                        flag1.Source = bi;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

        }

        private void cmbStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbStates.SelectedItem != null)
            {
                string selectedText = cmbStates.SelectedItem.ToString();
                try
                {
                    
                    string sql = "select * from State where statename = @text";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("text", selectedText);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    reader = command.ExecuteReader();
                    string state;
                    while (reader.Read())
                    {
                        state = reader["statecapital"].ToString();
                        lblState_Capital.Content = state;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}

    


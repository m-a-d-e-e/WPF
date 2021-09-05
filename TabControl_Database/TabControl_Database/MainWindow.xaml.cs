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

namespace TabControl_Database
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
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString);
            
        }

        private void tab1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> tablesList = new List<string>();

                string sql = "select name from sys.tables";
                command = new SqlCommand(sql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tablesList.Add(reader["name"].ToString());
                }

                trvwNorthwind.ItemsSource = tablesList;
                //TreeViewItem parentNode = new TreeViewItem();
                //parentNode.Header = "Northwind";
                //trvwNorthwind.Items.Add(parentNode);

                //foreach (string item in tablesList)
                //{
                //    TreeViewItem tblNode = new TreeViewItem();
                //    tblNode.Header = item;
                //    parentNode.Items.Add(tblNode);
                //    TreeViewItem dataNode = new TreeViewItem();
                //    dataNode.Header = "Data";
                //    tblNode.Items.Add(dataNode);
                //    TreeViewItem structureNode = new TreeViewItem();
                //    structureNode.Header = "Structure";               
                //    tblNode.Items.Add(structureNode);
                //}
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

        private void trvItemData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            TreeViewItem parent = item.Parent as TreeViewItem;
            string table = parent.Header.ToString();
            try
            {
                string sql = $"select * from {table}";
                command = new SqlCommand(sql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridTableData.DataContext = dataTable;
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

        private void trvItemStruct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            TreeViewItem parent = item.Parent as TreeViewItem;
            string table = parent.Header.ToString();
            try
            {
                string sql = $"select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{table}'";
                command = new SqlCommand(sql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridTableData.DataContext = dataTable;

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

       
        private void btnDynamicSql_Click(object sender, RoutedEventArgs e)
        {
            string tblName = txtTbl.Text;
            string col1 = txtCol1.Text;
            string col2 = txtCol2.Text;
            try
            {
                string sql = $"DECLARE @tab NVARCHAR(50), @col1 NVARCHAR(50),@col2 NVARCHAR(50), @st NVARCHAR(MAX); SET @tab = N'{tblName}'; SET @col1 = N'{col1}'; SET @col2 = N'{col2}'; SET @st = N'SELECT '+ @col1 +' , ' + @col2 +' FROM ' + @tab;EXEC sp_executesql @st; ";
                command = new SqlCommand(sql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridTab2Data.DataContext = dataTable;

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

        private void btnXmlToTbl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                command = new SqlCommand("PARSETABLETOXML", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter outParam = new SqlParameter();
                outParam.ParameterName = "@OUTPUTXML";
                outParam.SqlDbType = System.Data.SqlDbType.Xml;
                outParam.Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add(outParam);

                if (connection.State == ConnectionState.Closed)

                {
                    connection.Open();
                }

                command.ExecuteNonQuery();
                txtBlckTab3Data.DataContext = outParam.Value.ToString();
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

        private void btnTblToXml_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\Sept3 - Assignments\TabControl_Database\TabControl_Database\XMLemp.xml";

                string data = File.ReadAllText(filePath);

                command = new SqlCommand("PARSEXMLTOTABLE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@INPUTXML", data);
         
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridTab4Data.DataContext = dataTable;
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

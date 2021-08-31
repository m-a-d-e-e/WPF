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
using System.Configuration;
using DBLibrary;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseDML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmpDataStore dataStore;
        
        public MainWindow()
        {
            InitializeComponent();
            dataStore = new EmpDataStore(ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString);

        }

        private void Display()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString);
            string sql = "select * from emp";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "emp");
            EmpDataGrid.DataContext = ds.Tables["emp"];
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int empNo = Convert.ToInt32(txtEmpNo.Text);
                Employee employee = dataStore.GetEmpByNo(empNo);
                txtEmpName.Text = employee.EmpName;
                txtHireDate.Text = employee.HireDate.ToString();
                txtSalary.Text = employee.Salary.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error--->" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.EmpNo = Convert.ToInt32(txtEmpNo.Text);
                employee.EmpName = txtEmpName.Text;
                employee.HireDate = string.IsNullOrEmpty((txtHireDate.Text)) ? (DateTime?)null : Convert.ToDateTime(txtHireDate.Text);
                employee.Salary = string.IsNullOrEmpty((txtSalary.Text)) ? (decimal?)null : Convert.ToDecimal(txtSalary.Text);
                dataStore.AddEmp(employee);
                
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error--->" + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.EmpNo = Convert.ToInt32(txtEmpNo.Text);
                employee.EmpName = txtEmpName.Text;
                employee.HireDate = string.IsNullOrEmpty(txtHireDate.Text) ? (DateTime?)null : Convert.ToDateTime(txtHireDate.Text);
                employee.Salary = string.IsNullOrEmpty(txtSalary.Text) ? (decimal?)null : Convert.ToDecimal(txtSalary.Text);
                dataStore.UpdateEmp(employee);
                Display();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error--->" + ex.Message);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult boxResult = MessageBox.Show("Are you sure you want delete employee data?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (boxResult == MessageBoxResult.Yes)
            {
                try
                {
                    int empNo = Convert.ToInt32(txtEmpNo.Text);
                    dataStore.DeleteEmp(empNo);
                    txtEmpName.Clear();
                    txtEmpNo.Clear();
                    txtHireDate.Clear();
                    txtSalary.Clear();
                    Display();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error--->" + ex.Message);
                }
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtEmpName.Clear();
            txtEmpNo.Clear();
            txtHireDate.Clear();
            txtSalary.Clear();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }
    }
}

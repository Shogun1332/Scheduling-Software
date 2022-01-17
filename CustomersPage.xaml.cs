using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace C969___Scheduling_Software
{
    /// <summary>
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Window
    {
        public CustomersPage()
        {
            InitializeComponent();
            mySQLDB mySQLDB = new mySQLDB();
            List<Customer> customersList = mySQLDB.SelectAllCustomers();

            CollectionViewSource CustomerCollectionViewSource;
            CustomerCollectionViewSource = (CollectionViewSource)(FindResource("CustomerCollectionViewSource"));
            CustomerCollectionViewSource.Source = customersList;
        }

        private void apptButton_Click(object sender, RoutedEventArgs e)
        {
            new AppointmentsPage().Show();
            this.Close();
        }

        private void customerButton_Click(object sender, RoutedEventArgs e)
        {
            new CustomersPage().Show();
            this.Close();
        }

        private void calendarButton_Click(object sender, RoutedEventArgs e)
        {
            new CalendarPage().Show();
            this.Close();
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            new HomePage().Show();
            this.Close();
        }
        private void reportsButton_Click(object sender, RoutedEventArgs e)
        {
            new ReportsPage().Show();
            this.Close();
        }

        private void customerAddButton_Click(object sender, RoutedEventArgs e)
        {
            new AddCustomer().Show();
            this.Close();
        }

        private void customerUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)customerDataGrid.SelectedItem;
            new UpdateCustomer(customer).Show();
            this.Close();
        }

        private void customerDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var warning = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the selected Customer and any appointments linked to this Customer? This is permanent!", "Dom's Cool Scheduler - Confirm Delete?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (warning == System.Windows.Forms.DialogResult.OK)
            {
                mySQLDB mySQLDB = new mySQLDB();
                Customer cust = (Customer)customerDataGrid.SelectedItem;
                mySQLDB.DeleteCustomerAppointments(cust.customerID);
                mySQLDB.DeleteCustomer(cust.customerID);
                new CustomersPage().Show();
                this.Close();
            }
        }
    }
}

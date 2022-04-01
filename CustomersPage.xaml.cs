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
            List<Customer> customersList = mySQLDB.SelectAllCustomersAndAddressData();

            CollectionViewSource CustomerCollectionViewSource;
            CustomerCollectionViewSource = (CollectionViewSource)(FindResource("CustomerCollectionViewSource"));
            CustomerCollectionViewSource.Source = customersList;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text.Count() > 0)
            {
                mySQLDB mySQLDB = new mySQLDB();
                List<Customer> customersList = mySQLDB.SelectAllCustomersAndAddressData();
                List<Customer> filteredCustomersList = new List<Customer>();

                foreach (Customer customer in customersList)
                {
                    if (customer.customerName.ToLower().Contains(SearchBox.Text.ToLower()) || customer.address.ToLower().Contains(SearchBox.Text.ToLower()) || customer.address2.ToLower().Contains(SearchBox.Text.ToLower()) || customer.city.ToLower().Contains(SearchBox.Text.ToLower()) || customer.postal.ToLower().Contains(SearchBox.Text.ToLower()) || customer.country.ToLower().Contains(SearchBox.Text.ToLower()) || customer.phone.ToLower().Contains(SearchBox.Text.ToLower()))
                    {
                        filteredCustomersList.Add(customer);
                    }
                }

                CollectionViewSource CustomerCollectionViewSource;
                CustomerCollectionViewSource = (CollectionViewSource)(FindResource("CustomerCollectionViewSource"));
                CustomerCollectionViewSource.Source = filteredCustomersList;
            }
            else
            {
                mySQLDB mySQLDB = new mySQLDB();
                List<Customer> customersList = mySQLDB.SelectAllCustomersAndAddressData();

                CollectionViewSource CustomerCollectionViewSource;
                CustomerCollectionViewSource = (CollectionViewSource)(FindResource("CustomerCollectionViewSource"));
                CustomerCollectionViewSource.Source = customersList;
            }
            customerDataGrid_Loaded(sender, e);

            //Clear Search Textbox for easier followup search
            SearchBox.Text = "";
        }

        private void SearchBox_EnterKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton_Click(sender, e);
            }
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
            var warning = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the selected Customer and any appointments linked to this Customer? This is permanent!", "Grimoire - Confirm Delete?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (warning == System.Windows.Forms.DialogResult.OK)
            {
                mySQLDB mySQLDB = new mySQLDB();
                Customer cust = (Customer)customerDataGrid.SelectedItem;
                mySQLDB.DeleteCustomerAppointments(cust.Id);
                mySQLDB.DeleteCustomer(cust.Id);
                new CustomersPage().Show();
                this.Close();
            }
        }

        private void customerDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Hide unnecessary columns from data grid
            customerDataGrid.Columns[1].Visibility = Visibility.Hidden;
            customerDataGrid.Columns[2].Visibility = Visibility.Hidden;
            customerDataGrid.Columns[9].Visibility = Visibility.Hidden;
            customerDataGrid.Columns[10].Visibility = Visibility.Hidden;
            customerDataGrid.Columns[11].Visibility = Visibility.Hidden;
            customerDataGrid.Columns[12].Visibility = Visibility.Hidden;
            customerDataGrid.Columns[13].Visibility = Visibility.Hidden;
            //customerDataGrid.Columns[7].Visibility = Visibility.Hidden;
            
            //Rename remaining columns to have more friendly names
            customerDataGrid.Columns[0].Header = "Customer Name";
            customerDataGrid.Columns[3].Header = "Address";
            customerDataGrid.Columns[4].Header = "Address 2";
            customerDataGrid.Columns[5].Header = "City";
            customerDataGrid.Columns[6].Header = "Postal Code";
            customerDataGrid.Columns[7].Header = "Country";
            customerDataGrid.Columns[8].Header = "Phone Number";
        }
    }
}

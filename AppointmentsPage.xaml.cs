using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace C969___Scheduling_Software
{
    /// <summary>
    /// Interaction logic for AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage : Window
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            mySQLDB mySQLDB = new mySQLDB();
            List<Appointment> allAppointmentsList = mySQLDB.SelectAllAppointments();
            List<Appointment> userAppointmentsList = new List<Appointment>();
            
            foreach (Appointment appointment in allAppointmentsList)
            {
                appointment.startDateTime = appointment.startDateTime.ToLocalTime();
                appointment.endDateTime = appointment.endDateTime.ToLocalTime();
                appointment.apptCreatedDateTime = appointment.apptCreatedDateTime.ToLocalTime();
                appointment.apptLastUpdateDateTime = appointment.apptLastUpdateDateTime.ToLocalTime();

                if (appointment.apptUserID == mySQLDB.GetLoggedInUID())
                {
                    userAppointmentsList.Add(appointment);
                }
            }

            CollectionViewSource AppointmentCollectionViewSource;
            AppointmentCollectionViewSource = (CollectionViewSource)(FindResource("AppointmentCollectionViewSource"));
            AppointmentCollectionViewSource.Source = userAppointmentsList;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text.Count() > 0)
            {
                mySQLDB mySQLDB = new mySQLDB();
                List<Appointment> allAppointmentsList = mySQLDB.SelectAllAppointments();
                List<Appointment> userAppointmentsList = new List<Appointment>();
                List<Appointment> filteredAppointmentsList = new List<Appointment>();
                foreach (Appointment appointment in allAppointmentsList)
                {
                    appointment.startDateTime = appointment.startDateTime.ToLocalTime();
                    appointment.endDateTime = appointment.endDateTime.ToLocalTime();
                    appointment.apptCreatedDateTime = appointment.apptCreatedDateTime.ToLocalTime();
                    appointment.apptLastUpdateDateTime = appointment.apptLastUpdateDateTime.ToLocalTime();

                    if (appointment.apptUserID == mySQLDB.GetLoggedInUID())
                    {
                        userAppointmentsList.Add(appointment);
                    }
                }
                foreach (Appointment appointment in userAppointmentsList)
                {
                    if (appointment.apptTitle.ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptDescription.ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptContact.ToLower().Contains(SearchBox.Text.ToLower()) || mySQLDB.GetCustomerNameFromCustomerID(appointment.apptCustID).ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptLocation.ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptType.ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptURL.ToLower().Contains(SearchBox.Text.ToLower()))
                    {
                        filteredAppointmentsList.Add(appointment);
                    }
                }

                CollectionViewSource AppointmentCollectionViewSource;
                AppointmentCollectionViewSource = (CollectionViewSource)(FindResource("AppointmentCollectionViewSource"));
                AppointmentCollectionViewSource.Source = filteredAppointmentsList;
            }
            else
            {
                mySQLDB mySQLDB = new mySQLDB();
                List<Appointment> allAppointmentsList = mySQLDB.SelectAllAppointments();
                List<Appointment> userAppointmentsList = new List<Appointment>();

                foreach (Appointment appointment in allAppointmentsList)
                {
                    appointment.startDateTime = appointment.startDateTime.ToLocalTime();
                    appointment.endDateTime = appointment.endDateTime.ToLocalTime();
                    appointment.apptCreatedDateTime = appointment.apptCreatedDateTime.ToLocalTime();
                    appointment.apptLastUpdateDateTime = appointment.apptLastUpdateDateTime.ToLocalTime();

                    if (appointment.apptUserID == mySQLDB.GetLoggedInUID())
                    {
                        userAppointmentsList.Add(appointment);
                    }
                }

                CollectionViewSource AppointmentCollectionViewSource;
                AppointmentCollectionViewSource = (CollectionViewSource)(FindResource("AppointmentCollectionViewSource"));
                AppointmentCollectionViewSource.Source = userAppointmentsList;
            }
            //Hide unnecessary columns from data grid
            apptDataGrid.Columns[0].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[1].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[2].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[11].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[12].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[13].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[14].Visibility = Visibility.Hidden;

            //Rename remaining columns to have more friendly names
            apptDataGrid.Columns[3].Header = "Title";
            apptDataGrid.Columns[4].Header = "Description";
            apptDataGrid.Columns[5].Header = "Location";
            apptDataGrid.Columns[6].Header = "Contact";
            apptDataGrid.Columns[7].Header = "Type";
            apptDataGrid.Columns[8].Header = "URL";
            apptDataGrid.Columns[9].Header = "Start Date & Time";
            apptDataGrid.Columns[10].Header = "End Date & Time";

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

        private void apptAddButton_Click(object sender, RoutedEventArgs e)
        {
            new AddAppointment().Show();
            this.Close();
        }

        private void apptUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Appointment appt = (Appointment)apptDataGrid.SelectedItem;
            new UpdateAppointment(appt).Show();
            this.Close();
        }

        private void apptDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var warning = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the selected Appointment? This is permanent!", "Grimoire - Confirm Delete?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(warning == System.Windows.Forms.DialogResult.OK)
            {
                mySQLDB mySQLDB = new mySQLDB();
                Appointment appt = (Appointment)apptDataGrid.SelectedItem;
                mySQLDB.DeleteAppointment(appt.apptID);
                new AppointmentsPage().Show();
                this.Close();
            }


        }

        private void apptDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Hide unnecessary columns from data grid
            apptDataGrid.Columns[0].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[1].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[2].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[11].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[12].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[13].Visibility = Visibility.Hidden;
            apptDataGrid.Columns[14].Visibility = Visibility.Hidden;

            //Rename remaining columns to have more friendly names
            apptDataGrid.Columns[3].Header = "Title";
            apptDataGrid.Columns[4].Header = "Description";
            apptDataGrid.Columns[5].Header = "Location";
            apptDataGrid.Columns[6].Header = "Contact";
            apptDataGrid.Columns[7].Header = "Type";
            apptDataGrid.Columns[8].Header = "URL";
            apptDataGrid.Columns[9].Header = "Start Date & Time";
            apptDataGrid.Columns[10].Header = "End Date & Time";
        }
    }
}

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
            var warning = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the selected Appointment? This is permanent!", "Dom's Cool Scheduler - Confirm Delete?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(warning == System.Windows.Forms.DialogResult.OK)
            {
                mySQLDB mySQLDB = new mySQLDB();
                Appointment appt = (Appointment)apptDataGrid.SelectedItem;
                mySQLDB.DeleteAppointment(appt.apptID);
                new AppointmentsPage().Show();
                this.Close();
            }


        }
            
    }
}

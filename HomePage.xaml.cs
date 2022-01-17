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

namespace C969___Scheduling_Software
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
            DateTime loginTime = DateTime.Now;
            DateTime reminderTime = loginTime.AddMinutes(15);

            mySQLDB mySQLDB = new mySQLDB();
            List<Appointment> allAppointmentsList = mySQLDB.SelectAllAppointments();
            List<Appointment> upcomingAppointmentsList = new List<Appointment>();
            foreach (Appointment appointment in allAppointmentsList)
            {
                appointment.startDateTime = appointment.startDateTime.ToLocalTime();
                appointment.endDateTime = appointment.endDateTime.ToLocalTime();
                appointment.apptCreatedDateTime = appointment.apptCreatedDateTime.ToLocalTime();
                appointment.apptLastUpdateDateTime = appointment.apptLastUpdateDateTime.ToLocalTime();
                if (appointment.startDateTime <= reminderTime && appointment.startDateTime >= loginTime)
                {
                    upcomingAppointmentsList.Add(appointment);
                }
            }

            CollectionViewSource AppointmentCollectionViewSource;
            AppointmentCollectionViewSource = (CollectionViewSource)(FindResource("AppointmentCollectionViewSource"));
            AppointmentCollectionViewSource.Source = upcomingAppointmentsList;

            if (upcomingAppointmentsList.Count == 0)
            {
                homeDataGrid.Visibility = Visibility.Hidden;
                noAppointmentsLabel.Visibility = Visibility.Visible;
                noAppointmentsRectangle.Visibility = Visibility.Visible;
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
    }
}

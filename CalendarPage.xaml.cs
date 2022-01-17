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
    /// Interaction logic for CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Window
    {
        public CalendarPage()
        {
            InitializeComponent();
            mySQLDB mySQLDB = new mySQLDB();
            List<Appointment> appointmentsList = mySQLDB.SelectAllAppointments();
            List<Appointment> calendarApptList = new List<Appointment>();

            //default to month view
            foreach (var appt in appointmentsList.Where(n => n.startDateTime.ToLocalTime().Month == DateTime.Today.Month && n.apptUserID == mySQLDB.GetLoggedInUID())) //Using a Lambda expression here for the LINQ query simplifies the code greatly vs using long form query syntax. As an alternate, if I desired query syntax vs a Lambda, I could use something akin to: foreach (var appt in from appt in apptList where appt.startDateTime.Month == DateTime.Today.Month select appt){...}. This is much longer and harder to read than the Lambda
            {
                calendarApptList.Add(appt);
            }

            CollectionViewSource CalendarCollectionViewSource;
            CalendarCollectionViewSource = (CollectionViewSource)FindResource("CalendarCollectionViewSource");
            CalendarCollectionViewSource.Source = calendarApptList;

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

        private void calWeeklyButton_Click(object sender, RoutedEventArgs e)
        {
            mySQLDB mySQLDB = new mySQLDB();
            List<Appointment> appointmentsList = mySQLDB.SelectAllAppointments();
            List<Appointment> weekApptList = new List<Appointment>();

            foreach (var appt in appointmentsList.Where(n => n.startDateTime.ToLocalTime() >= DateTime.Today && n.startDateTime.ToLocalTime() <= DateTime.Today.AddDays(7) && n.apptUserID == mySQLDB.GetLoggedInUID())) //More lambdas for the same reasons expressed above
            {
                weekApptList.Add(appt);
            }

            CollectionViewSource CalendarCollectionViewSource;
            CalendarCollectionViewSource = (CollectionViewSource)FindResource("CalendarCollectionViewSource");
            CalendarCollectionViewSource.Source = weekApptList;


        }

        private void calMonthButton_Click(object sender, RoutedEventArgs e)
        {
            mySQLDB mySQLDB = new mySQLDB();
            List<Appointment> appointmentsList = mySQLDB.SelectAllAppointments();
            List<Appointment> monthApptList = new List<Appointment>();

            foreach (var appt in appointmentsList.Where(n => n.startDateTime.ToLocalTime().Month == DateTime.Today.Month && n.apptUserID == mySQLDB.GetLoggedInUID())) //More lambdas for the same reasons expressed above
            {
                monthApptList.Add(appt);
            }

            CollectionViewSource CalendarCollectionViewSource;
            CalendarCollectionViewSource = (CollectionViewSource)FindResource("CalendarCollectionViewSource");
            CalendarCollectionViewSource.Source = monthApptList;
        }
    }
}

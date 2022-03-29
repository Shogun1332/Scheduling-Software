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
                appt.startDateTime = appt.startDateTime.ToLocalTime();
                appt.endDateTime = appt.endDateTime.ToLocalTime();
                appt.apptCreatedDateTime = appt.apptCreatedDateTime.ToLocalTime();
                appt.apptLastUpdateDateTime = appt.apptLastUpdateDateTime.ToLocalTime();

                calendarApptList.Add(appt);
            }

            CollectionViewSource CalendarCollectionViewSource;
            CalendarCollectionViewSource = (CollectionViewSource)FindResource("CalendarCollectionViewSource");
            CalendarCollectionViewSource.Source = calendarApptList;

        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text.Count() > 0)
            {
                mySQLDB mySQLDB = new mySQLDB();
                List<Appointment> appointmentsList = mySQLDB.SelectAllAppointments();
                List<Appointment> calendarApptList = new List<Appointment>();
                List<Appointment> filteredAppointmentsList = new List<Appointment>();
                foreach (Appointment appointment in appointmentsList.Where(n => n.startDateTime.ToLocalTime().Month == DateTime.Today.Month && n.apptUserID == mySQLDB.GetLoggedInUID()))
                {
                    appointment.startDateTime = appointment.startDateTime.ToLocalTime();
                    appointment.endDateTime = appointment.endDateTime.ToLocalTime();
                    appointment.apptCreatedDateTime = appointment.apptCreatedDateTime.ToLocalTime();
                    appointment.apptLastUpdateDateTime = appointment.apptLastUpdateDateTime.ToLocalTime();

                    calendarApptList.Add(appointment);
                }
                foreach (Appointment appointment in calendarApptList)
                {
                    if (appointment.apptTitle.ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptDescription.ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptContact.ToLower().Contains(SearchBox.Text.ToLower()) || mySQLDB.GetCustomerNameFromCustomerID(appointment.apptCustID).ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptLocation.ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptType.ToLower().Contains(SearchBox.Text.ToLower()) || appointment.apptURL.ToLower().Contains(SearchBox.Text.ToLower()))
                    {
                        filteredAppointmentsList.Add(appointment);
                    }
                }

                CollectionViewSource CalendarCollectionViewSource;
                CalendarCollectionViewSource = (CollectionViewSource)(FindResource("CalendarCollectionViewSource"));
                CalendarCollectionViewSource.Source = filteredAppointmentsList;
            }
            else
            {
                mySQLDB mySQLDB = new mySQLDB();
                List<Appointment> appointmentsList = mySQLDB.SelectAllAppointments();
                List<Appointment> calendarApptList = new List<Appointment>();

                foreach (Appointment appointment in appointmentsList.Where(n => n.startDateTime.ToLocalTime().Month == DateTime.Today.Month && n.apptUserID == mySQLDB.GetLoggedInUID()))
                {
                    appointment.startDateTime = appointment.startDateTime.ToLocalTime();
                    appointment.endDateTime = appointment.endDateTime.ToLocalTime();
                    appointment.apptCreatedDateTime = appointment.apptCreatedDateTime.ToLocalTime();
                    appointment.apptLastUpdateDateTime = appointment.apptLastUpdateDateTime.ToLocalTime();

                    calendarApptList.Add(appointment);
                }

                CollectionViewSource CalendarCollectionViewSource;
                CalendarCollectionViewSource = (CollectionViewSource)(FindResource("CalendarCollectionViewSource"));
                CalendarCollectionViewSource.Source = calendarApptList;
            }
            calDataGrid_Loaded(sender, e);

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

        private void calWeeklyButton_Click(object sender, RoutedEventArgs e)
        {
            mySQLDB mySQLDB = new mySQLDB();
            List<Appointment> appointmentsList = mySQLDB.SelectAllAppointments();
            List<Appointment> calendarApptList = new List<Appointment>();

            foreach (var appt in appointmentsList.Where(n => n.startDateTime.ToLocalTime() >= DateTime.Today && n.startDateTime.ToLocalTime() <= DateTime.Today.AddDays(7) && n.apptUserID == mySQLDB.GetLoggedInUID())) //More lambdas for the same reasons expressed above
            {
                calendarApptList.Add(appt);
            }

            CollectionViewSource CalendarCollectionViewSource;
            CalendarCollectionViewSource = (CollectionViewSource)FindResource("CalendarCollectionViewSource");
            CalendarCollectionViewSource.Source = calendarApptList;

            calDataGrid_Loaded(sender, e);
        }

        private void calMonthButton_Click(object sender, RoutedEventArgs e)
        {
            mySQLDB mySQLDB = new mySQLDB();
            List<Appointment> appointmentsList = mySQLDB.SelectAllAppointments();
            List<Appointment> calendarApptList = new List<Appointment>();

            foreach (var appt in appointmentsList.Where(n => n.startDateTime.ToLocalTime().Month == DateTime.Today.Month && n.apptUserID == mySQLDB.GetLoggedInUID())) //More lambdas for the same reasons expressed above
            {
                calendarApptList.Add(appt);
            }

            CollectionViewSource CalendarCollectionViewSource;
            CalendarCollectionViewSource = (CollectionViewSource)FindResource("CalendarCollectionViewSource");
            CalendarCollectionViewSource.Source = calendarApptList;

            calDataGrid_Loaded(sender, e);
        }

        private void calDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Hide unnecessary columns from data grid
            calDataGrid.Columns[0].Visibility = Visibility.Hidden;
            calDataGrid.Columns[1].Visibility = Visibility.Hidden;
            calDataGrid.Columns[2].Visibility = Visibility.Hidden;
            calDataGrid.Columns[11].Visibility = Visibility.Hidden;
            calDataGrid.Columns[12].Visibility = Visibility.Hidden;
            calDataGrid.Columns[13].Visibility = Visibility.Hidden;
            calDataGrid.Columns[14].Visibility = Visibility.Hidden;

            //Rename remaining columns to have more friendly names
            calDataGrid.Columns[3].Header = "Title";
            calDataGrid.Columns[4].Header = "Description";
            calDataGrid.Columns[5].Header = "Location";
            calDataGrid.Columns[6].Header = "Contact";
            calDataGrid.Columns[7].Header = "Type";
            calDataGrid.Columns[8].Header = "URL";
            calDataGrid.Columns[9].Header = "Start Date & Time";
            calDataGrid.Columns[10].Header = "End Date & Time";
        }
    }
}

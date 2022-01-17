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
    /// Interaction logic for ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Window
    {
        public ReportsPage()
        {
            InitializeComponent();
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

        private void apptTypesByMonthButton_Click(object sender, RoutedEventArgs e)
        {
            noReportLabel.Visibility = Visibility.Hidden;
            noReportRectangle.Visibility = Visibility.Hidden;
            mySQLDB mySQLDB = new mySQLDB();
            List<NumberAppointmentTypesByMonth> reportList = mySQLDB.Report_NumAppointmentTypesByMonth();

            foreach (var item in reportList)
            {
                int year = int.Parse(item.appointmentMonth.Substring(0, 4));
                int convertMonth = int.Parse(item.appointmentMonth.Substring(4));
                string longNameMonth = new DateTime(year, convertMonth, 1).ToString("MMMM");
                string prettyYearMonth = year.ToString() + " - " + longNameMonth;
                item.appointmentMonth = prettyYearMonth;
            }


            CollectionViewSource ReportsCollectionViewSource;
            ReportsCollectionViewSource = (CollectionViewSource)FindResource("ReportsCollectionViewSource");
            ReportsCollectionViewSource.Source = reportList;

        }

        private void customReportButton_Click(object sender, RoutedEventArgs e)
        {
            noReportLabel.Visibility = Visibility.Hidden;
            noReportRectangle.Visibility = Visibility.Hidden;
            mySQLDB mySQLDB = new mySQLDB();
            List<NumberCustomersAndAppointmentsByCity> reportList = mySQLDB.Report_NumberCustomersAndAppointmentsByCity();

            CollectionViewSource ReportsCollectionViewSource;
            ReportsCollectionViewSource = (CollectionViewSource)FindResource("ReportsCollectionViewSource");
            ReportsCollectionViewSource.Source = reportList;

        }

        private void consultantScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            noReportLabel.Visibility = Visibility.Hidden;
            noReportRectangle.Visibility = Visibility.Hidden;
            mySQLDB mySQLDB = new mySQLDB();
            List<ConsultantSchedule> reportList = mySQLDB.Report_ConsultantSchedules();

            foreach (var item in reportList)
            {
                item.consultantName = mySQLDB.GetConsultantNameFromUserID(int.Parse(item.consultantName));
                item.customerName = mySQLDB.GetCustomerNameFromCustomerID(int.Parse(item.customerName));
                item.startTime.ToLocalTime();
                item.endTime.ToLocalTime();
            }


            CollectionViewSource ReportsCollectionViewSource;
            ReportsCollectionViewSource = (CollectionViewSource)FindResource("ReportsCollectionViewSource");
            ReportsCollectionViewSource.Source = reportList;
        }
    }
}

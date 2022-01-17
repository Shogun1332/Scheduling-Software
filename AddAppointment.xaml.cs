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
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        public AddAppointment()
        {
            InitializeComponent();
            mySQLDB mySQLDB = new mySQLDB();
            List<Customer> allCustomersList = mySQLDB.SelectAllCustomers();
            List<string> custNamesList = new List<string>();
            foreach (var customer in allCustomersList)
            {
                custNamesList.Add(String.Format(customer.customerName));
            }

            addApptCustomerComboBox.ItemsSource = custNamesList;
        }

        private void newCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            //Need to build function
        }

        private static bool CheckApptHasConflict(DateTime start, DateTime end)
        {
            mySQLDB mySQLDB = new mySQLDB();
            int countApptsAtTime = mySQLDB.CheckForApptsAtTime(start, end);
            List<Appointment> apptList = mySQLDB.SelectCurrentUIDAppointments();
            if (countApptsAtTime > 0)
            {
                return true;
            }
            foreach (var appt in apptList)
            {
                if (start <= appt.startDateTime && end >= appt.endDateTime)
                {
                    return true;
                }
                if (start >= appt.startDateTime && start < appt.endDateTime)
                {
                    return true;
                }
                if (end > appt.startDateTime && end <= appt.startDateTime)
                {
                    return true;
                }

                /*if (start < appt.endDateTime && start < appt.startDateTime)
                {
                    hasConflict = true;
                }*/
                    /*if (end > appt.startDateTime && end < appt.endDateTime)
                    {
                        hasConflict = true;
                    }*/
                    /*if (end > appt.startDateTime && end > appt.endDateTime)
                    {
                        hasConflict = true;
                    }*/
            }
            return false;
        }

        private static bool CheckApptOutsideBusHours(DateTime start, DateTime end)
        {
            DateTime bizStartTime = DateTime.Today.AddHours(8);
            DateTime bizEndTime = DateTime.Today.AddHours(17);
            DateTime apptStart = start;
            DateTime apptEnd = end;

            if(apptStart >= bizEndTime || apptStart < bizStartTime)
            {
                return true;
            }
            if (apptEnd > bizEndTime || apptEnd <= bizStartTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void saveApptButton_Click(object sender, RoutedEventArgs e)
        {
            mySQLDB mySQLDB = new mySQLDB();
            DateTime now = DateTime.UtcNow;
            //DateTime later = now.AddMinutes(30);
            int apptID = mySQLDB.GetMaxAppointmentID();
            int custID = mySQLDB.GetCustomerIDFromCustomerName(addApptCustomerComboBox.SelectedItem.ToString());
            int userID = mySQLDB.GetLoggedInUID();
            string title = addApptTitleTextBox.Text;
            string desc = addApptDescriptionTextBox.Text;
            string loc = addApptLocationTextBox.Text;
            string contact = addApptContactTextBox.Text;
            string type = addApptTypeTextBox.Text;
            string url = addApptURLTextBox.Text;
            
            //Start Date/Time stuff
            string startDateSelectedValue = addApptStartDateBox.SelectedDate.ToString();
            DateTime startDateExpl = DateTime.Parse(startDateSelectedValue);
            DateTime startTimeExpl = new DateTime();
            if (addApptStartAMPM.SelectedIndex == 1 && addApptStartHour.SelectedIndex != 11)
            {
                startTimeExpl = DateTime.Today.AddHours((addApptStartHour.SelectedIndex) + 13).AddMinutes(int.Parse(addApptStartMin.Text));
            }
            if (addApptStartAMPM.SelectedIndex == 1 && addApptStartHour.SelectedIndex == 11)
            {
                startTimeExpl = DateTime.Today.AddHours(12).AddMinutes(int.Parse(addApptStartMin.Text));
            }
            if (addApptStartAMPM.SelectedIndex == 0 && addApptStartHour.SelectedIndex == 11)
            {
                startTimeExpl = DateTime.Today.AddMinutes(int.Parse(addApptStartMin.Text));
            }
            if (addApptStartAMPM.SelectedIndex == 0 && addApptStartHour.SelectedIndex != 11)
            {
                startTimeExpl = DateTime.Today.AddHours((addApptStartHour.SelectedIndex) + 1).AddMinutes(int.Parse(addApptStartMin.Text));
            }
            string startDate = startDateExpl.ToString("yyyy-MM-dd HH:mm:ss");
            string startTime = startTimeExpl.ToString("yyyy-MM-dd HH:mm:ss");
            string startCombo = startDate.Substring(0, 10) + " " + startTime.Substring(10);
            DateTime start = DateTime.Parse(startCombo).ToUniversalTime();
            
            //End Date/Time stuff
            string endDateSelectedValue = addApptEndDateBox.SelectedDate.ToString();
            DateTime endDateExpl = DateTime.Parse(endDateSelectedValue);
            DateTime endTimeExpl = new DateTime();
            if (addApptEndAMPM.SelectedIndex == 1 && addApptEndHour.SelectedIndex != 11)
            {
                endTimeExpl = DateTime.Today.AddHours((addApptEndHour.SelectedIndex) + 13).AddMinutes(int.Parse(addApptEndMin.Text));
            }
            if (addApptEndAMPM.SelectedIndex == 1 && addApptEndHour.SelectedIndex == 11)
            {
                endTimeExpl = DateTime.Today.AddHours(12).AddMinutes(int.Parse(addApptEndMin.Text));
            }
            if (addApptEndAMPM.SelectedIndex == 0 && addApptEndHour.SelectedIndex == 11)
            {
                endTimeExpl = DateTime.Today.AddMinutes(int.Parse(addApptEndMin.Text));
            }
            if (addApptEndAMPM.SelectedIndex == 0 && addApptEndHour.SelectedIndex != 11)
            {
                endTimeExpl = DateTime.Today.AddHours(addApptEndHour.SelectedIndex + 1).AddMinutes(int.Parse(addApptEndMin.Text));
            }
            string endDate = endDateExpl.ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = endTimeExpl.ToString("yyyy-MM-dd HH:mm:ss");
            string endCombo = endDate.Substring(0, 10) + " " + endTime.Substring(10);
            DateTime end = DateTime.Parse(endCombo).ToUniversalTime();

            string username = mySQLDB.GetLoggedInUName();

            try
            {
                if(CheckApptHasConflict(start, end))
                {
                    throw new ApptException();
                }
                else
                {
                    try
                    {
                        if (CheckApptOutsideBusHours(startTimeExpl, endTimeExpl))
                        {
                            throw new ApptException();
                        }
                        else
                        {
                            try
                            {
                                if(type.Length == 0)
                                {
                                    throw new ApptException();
                                }
                                else
                                {
                                    try
                                    {
                                        if (!mySQLDB.InsertNewAppointment(apptID, custID, userID, title, desc, loc, contact, type, url, start, end, now, username, now, username))
                                        {
                                            throw new ApptException();
                                        }
                                        else
                                        {
                                            //Update Appt Page
                                            new AppointmentsPage().Show();
                                            this.Close();
                                        }
                                    }
                                    catch (ApptException exception)
                                    {
                                        exception.ApptGeneralException();
                                    }
                                }
                                
                            }
                            catch (ApptException exception)
                            {
                                exception.ApptGeneralException();
                            }
                        }
                    }
                    catch (ApptException exception)
                    {
                        exception.ApptOutOfBusHoursException();
                    }
                }
            }
            catch (ApptException exception)
            {
                exception.ApptConflictException();
            }
        }
    }
}

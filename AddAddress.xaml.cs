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
    /// Interaction logic for AddAddress.xaml
    /// </summary>
    public partial class AddAddress : Window
    {
        public AddAddress()
        {
            InitializeComponent();
            mySQLDB mySQLDB = new mySQLDB();
            List<Country> allCountryList = mySQLDB.SelectAllCountries();
            List<string> countryList = new List<string>();
            foreach (var country in allCountryList)
            {
                countryList.Add(String.Format(country.country));
            }

            addAddressCountryComboBox.ItemsSource = countryList;
        }

        private void saveAddressButton_Click(object sender, RoutedEventArgs e)
        {
            mySQLDB mySQLDB = new mySQLDB();
            bool proceed = false;
            try
            {
                if (addAddressCityComboBox.SelectedItem == null || addAddressCountryComboBox.SelectedItem == null || addAddressAddressTextBox.Text.Length == 0 || addAddressPhoneTextBox.Text.Length == 0 || addAddressPostalCodeTextBox.Text.Length == 0)
                {
                    proceed = false;
                    throw new ApptException();
                }
                else
                {
                    proceed = true;
                    mySQLDB.InsertAddress(addAddressCityComboBox.SelectedItem.ToString(), addAddressAddressTextBox.Text, addAddressAddress2TextBox.Text, addAddressPostalCodeTextBox.Text, addAddressPhoneTextBox.Text);
                }
            }
            catch (ApptException exception)
            {
                exception.AddressDataException();
            }
            if (proceed)
            {
                new AddCustomer().Show();
                this.Close();
            }
        }

        private void addAddressCountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string countrySelect = addAddressCountryComboBox.SelectedItem.ToString();
            mySQLDB mySQLDB = new mySQLDB();
            List<City> allCityList = mySQLDB.SelectAllCities();
            List<string> cityList = new List<string>();
            //var citiesInCityList = from city in allCityList where city.countryID == mySQLDB.GetCountryIDFromCountryName(countrySelect) select city; NO LONGER NEEDED DUE TO LAMBDA EXPRESSION BELOW
            foreach (var city in allCityList.Where(n => n.countryID == mySQLDB.GetCountryIDFromCountryName(countrySelect))) //By implementing a Lambda expression here I am able to eliminate the above line of code and simplify this LINQ function into one single line rather than being broken up across two lines.
            {
                cityList.Add(String.Format(city.city));
            }

            addAddressCityComboBox.ItemsSource = cityList;
        }
    }
}

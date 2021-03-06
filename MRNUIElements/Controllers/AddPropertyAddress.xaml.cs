﻿using MRNNexus_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
namespace MRNUIElements.Controllers
{


    /// <summary>
    /// Interaction logic for AddPropertyAddress.xaml
    /// </summary>
    public partial class AddPropertyAddress
    {
        static ServiceLayer s1 = ServiceLayer.getInstance();

        static MRNClaim MrnClaim = MRNClaim.getInstance();
        private DTO_Address address { get; set; }


        public AddPropertyAddress()
        {
            InitializeComponent();
            Select_Button.IsEnabled = false;
            GetAddress();
            AddressTextbox.IsEnabled = false;
        }

        private async void GetAddress()
        {

            List<string> strlist = new List<string>();
            strlist.Add("Loading...");
            listView.ItemsSource = strlist;
            await s1.GetAllAddresses();
        }

        DTO_Address UpdateAddress(string addressstring = "", string zip = "")
        {
            if (!string.IsNullOrEmpty(addressstring) && !string.IsNullOrEmpty(zip))
            {
                if(address==null)
                    address = new DTO_Address();

                address.Address = addressstring;
                address.Zip = zip;

            }
            return address;


        }

        private void MaskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (ZipcodeBox.Text.Length != 5)
            {
                List<DTO_Address> addList = new List<DTO_Address>();
                var a = new DTO_Address { Address = "Zipcode Required...", Zip = "" };
                addList.Add(a);
                listView.ItemsSource = addList;
                AddressTextbox.IsEnabled = false;
                return;
            }
            else
            {
                listView.ItemsSource = s1.AddressesList.FindAll(x => x.Zip == ZipcodeBox.Text);
                AddressTextbox.IsEnabled = true;
            }
        }



        private void ZipcodeBox_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ZipcodeBox.Text = ZipcodeBox.Value.ToString();

            if (ZipcodeBox.Text.Length != 5)
            {
                List<DTO_Address> addList = new List<DTO_Address>();
                var a = new DTO_Address { Address = "Zipcode Required...", Zip = "" };
                addList.Add(a);
                if (listView != null)
                    listView.ItemsSource = addList;
                AddressTextbox.IsEnabled = false;
                return;
            }

            else
            {
                listView.ItemsSource = s1.AddressesList.FindAll(x => x.Zip == ZipcodeBox.Text);

                AddressTextbox.IsEnabled = true;
            }

        }

        private bool CheckIfExists(string streetAddress)
        {


            if (!s1.AddressesList.Exists(x => x.Address == streetAddress && x.Zip == ZipcodeBox.Text))
                return false;
                if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("Address is already in system, is this a new claim?", "Duplicate Address Entry", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No))
                    return false;
            return true;
        }

        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckIfExists(AddressTextbox.Text))
            {
                MrnClaim.a = UpdateAddress(AddressTextbox.Text, ZipcodeBox.Text);
                MRNClaim.getInstance().a = MrnClaim.a;
                NavigationService.Navigate(new AddLeadInformation(MRNClaim.getInstance()));
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedIndex < 0 && string.IsNullOrEmpty(AddressTextbox.Text))
            {
                Select_Button.IsEnabled = false;
                return;
            }
            else
                Select_Button.IsEnabled = true;


            MRNClaim.getInstance().a = address = (DTO_Address)listView.SelectedItem;
            if (listView.Items.Count > 0 && listView.SelectedIndex > -1)
                AddressTextbox.Text = ((DTO_Address)listView.SelectedItem).Address;
        }

        private void AddressTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (listView.SelectedIndex > -1)
                listView.SelectedIndex = -1;

            if (string.IsNullOrEmpty(AddressTextbox.Text))
            {
                listView.ItemsSource = s1.AddressesList.FindAll(x => x.Zip == ZipcodeBox.Text);
                Select_Button.IsEnabled = true;
            }
            else
            {
                listView.IsEnabled = true;
                listView.ItemsSource = s1.AddressesList.FindAll(x => x.Address.Contains(AddressTextbox.Text) && x.Zip == ZipcodeBox.Text).ToList();
                Select_Button.IsEnabled = true;
            }
        }
    }
}

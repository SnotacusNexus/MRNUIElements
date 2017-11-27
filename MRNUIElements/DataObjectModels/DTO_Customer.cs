using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using MRNNexus_Model;
using System.Windows;
using MRNUIElements.Controllers;

namespace MRNUIElements.DataObjectModels
{
    [KnownType(typeof(DTO_Base))]

    public class Customer : DTO_Customer, INotifyPropertyChanged
    {
        static DTO_Customer cust;
        ServiceLayer s = ServiceLayer.getInstance();
        public Customer()
        {
            if (s.Cust != null)
                cust = s.Cust;
            else return;

        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");

            }
        }

        private string middleName;

        public string MiddleName
        {
            get { return middleName; }
            set
            {

                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");

            }

        }




        public int CustomerID
        {
            get;
                    set;}



        private string suffix;

        public string Suffix
        {
            get { return suffix; }
            set
            {
                suffix = value;
                OnPropertyChanged("Suffix");
            }

        }

        private string primaryNumber;

        public string PrimaryNumber
        {
            get { return primaryNumber; }
            set
            {
                primaryNumber = value;

                OnPropertyChanged("Suffix");
            }
        }

        private string secondaryNumber;

        public string SecondaryNumber
        {
            get { return secondaryNumber; }
            set
            {
                secondaryNumber = value;
                OnPropertyChanged("SecondaryNumber");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private bool mailPromos;

        public bool MailPromos
        {
            get { return mailPromos; }
            set
            {
                mailPromos = value;
                OnPropertyChanged("MailPromos");
            }
        }

       
        public override string ToString()
        {
            return FirstName + " " + LastName.ToString();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

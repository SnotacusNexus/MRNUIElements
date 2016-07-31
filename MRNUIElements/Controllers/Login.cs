﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MRNNexus_Model;

namespace MRNUIElements.Controllers
{
    internal class Login : MRNUIElements.Login
    {

        public bool IsEmployeeLoggedIn { get; set; }

        public async Task UserLogin(TextBox usernameBox, PasswordBox passwordBox)
        {

            
            ServiceLayer s = ServiceLayer.getInstance();

            //await s.MakeRequest(new DTO_User { Username = usernameBox.Text, Pass = passwordBox.Text }, typeof(DTO_Employee), "Login");
            await s.MakeRequest(new DTO_User { Username = "aharvey@gmail.com", Pass = "Harvey1214" }, typeof(DTO_Employee), "Login");

            if (s.LoggedInEmployee.EmployeeID > 0 && s.LoggedInEmployee.SuccessFlag == true && s.LoggedInEmployee.Message == null)
            {
                IsEmployeeLoggedIn = true;
            }
            

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MRNNexusDTOs;
using System.Collections.ObjectModel;

namespace MRNNexus.WPFClient.Controllers
{
    internal class Inspection
    {
        //public ObservableCollection<DTO_InsuranceCompany> insuranceCompanies = new ObservableCollection<DTO_InsuranceCompany>();

        public async Task GetInsuranceCompanies()
        {
            ServiceLayer s = ServiceLayer.getInstance();
            await s.MakeRequest(new DTO_Base(), typeof(List<DTO_InsuranceCompany>), "GetAllInsuranceCompanyNames");
            //s.InsuranceCompaniesList.ForEach(i => insuranceCompanies.Add(i));
        }
    }
}

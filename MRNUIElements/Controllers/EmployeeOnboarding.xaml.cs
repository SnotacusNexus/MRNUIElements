using MRNNexus_Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for EmployeeOnboarding.xaml
	/// </summary>
	public partial class EmployeeOnboarding : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		DTO_User a = new DTO_User();
		DTO_Employee e = new DTO_Employee();
		DTO_EmployeeDetail f = new DTO_EmployeeDetail();
		public EmployeeOnboarding()
		{
			InitializeComponent();
		}
		async void setEmployeeObjectValues(DTO_Employee e, DTO_EmployeeDetail f) {

			var loe = new List<DTO_Employee>();
			if (s1.EmployeesList == null)
				await s1.GetAllEmployees();
			





			if ((bool)activeCheckBox.IsChecked)
				e.Active = true;
			else
				e.Active = false;

			e.CellPhone = EmployeeCellPhone.Text;
			e.Email = EmployeeEmail.Text;
		//	e.EmployeeTypeID = ((DTO_LU_EmployeeType)employeeType;
			e.FirstName = EmployeeFirstName.Text;
			e.LastName = EmployeeLastName.Text;
			f.SignaturePath = signaturePathTextBox.Text;
			f.ShirtSize = shirtSizeTextBox.Text;
			if ((bool)previousEmployeeCheckBox.IsChecked)
				f.PreviousEmployee = true;
			else
				f.PreviousEmployee = false;

			f.PayTypeID = (int)payTypeIDTextBox.SelectedValue;
			f.PayRate = (double)payRateTextBox.Value;
			f.PayFrequencyID = ((DTO_LU_PayFrequncy)payFrequencyIDComboBox.SelectedItem).PayFrequencyID;

			f.MailingAddress = EmployeeAddress.Text;
			f.EmployeeID = e.EmployeeID;
			f.DLPhotoPath = dLPhotoPathTextBox.Text;
			f.DateReleased = dateHiredDatePicker.SelectedDate;
			f.DateHired = dateHiredDatePicker.SelectedDate.Value;
			f.CompanyPhotoPath = companyPhotoPathTextBox.Text;

			


			s1.EmployeesList.Add(e);


			if (s1.EmployeesList != null)
				if (s1.EmployeesList.Count > 0)
					s1.EmployeesList.Clear();
			await s1.AddEmployee(e);
			if (s1.Employee.Message == null)
				System.Windows.Forms.MessageBox.Show(s1.Employee.EmployeeID.ToString());



			int i = ((DTO_Employee)s1.EmployeesList.Where(x => x.Email == e.Email)).EmployeeID;
			await s1.RegisterUser(new DTO_User {
				Username = e.Email.ToString(),
				Active = true, EmployeeID = i,
				Pass = "Mrn19699",
				PermissionID = 1
			});
		}

		private void payRateTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Lead_FirstName_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
	

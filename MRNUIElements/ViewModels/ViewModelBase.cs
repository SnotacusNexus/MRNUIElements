using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRNUIElements.Interface.Command;
using MRNUIElements.ViewModels.Commands;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MRNUIElements.Models;
using System.Windows.Navigation;
using static MRNUIElements.MainWindow;

namespace MRNUIElements.ViewModels
{


	public class ViewModelBase : ObservableCollection<ScopeModel>
	{

		//  public static PageFunction PF = PageFunction.getInstance();
		protected override event  PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyChanged)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
		}



		public SaveCommand SaveCommand { get; set; }
		public ViewModelBase()
		{
			this.SaveCommand = new SaveCommand(this);
		}



		public void SaveMethod()
		{
			Debug.Print("Going Home!");
			//   var page = new NexusHome();
			//  var n = new PageFunction();
			// n.Navigate(new NexusHome());
			//  page.NavigationService.Navigate(page);
		}
	}
}

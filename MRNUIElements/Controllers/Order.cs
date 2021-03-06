﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRNNexus_Model;
using System.Collections.ObjectModel;
using MRNUIElements.Controllers;
namespace MRNUIElements.RoofOrder
{

	public class RoofOrder
	{
		ServiceLayer s = ServiceLayer.getInstance();
		DTO_Inspection inspection = new DTO_Inspection();
		// public ObservableCollection<DTO_Plane> planes = new ObservableCollection<DTO_Plane>();
		public ObservableCollection<DTO_OrderItem> items = new ObservableCollection<DTO_OrderItem>();
		public int OrderID { get; set; }
		public int MeasurementID { get; set; }
		public int ShingleColor { get; set; }
		public int ShingleLine { get; set; }
		public int Manufacturer { get; set; }
		public int Sheathing { get; set; }
		public int PJB3 { get; set; }
		public int PJB4 { get; set; }
		public int UnderlaymentType { get; set; }
		public int VentType { get; set; }
		public int NumberOfVents { get; set; }
		public string SpecialInstructions { get; set; }
		public async void NewRoofOrder()
		{
			try
			{
				await s.GetPlanesByInspectionID(inspection);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());

			}

			int TotalEaves = 0;
			int TotalRidges = 0;
			double TotalSquareFootage = 0;
			int PJB3 = 0;
			int PJB4 = 0;
			int Hips = 0;
			int Valleys = 0;
			int Rakes = 0;
			int Pitches = 0;
			int AveragePitch = 0;
			int AverageEaveHeight = 0;
			int LowestPlaneHeight = 0;
			int LowestPlaneID = 0;
			int HeighestPlaneHeight = 0;
			int HeighestPlaneID = 0;
			int NumberOfPlanes = 0;
            int TotEaveHeight = 0;
           

            int a = 0;
			foreach (DTO_Plane p in s.PlanesList)
			{
                a++;
               
				TotalEaves += (int)p.EaveLength;
				PJB4 += (int)p.FourAndUp;
				p.GroupNumber=a;
				Hips += (int)p.Hip;
				Valleys += (int)p.Valley;
				p.ItemSpec = "";
				Pitches += (int)p.Pitch;
				Rakes += (int)p.RakeLength;
				TotalRidges += (int)p.RidgeLength;
				TotalSquareFootage += (double)p.SquareFootage;
				PJB3 += (int)p.ThreeAndOne;
				TotEaveHeight += (int)p.EaveHeight;
                AverageEaveHeight = (int)TotEaveHeight / a;
                    AveragePitch = (int)Pitches / a;

            }






		}


	}

}



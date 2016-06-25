using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using MRNNexus_Model;

namespace MRNNexusTestingConsole
{
    class Program
    {
  
        static void Main(string[] args)
        {
            Program p = new Program();
               // Console.ReadLine();
            for (int i = 0; i < 1; i++)
            {
				//Console.WriteLine(new DateTime(2016, 8, 12, 13, 0, 0).ToString());
               p.GetData();
            }
            Console.ReadLine();

        }

        async void GetData()
        {
            ServiceLayer s1 = new ServiceLayer();
            await s1.DoWork();
            Console.WriteLine(s1.calData.EntryID);
        }


    }
}

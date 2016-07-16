
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram;

namespace Shape_Shifter.ViewModel
{
    public class StencilVM : DiagramElementViewModel
    {
        private SymbolFilterProvider _selectedFilter;
        private Syncfusion.UI.Xaml.Diagram.Stencil.Symbol _selectedSymbol = null;
        public StencilVM()
        {
            //List<SymbolVM> items = new List<SymbolVM>()
            //    {
            //        new SymbolVM() {Symbol = new TextBlock {Text = "AAA"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "BBB"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "CCC"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "DDD"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "EEE"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "FFF"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "GGG"}},
            //    };
            SymbolFilterProvider all = new SymbolFilterProvider { SymbolFilter = All, Content = "All" };
            SymbolFilterProvider basicShapes = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Basic Shapes" };
            SymbolFilterProvider flowChart = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Flow Chart" };
            SymbolFilterProvider electrical = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Electrical" };
            SymbolFilterProvider connector = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Connector" };
            Filters = new ObservableCollection<SymbolFilterProvider>()
            {
                all,
                basicShapes,
                flowChart,
                electrical,
                connector
            };
            SelectedFilter = all;
        }

        public SymbolFilterProvider SelectedFilter
        {
            get { return _selectedFilter; }
            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    OnPropertyChanged("SelectedFilter");
                }
            }
        }

        public Syncfusion.UI.Xaml.Diagram.Stencil.Symbol SelectedSymbol
        {
            get { return _selectedSymbol; }
            set
            {
                if (_selectedSymbol != value)
                {
                    _selectedSymbol = value;
                    OnPropertyChanged("SelectedSymbol");
                }
            }
        }


        public IEnumerable<SymbolFilterProvider> Filters { get; set; }

        public object Test(object key)
        {
            return key;
        }

        public bool All(SymbolFilterProvider source, object symbol)
        {
            //if ((symbol.Symbol as TextBlock).Text == "AAA")
            //{
            //    return false;
            //}

            return true;
        }

        public bool Filter(SymbolFilterProvider source, object symbol)
        {
            return true;
            //if ((symbol as SymbolVM).GroupName.Equals(source.Content.ToString()))
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
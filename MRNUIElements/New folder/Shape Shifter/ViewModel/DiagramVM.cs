
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Shape_Shifter.Utility;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.IO;
using System.Collections;
using Microsoft.Win32;

namespace Shape_Shifter.ViewModel
{
    public class DiagramVM : DiagramViewModel, IDiagramViewModel
    {
        public bool _isValidXml = false;
        private bool _isSelected = false;
        private Brush _offPageBackground;
        private string _name;
        string _file;
        string installedLocation;
        private Visibility _mIsBusy = Visibility.Visible;

        public Visibility IsBusy
        {
            get { return _mIsBusy; }
            set
            {
                if (_mIsBusy != value)
                {
                    _mIsBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }

        //StorageFile file, 
        public DiagramVM(string file,bool isValidXml)
        {
            _isValidXml = isValidXml;
            _file = file;
            Nodes = new ObservableCollection<NodeVM>();
            Connectors = new ObservableCollection<ConnectorVM>();
            Groups = new ObservableCollection<GroupVM>();
            SelectedItems = new SelectorVM(this);

            Select = new Command(param => IsSelected = true);
            FirstLoad = new Command(OnViewLoaded);

            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.All,
                SnapToObject = SnapToObject.All
            };


            PageSettings = new PageVM();
       
            (PageSettings as PageVM).InitDiagram(this);

            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            //OffPageBackground = new SolidColorBrush(new Color() { A = 0xFF, R = 0xEC, G = 0xEC, B = 0xEC });
            //OffPageBackground = new SolidColorBrush(new Color() { A = 0xFF, R = 0x2D, G = 0x2D, B = 0x2D });
            InitLocation();
#if SyncfusionFramework4_5_1
            ExportSettings = new ExportSettings()
            {
                ImageStretch = Stretch.Uniform,
                ExportMode = ExportMode.PageSettings
            };
            PrintingService = new PrintingService();
#endif
            Export = new Command(OnExportCommand);
            Captures = new Command(OnCapturesCommand);
            ClearDiagram = new Command(OnClearCommand);
            Upload = new Command(Onuploadcommand);
            Draw = new Command(OnDrawCommand);
            SingleSelect = new Command(OnSingleSelectCommand);
            SelectAll = new Command(OnSelectAllCommand);
            Manipulate = new Command(OnManipulateCommand);
            LoadExt = new Command(OnLoadExt);
            AddImageNode = new Command(OnAddImageNodeCommand);
            PageOrientationCommand = new Command(OnPageOrientationCommand);
            PageSizeCommand = new Command(OnPageSizeCommand);
            ConnectTypeCommand = new Command(OnConnectTypeCommand);
            SizeandPositionCommand = new Command(OnSizeandPositionCommand);
            PanZoomCommand = new Command(OnPanZoomCommand);
           
            //Tool = Tool.ZoomPan | Tool.SingleSelect;
            ;

            //ConnectorVM c = new ConnectorVM()
            //{
            //    SourcePoint = new Point(100, 100),
            //    TargetPoint = new Point(300, 300)
            //};

            //(this.ConnectorCollection as ICollection<ConnectorVM>).Add(c);

        }

        private void OnLoadExt(object obj)
        {
            
        }

        private void OnManipulateCommand(object obj)
       {
            Tool = Tool.MultipleSelect;
          
        }

        private async void InitLocation()
        {
            installedLocation =   Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        void DiagramVM_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.ItemSource == ItemSource.Stencil)
            {
                var dropedItem = args.Item as INode;
                if (dropedItem != null)
                {
                    dropedItem.UnitHeight = 100; //PageSettings.Unit.ToUnit(100);
                    dropedItem.UnitWidth = 100;// PageSettings.Unit.ToUnit(100);
                    (dropedItem as INodeVM).Fill = new SolidColorBrush(Colors.White);
                }

            }
            else if (args.ItemSource == ItemSource.DrawingTool)
            {
                IConnectorVM newCon = args.Item as IConnectorVM;
                if (newCon != null)
                {
                    switch (DefaultConnectorType)
                    {
                        case ConnectorType.Orthogonal:
                            newCon.Type = ConnectType.Orthogonal;
                            break;
                        case ConnectorType.Line:
                            newCon.Type = ConnectType.Straight;
                            break;
                        case ConnectorType.CubicBezier:
                            newCon.Type = ConnectType.Bezier;
                            break;
                    }
                }
                //DefaultConnectorType = ConnectorType.Orthogonal;
            }
            CheckEmpty();
        }

        void DiagramVM_ItemDeleted(object sender, DiagramEventArgs args)
        {
            CheckEmpty();        
        }

        private void CheckEmpty()
        {
            if ((NodeCollection != null && NodeCollection.Count > 0) ||
                (ConnectorCollection != null && ConnectorCollection.Count > 0) ||
                (GroupCollection != null && GroupCollection.Count > 0))
            {
                IsNonEmpty = true;
            }
            else
            {
                IsNonEmpty = false;
            }
        }

        private bool _mIsNonEmpty = false;

        public bool IsNonEmpty
        {
            get { return _mIsNonEmpty; }
            set
            {
                if (_mIsNonEmpty != value)
                {
                    _mIsNonEmpty = value;
                    OnPropertyChanged("IsNonEmpty");
                }
            }
        }

        public bool _mEnablePanZoom;
        public bool EnablePanZoom
        {
            get { return _mEnablePanZoom; }
            set
            {
                if (_mEnablePanZoom != value)
                {
                    _mEnablePanZoom = value;
                    OnPropertyChanged("EnablePanZoom");
                }
            }
        }

        public bool _mEnableSizePosition;
        public bool EnableSizePosition
        {
            get { return _mEnableSizePosition; }
            set
            {
                if (_mEnableSizePosition != value)
                {
                    _mEnableSizePosition = value;
                    OnPropertyChanged("EnableSizePosition");
                }
            }
        }

        private async void OnViewLoaded(object param)
        {
            IGraphInfo graph = Info as IGraphInfo;
            graph.ItemAdded += DiagramVM_ItemAdded;
            graph.ItemDeleted += DiagramVM_ItemDeleted;
            graph.SymbolDroppingEvent += graph_SymbolDroppingEvent;
            graph.GetDrawType += graph_GetDrawType;
            await Load();
            PageVM page = PageSettings as PageVM;
            if (_isValidXml)
            {
                graph.Commands.Zoom.Execute(
                   new ZoomPositionParamenter()
                   {
                       ZoomTo = page.Scale
                   });
                graph.ScrollInfo.PanTo(new Point(page.HOffset, page.VOffset));
            }
            //else
            //{
            //    await Save();
            //    (Info as IGraphInfo).Commands.FitToPage.Execute(
            //        new FitToPageParameter
            //        {
            //            FitToPage = FitToPage.FitToPage,
            //            Margin = new Thickness(20)
            //        }
            //        );
            //    this.Save();
            //}
            IsBusy = Visibility.Collapsed;
        }

        void graph_SymbolDroppingEvent(object sender, SymbolDroppingEventArgs args)
        {
            args.SymbolDropMode = SymbolDropMode.Drop;
        }

        void graph_GetDrawType(object sender, DrawTypeEventArgs args)
        {
            if (IsDrawTextNode)
            {
                args.DrawItem = new TextBox() { AcceptsReturn = true };
                (args.DrawItem as TextBox).Loaded += DiagramVM_Loaded;
                (args.DrawItem as TextBox).GotFocus += DiagramVM_GotFocus;
                (args.DrawItem as TextBox).LostFocus += DiagramVM_LostFocus;
            }
            else if (Shape.Equals("Rectangle"))
            {
                args.DrawItem = new System.Windows.Shapes.Rectangle() { RadiusX = 10, RadiusY = 10, StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White), Stretch = Stretch.Fill };
            }
            else if (Shape.Equals("Ellipse"))
            {
                args.DrawItem = new System.Windows.Shapes.Ellipse() { StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            //else if (this.Shape.Equals("Line"))
            //{
            //}
        }

        void DiagramVM_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            FrameworkElement parent = (FrameworkElement)textBox.Parent;
            (parent as INode).IsSelected = false;
            textBox.GotFocus += DiagramVM_GotFocus;
        }

        void DiagramVM_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            FrameworkElement parent = (FrameworkElement)textBox.Parent;
            while (parent != null && parent is IInputElement && !((IInputElement)parent).Focusable)
            {
                parent = (FrameworkElement)parent.Parent;
            }
            if (DrawingTool != Syncfusion.UI.Xaml.Diagram.DrawingTool.Node)
            {                
                (SelectedItems as SelectorVM).Clear();
                (parent as INode).IsSelected = true;
                parent.Focus();
                textBox.GotFocus -= DiagramVM_GotFocus;
            }
            else
            {
                (SelectedItems as SelectorVM).Clear();
                (parent as INode).IsSelected = true;
            }
        }

        void DiagramVM_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            FrameworkElement parent = (FrameworkElement)textBox.Parent;
            //(parent as INode).Annotations = null;
            foreach (LabelVM _mAnnotation in (parent as INode).Annotations as List<IAnnotation>)
            {
                _mAnnotation.PropertyChanged += (s, e1) =>
                {
                    if (e1.PropertyName == "Mode")
                    {
                        if ((s as LabelVM).Mode == ContentEditorMode.Edit)
                            (s as LabelVM).Mode = ContentEditorMode.View;
                    }
                };
            }
            textBox.Focus();
        } 

        public string Title
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        public FileInfo FileInfo 
        { 
            get 
            {
                return new FileInfo()
                {
                    FileName = GetFileName(),
                    Selected = IsSelected,
                    Title = Title
                };
            } 
        }

        private string _mComments = string.Empty;
        public string Comments
        {
            get { return _mComments; }
            set
            {
                if (_mComments != value)
                {
                    _mComments = value;
                    OnPropertyChanged("Comments");
                }
            }
        }
        

        public ObservableCollection<NodeVM> NodeCollection
        {
            get { return Nodes as ObservableCollection<NodeVM>; }
        }
        public ObservableCollection<ConnectorVM> ConnectorCollection
        {
            get { return Connectors as ObservableCollection<ConnectorVM>; }
        }
        public ObservableCollection<GroupVM> GroupCollection
        {
            get { return Groups as ObservableCollection<GroupVM>; }
        }

        public ICommand Select { get; set; }
        public ICommand FirstLoad { get; set; }
        public ICommand Export { get; set; }
        public ICommand ClearDiagram { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Draw { get; set; }
        public ICommand SingleSelect { get; set; }
        public ICommand SelectAll { get; set; }
        public ICommand Upload { get; set; }
        public ICommand Captures { get; set; }
        public ICommand Manipulate { get; set; }
        public ICommand LoadExt { get; set; }
        public ICommand AddImageNode { get; set; }
        public ICommand PageOrientationCommand { get; set; }
        public ICommand PageSizeCommand { get; set; }
        public ICommand ConnectTypeCommand { get; set; }
        public ICommand SizeandPositionCommand { get; set; }
        public ICommand PanZoomCommand { get; set; }

        private string _mShape = "Rectangle";
        public string Shape
        {
            get { return _mShape; }
            set
            {
                if (_mShape != value)
                {
                    _mShape = value;
                }
            }
        }

        private bool _mIsDrawTextNode = false;
        public bool IsDrawTextNode
        {
            get { return _mIsDrawTextNode; }
            set
            {
                if (_mIsDrawTextNode != value)
                {
                    _mIsDrawTextNode = value;
                }
            }
        }
        

        public Brush OffPageBackground
        {
            get { return _offPageBackground; }
            set
            {
                _offPageBackground = value;
                OnPropertyChanged("OffpageBackground");
            }
        }

        private async Task Load()
        {
            try
            {
                if (_isValidXml)
                {
                    IGraphInfo graph = Info as IGraphInfo;
                    //using (Stream stream = _file.OpenStreamForReadAsync().GetAwaiter().GetResult())
                    using (FileStream fileStream = File.OpenRead(_file))
                    {
                        graph.Load(fileStream);
                    }
                    (PageSettings as PageVM).InitDiagram();
                    (PageSettings as PageVM).InitDiagram(this);
                }
            }
            catch
            { }
        }

        public async Task Save()
        {
            //try
            //{
            IGraphInfo graph = Info as IGraphInfo;
            PageVM page = PageSettings as PageVM;
            if (graph != null && graph.ScrollInfo != null)
            {
                page.HOffset = graph.ScrollInfo.HorizontalOffset;
                page.VOffset = graph.ScrollInfo.VerticalOffset;
                page.Scale = graph.ScrollInfo.CurrentZoom;


                string pathString = System.IO.Path.Combine(installedLocation, "Shape_Shifter");
                DirectoryInfo DI = new DirectoryInfo(_file);
                string file = DI.Name;
                if (File.Exists(pathString + "/" + file.ToString()))
                {
                    File.Delete(pathString + "/" + file.ToString());
                }

                File.Create(pathString + "/" + file.ToString()).Close();
                _file = pathString + "/" + file.ToString();
                using (FileStream fileStream = File.OpenWrite(_file))
                {
                    graph.Save(fileStream);
                }
                _isValidXml = true;
            }
            //  }
            //catch
            //{ }
        }

        public async Task DeleteFile()
        {
            //try
            //{
            //    if (_file != null)
            //    {
            //        await _file.DeleteAsync();
            //    }
            //}
            //catch
            //{ }
        }

        public string GetFileName()
        {
            if (_file != null)
            {
                DirectoryInfo di = new DirectoryInfo(_file);
                return di.Name;
            }
            else
            {
                return string.Empty;
            }
        }

        public void OnExportCommand(object param)
        {
            //try
            //{
            //    string type = param as string;
            //    switch (type)
            //    {
            //        case "Png":
            //            SinglePageExporting(type, BitmapEncoder.PngEncoderId);
            //            break;
            //        case "Jpeg":
            //            SinglePageExporting(type, BitmapEncoder.JpegEncoderId);
            //            break;
            //        case "Tiff":
            //            SinglePageExporting(type, BitmapEncoder.TiffEncoderId);
            //            break;
            //        case "Gif":
            //            SinglePageExporting(type, BitmapEncoder.GifEncoderId);
            //            break;
            //        case "Bitmap":
            //            SinglePageExporting(type, BitmapEncoder.BmpEncoderId);
            //            break;
            //        case "JpegXR":
            //            SinglePageExporting(type, BitmapEncoder.JpegEncoderId);
            //            break;
            //    }
            //}
            //catch
            //{ }
        }

        private async void SinglePageExporting(string p, Guid guid)
        {
#if SyncfusionFramework4_5_1
            IGraphInfo graph = this.Info as IGraphInfo;
            if (graph != null)
            {
                var savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = "." + p;
                savePicker.FileTypeChoices.Add("." + p, new List<string> { "." + p });
                savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                savePicker.SuggestedFileName = Title;

                // Prompt the user to select a file
                var saveFile = await savePicker.PickSaveFileAsync();

                // Verify the user selected a file
                if (saveFile == null)
                    return;
                // Encode the image to the selected file on disk
                using (var fileStream = await saveFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    ExportSettings.ExportBitmapEncoder = await BitmapEncoder.CreateAsync(guid, fileStream);
                    //Method to Export the SfDiagram
                    await graph.Export();
                }
            } 
#endif
        }

        public void OnClearCommand(object param)
        {
            NodeCollection.Clear();
            ConnectorCollection.Clear();
            GroupCollection.Clear();
        }

       async private void Onuploadcommand(object obj)
        {
            //var picker = new FileOpenPicker();
            //picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            //picker.ViewMode = PickerViewMode.Thumbnail;
            //picker.FileTypeFilter.Add(".jpg");
            //picker.FileTypeFilter.Add(".jpeg");
            //var file = await picker.PickSingleFileAsync();
            //if (file == null) return;
            //var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //BitmapImage image = new BitmapImage();
            //image.SetSource(stream);           
            //IGraphInfo graph = this.Info as IGraphInfo;          
            //NodeVM node = new NodeVM();          
            //node.OffsetX = (graph.ScrollInfo.ViewportWidth) / 2;
            //node.OffsetY = (graph.ScrollInfo.ViewportHeight)/2;
            //node.UnitHeight = 100;
            //node.UnitWidth = 100;
            //node.Content = new Image() { Source = image,Stretch=Stretch.Fill};
            //(Nodes as ObservableCollection<NodeVM>).Add(node);           
            
        }
        async public void OnCapturesCommand(object param)
        {

            //var ui = new CameraCaptureUI();
            //var file = await ui.CaptureFileAsync(CameraCaptureUIMode.PhotoOrVideo);
            //if (file != null)
            //{
            //    IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //    BitmapImage bitmap = new BitmapImage();
            //    bitmap.SetSource(fileStream);
           
            //    IGraphInfo graph = this.Info as IGraphInfo;
            //    NodeVM node = new NodeVM();
            //    node.OffsetX = (graph.ScrollInfo.ViewportWidth) / 2;
            //    node.OffsetY = (graph.ScrollInfo.ViewportHeight) / 2;
            //    node.UnitHeight = 100;
            //    node.UnitWidth = 100;
            //    node.Content = new Image() { Source = bitmap, Stretch = Stretch.Fill };
            //    (Nodes as ObservableCollection<NodeVM>).Add(node);

            //}
        }
        public void OnDrawCommand(object param)
        {
            string type = param as string;
            switch (type)
            { 
                case "Straight":
                    DefaultConnectorType = ConnectorType.Line;
                    break;
                case "Ortho":
                    DefaultConnectorType = ConnectorType.Orthogonal;
                    break;
                case "Bezier":
                    DefaultConnectorType = ConnectorType.CubicBezier;
                    break;
                //case "FreeHand":
                //    DefaultConnectorType = ConnectorType.PolyCubicBezier;
                //    break;
            }
            Tool |= Tool.ContinuesDraw;
        }
        public void OnSingleSelectCommand(object param)
        {
            string type = param as string;

            if (type == "Node" && Nodes != null)
            {
                foreach (IConnector o in ConnectorsE)
                {
                    o.IsSelected = false;
                }

                foreach (INode o in NodesE)
                {
                    o.IsSelected = true;
                }
            }
            else if (type == "Connector" && ConnectorsE != null)
            {
                foreach (INode o in NodesE)
                {
                    o.IsSelected = false;
                }

                foreach (IConnector o in ConnectorsE)
                {
                    o.IsSelected = true;
                }
            }
        }
        public void OnSelectAllCommand(object param)
        {
            string type = param as string;

            if (type == "Node" && Nodes != null)
            {
                foreach (IConnector o in ConnectorsE)
                {
                    o.IsSelected = false;
                }

                foreach (INode o in NodesE)
                {
                    o.IsSelected = true;
                }
            }
            if (type == "Connector" && ConnectorsE != null)
            {
                foreach (INode o in NodesE)
                {
                    o.IsSelected = false;
                }

                foreach (IConnector o in ConnectorsE)
                {
                    o.IsSelected = true;
                }
            }
        }
        public void OnAddImageNodeCommand(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if(openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap=new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                double offX = ((Info as IGraphInfo).ScrollInfo.HorizontalOffset / (Info as IGraphInfo).ScrollInfo.CurrentZoom) + (Info as IGraphInfo).ScrollInfo.ViewportWidth / 2 - (bitmap.Width * (Info as IGraphInfo).ScrollInfo.CurrentZoom) / 2;
                double offY = ((Info as IGraphInfo).ScrollInfo.VerticalOffset / (Info as IGraphInfo).ScrollInfo.CurrentZoom) + (Info as IGraphInfo).ScrollInfo.ViewportHeight / 2 - (bitmap.Height * (Info as IGraphInfo).ScrollInfo.CurrentZoom) / 2;
                NodeVM nodevm = new NodeVM()
                {
                    OffsetX = offX,
                    OffsetY = offY,
                    Content = new Image() { Stretch = Stretch.Fill, Source = bitmap }
                };
                (Nodes as ObservableCollection<NodeVM>).Add(nodevm);
            }
        }
        private void OnPageOrientationCommand(object param)
        {
            if(param.ToString().Equals("Portrait"))
            {
                PageSettings.PageOrientation = PageOrientation.Portrait;
            }
            else if (param.ToString().Equals("Landscape"))
            {
                PageSettings.PageOrientation = PageOrientation.Landscape;
            }
        }
        private void OnPageSizeCommand(object param)
        {
            if (param.ToString().Equals("Letter"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.Letter;
            }
            else if (param.ToString().Equals("Folio"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.Folio;
            }
            else if (param.ToString().Equals("Legal"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.Legal;
            }
            else if (param.ToString().Equals("Ledger"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.Ledger;
            }
            else if (param.ToString().Equals("A5"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A5;
            }
            else if (param.ToString().Equals("A4"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A4;
            }
            else if (param.ToString().Equals("A3"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A3;
            }
            else if (param.ToString().Equals("A3"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A2;
            }
            else if (param.ToString().Equals("A2"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A2;
            }
            else if (param.ToString().Equals("A1"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A1;
            }
            else if (param.ToString().Equals("A0"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A0;
            }
        }

        private void OnConnectTypeCommand(object param)
        {
            if (param.ToString().Equals("Orthogonal"))
            {
                (SelectedItems as ISelectorVM).Type = ConnectType.Orthogonal;
            }
            else if (param.ToString().Equals("StraightLine"))
            {
                (SelectedItems as ISelectorVM).Type = ConnectType.Straight;
            }
            else if (param.ToString().Equals("CubicBezier"))
            {
                (SelectedItems as ISelectorVM).Type = ConnectType.Bezier;
            }
        }

        public void OnSizeandPositionCommand(object param)
        {           
            if (!EnableSizePosition)
            {
                EnableSizePosition = true;
            }
            else
            {
                EnableSizePosition = false;
            }
        }

        public void OnPanZoomCommand(object param)
        {
            if (!EnablePanZoom)
            {
                EnablePanZoom = true;
            }
            else
            {
                EnablePanZoom = false;
            }
        }

#if !SyncfusionFramework4_5_1
        public new object ExportSettings { get; set; }
        public new object PrintingService { get; set; }
#endif

        public IEnumerable ConnectorsE
        {
            get { return Connectors as IEnumerable; }
        }
        public IEnumerable NodesE
        {
            get { return Nodes as IEnumerable; }
        }
        public IEnumerable GroupsE
        {
            get { return Groups as IEnumerable; }
        }
    
    }


    public interface IDiagramViewModel : IGraph
    {
        ICommand Select { get; set; }
        ICommand FirstLoad { get; set; }
        string Title { get; set; }
        bool IsSelected { get; set; }
        bool EnablePanZoom { get; set; }
        ICommand Export { get; set; }
        ICommand ClearDiagram { get; set; }
        ICommand Delete { get; set; }
        ICommand Draw { get; set; }
        ICommand SingleSelect { get; set; }
        ICommand SelectAll { get; set; }
        ICommand Manipulate { get; set; }
        string Shape { get; set; }
        bool IsDrawTextNode { get; set; }
    }
}

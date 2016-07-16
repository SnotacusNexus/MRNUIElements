
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Diagram;
using System.Collections.Specialized;
using System.Windows.Input;
using Shape_Shifter.Utility;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Path = System.Windows.Shapes.Path;
using Microsoft.Win32;
using Shape_Shifter.Model;


namespace Shape_Shifter.ViewModel
{
    public class DiagramBuilderVM : DiagramElementViewModel, IDiagramBuilderVM
    {
        #region Fields
        List<Arrows> _mCaps = new List<Arrows>
        {
         new Arrows(){LineData="M0,0 z",HorizontalAlignment="Left",Angle=180,IsCap=false},
         new Arrows(){LineData="M0.511,0L5.099,4.734L0.511,9.468L0,8.941L4.077,4.734L0,0.527z",HorizontalAlignment="Left",Issourcecap=true,Angle=180,IsCap=false},
         new Arrows(){LineData="M0.511,0L5.099,4.734L0.511,9.468L0,8.941L4.077,4.734L0,0.527z",HorizontalAlignment="Right",Istargetcap=true,Angle=0,IsCap=false},
         new Arrows(){LineData="M0.511,0L5.099,4.734L0.511,9.468L0,8.941L4.077,4.734L0,0.527z",HorizontalAlignment="Left", Isbothcap=true,Angle=180,IsCap=true},
         new Arrows(){LineData="M0,0L7.583,3.792L0,7.583z",HorizontalAlignment="Left",Angle=180,Issourcecap=true,IsCap=false},
         new Arrows(){LineData="M0,0L7.583,3.792L0,7.583z",HorizontalAlignment="Right",Angle=0,Istargetcap=true,IsCap=false},
         new Arrows(){LineData="M0,0L7.583,3.792L0,7.583z",HorizontalAlignment="Left",Angle=180,Isbothcap=true,IsCap=true},
         new Arrows(){LineData="M4.333,0L8.667,4.333L4.333,8.666L0,4.333z",HorizontalAlignment="Left",Issourcecap=true,Angle=180,IsCap=false},
         new Arrows(){LineData="M4.333,0L8.667,4.333L4.333,8.666L0,4.333z",HorizontalAlignment="Right",Istargetcap=true,Angle=0,IsCap=false},
         new Arrows(){LineData="M4.333,0L8.667,4.333L4.333,8.666L0,4.333z",HorizontalAlignment="Left",Isbothcap=true,Angle=180,IsCap=true},
         new Arrows(){LineData="M3.25847,5.37642e-006C3.80781,0.00100555 4.36433,0.141591 4.87424,0.436245C6.42923,1.33324 6.96123,3.32022 6.06423,4.87521C5.75589,5.4094 5.31863,5.82282 4.8144,6.09894C3.85177,6.62609 2.64505,6.65285 1.62524,6.0642C0.0712487,5.16721 -0.461751,3.17923 0.436248,1.62524C0.534357,1.45527 0.645505,1.29752 0.7677,1.15252L0.779131,1.13929L0.82074,1.09115L0.847908,1.06127L0.875099,1.03136L0.917886,0.986597L0.930739,0.973151C1.54972,0.341551 2.39522,-0.00156644 3.25847,5.37642e-006z",HorizontalAlignment="Left",Issourcecap=true,Angle=180,IsCap=false},
         new Arrows(){LineData="M3.25847,5.37642e-006C3.80781,0.00100555 4.36433,0.141591 4.87424,0.436245C6.42923,1.33324 6.96123,3.32022 6.06423,4.87521C5.75589,5.4094 5.31863,5.82282 4.8144,6.09894C3.85177,6.62609 2.64505,6.65285 1.62524,6.0642C0.0712487,5.16721 -0.461751,3.17923 0.436248,1.62524C0.534357,1.45527 0.645505,1.29752 0.7677,1.15252L0.779131,1.13929L0.82074,1.09115L0.847908,1.06127L0.875099,1.03136L0.917886,0.986597L0.930739,0.973151C1.54972,0.341551 2.39522,-0.00156644 3.25847,5.37642e-006z",HorizontalAlignment="Right",Istargetcap=true,Angle=0,IsCap=false},
         new Arrows(){LineData="M3.25847,5.37642e-006C3.80781,0.00100555 4.36433,0.141591 4.87424,0.436245C6.42923,1.33324 6.96123,3.32022 6.06423,4.87521C5.75589,5.4094 5.31863,5.82282 4.8144,6.09894C3.85177,6.62609 2.64505,6.65285 1.62524,6.0642C0.0712487,5.16721 -0.461751,3.17923 0.436248,1.62524C0.534357,1.45527 0.645505,1.29752 0.7677,1.15252L0.779131,1.13929L0.82074,1.09115L0.847908,1.06127L0.875099,1.03136L0.917886,0.986597L0.930739,0.973151C1.54972,0.341551 2.39522,-0.00156644 3.25847,5.37642e-006z",HorizontalAlignment="Left",Isbothcap=true,Angle=180,IsCap=true},
         new Arrows(){LineData="M0,0L9.75,3.983L1.74344e-006,8.125L3.837,4.063z",HorizontalAlignment="Left",Issourcecap=true,Angle=180,IsCap=false},
         new Arrows(){LineData="M0,0L9.75,3.983L1.74344e-006,8.125L3.837,4.063z",HorizontalAlignment="Right",Istargetcap=true,Angle=0,IsCap=false},
         new Arrows(){LineData="M0,0L9.75,3.983L1.74344e-006,8.125L3.837,4.063z",HorizontalAlignment="Left",Isbothcap=true,Angle=180,IsCap=true},
         new Arrows(){LineData="M0.365001,0L4.0625,3.69703L7.76,1.21072e-006L8.125,0.365999L4.42826,4.06274L8.125,7.759L7.759,8.125L4.0625,4.4285L0.365999,8.125L0,7.759L3.69674,4.06274L0,0.365999z",HorizontalAlignment="Left",Issourcecap=true,Angle=180,IsCap=false},
         new Arrows(){LineData="M0.365001,0L4.0625,3.69703L7.76,1.21072e-006L8.125,0.365999L4.42826,4.06274L8.125,7.759L7.759,8.125L4.0625,4.4285L0.365999,8.125L0,7.759L3.69674,4.06274L0,0.365999z",HorizontalAlignment="Right",Istargetcap=true,Angle=0,IsCap=false},
         new Arrows(){LineData="M0.365001,0L4.0625,3.69703L7.76,1.21072e-006L8.125,0.365999L4.42826,4.06274L8.125,7.759L7.759,8.125L4.0625,4.4285L0.365999,8.125L0,7.759L3.69674,4.06274L0,0.365999z",HorizontalAlignment="Left",Isbothcap=true,Angle=180,IsCap=true},
        };
        private List<string> _mToolTipConstraints = new List<string>
        {
            "None",
            "Position",
            "Size",
            "Angle",
            "Default"
        };
        Visibility _mEditorVisbility { get; set; }
        Visibility _mEditorPickerVisibility { get; set; }
        private bool _mDrawConnector = false;
        private bool _mPortVisible = false;
        private bool _mPointerTool = true;
        private bool _mDrawTextNode = false;
        string installedLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private DiagramVM _selectedDiagram;
        private IPropertyEditor _mSelectedEditor = null;
        private List<PageSize> _mFormat = new List<PageSize>
        {
            PageSize.Letter,
            PageSize.Folio,
            PageSize.Legal,
            PageSize.Ledger,

            PageSize.A5,
            PageSize.A4,
            PageSize.A3,
            PageSize.A2,
            PageSize.A1,
            PageSize.A0,

            PageSize.Custom
        };
        private List<PageOrientation> _mOrientations = new List<PageOrientation>
        {
            PageOrientation.Landscape,
            PageOrientation.Portrait
        };
        private List<LengthUnits> _mUnits = new List<LengthUnits>
        {
            LengthUnits.Inches,
            LengthUnits.Feets,
            LengthUnits.Yards,
            LengthUnits.Millimeters,
            LengthUnits.Centimeters,
            LengthUnits.Meters,
            LengthUnits.Pixels,
        };
        private List<ConnectType> _mTypes = new List<ConnectType>
        {
            ConnectType.Straight,
            ConnectType.Orthogonal,
            ConnectType.Bezier
        };
        private static List<FontFamily> _mFonts = new List<FontFamily> { 
            new FontFamily("Segoe UI"),
            new FontFamily("Calibri"),
            new FontFamily("Arial"),
            new FontFamily("Comic Sans MS"),
            new FontFamily("Georgia"),
            new FontFamily("Times New Roman")
        };
        List<string> _mDashDots = new List<string> 
                                    { 
                                        "1,0",
                                       "18,6",
                                       "3,1",
                                       "2,2",
                                       "7,1,4,1",
                                      "3,1,3,2,1,2",
                                      "1,2"

                                    };
        #endregion

        #region Diagrams

        public DiagramBuilderVM()
        {

            New = new Command(OnNewCommand);
            Import = new Command(OnImportCommand);
            Export = new Command(OnExportCommand);
            Save = new Command(OnSaveCommand);
            SaveAll = new Command(OnSaveAllCommand);
            Delete = new Command(OnDeleteCommand);
            Print = new Command(OnPrintCommand);
            ZoomIn = new Command(OnZoomInCommand);
            ZoomOut = new Command(OnZoomOutCommand);
            Zoom1 = new Command(OnZoomCommand);
            Exit = new Command(OnExitCommand);
            Duplicate = new Command(OnDuplicateCommand);
            Open = new Command(OnOpenCommand);
            QuickStyle = new Command(OnQuickCommand);
            SaveAs = new Command(OnSaveAsCommand);
            Draw = new Command(OnDrawCommand);
            Stencil = new StencilVM();
            Diagrams = new ObservableCollection<DiagramVM>();


            Copy = new Command(OnCopyCommand);
            Cut = new Command(OnCutCommand);
            Paste = new Command(OnPasteCommand);
            //Diagrams.Add(new DiagramVM(false));
            //SelectedDiagram = Diagrams[0];

            LoadDiagram();
            //Diagrams.Add(GetNewDiagramVM());
            //SelectedDiagram = Diagrams[0];

            DiagramCommandsVM = new DiagramCommandsViewModel(this);
#if !SyncfusionFramework4_5_1
            Framework = Visibility.Collapsed;
#else
            Framework = Visibility.Visible; 
#endif
            Stencil.PropertyChanged += Stencil_PropertyChanged;
            PropertyPanelVM();
        }

        private void OnQuickCommand(object obj)
        {
            string name = obj.ToString() + "Style";
            Style s = Application.Current.Resources[name] as Style;
            if ((SelectedDiagram.SelectedItems as ISelectorVM).IsNodeSelected)
            {
                Style stye = new Style();
                stye.TargetType = typeof(Path);
                foreach (Setter set in s.Setters)
                {
                    if (set.Property == Path.FillProperty)
                    {
                        stye.Setters.Add(new Setter(Path.FillProperty, (Brush)set.Value));
                    }
                    else if (set.Property == Path.StrokeProperty)
                    {
                        stye.Setters.Add(new Setter(Path.StrokeProperty, (Brush)set.Value));
                    }
                    else if (set.Property == Path.StrokeThicknessProperty)
                    {
                        stye.Setters.Add(new Setter(Path.StrokeThicknessProperty, (double)set.Value));
                    }
                    else if (set.Property == FrameworkElement.TagProperty)
                    {
                        var converter = new System.Windows.Media.BrushConverter();
                        var brush = (Brush)converter.ConvertFromString(set.Value.ToString());
                        (SelectedDiagram.SelectedItems as ISelectorVM).LabelForeground = brush;
                    }

                }
                (SelectedDiagram.SelectedItems as ISelectorVM).Style = stye;
            }
            else if ((SelectedDiagram.SelectedItems as ISelectorVM).IsConnectorSelected)
            {
                Style stye = new Style();
                stye.TargetType = typeof(Path);
                foreach (Setter set in s.Setters)
                {
                    if (set.Property == Path.StrokeProperty)
                    {
                        stye.Setters.Add(new Setter(Path.StrokeProperty, (Brush)set.Value));
                    }
                    else if (set.Property == Path.StrokeThicknessProperty)
                    {
                        stye.Setters.Add(new Setter(Path.StrokeThicknessProperty, (double)set.Value));
                    }
                    else if (set.Property == Path.StrokeDashArrayProperty)
                    {
                        stye.Setters.Add(new Setter(Path.StrokeDashArrayProperty, set.Value));
                    }
                }
                (SelectedDiagram.SelectedItems as ISelectorVM).Style = stye;
            }

        }


        private async void OnExitCommand(object obj)
        {
            await SaveAllDiagrams();
        }

        void Stencil_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedSymbol")
            {
                if ((sender as StencilVM).SelectedSymbol != null)
                {
                    (sender as StencilVM).SelectedSymbol.MouseDoubleClick += SelectedSymbol_MouseDoubleClick;
                }
            }
        }

        void SelectedSymbol_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (this.SelectedDiagram.SelectedItems != null && ((this.SelectedDiagram.SelectedItems as SelectorVM).Nodes as ICollection<object>).Count > 0)
            //{
            //    ((this.SelectedDiagram.SelectedItems as SelectorVM).Nodes as ICollection<object>).Clear();
            //}
            //NodeVM node = new NodeVM();
            //IGraphInfo graph = this.SelectedDiagram.Info as IGraphInfo;
            //node.OffsetX = (graph.ScrollInfo.ViewportWidth) / 2;
            //node.OffsetY = (graph.ScrollInfo.ViewportHeight) / 2;
            //node.UnitWidth = 100;
            //node.UnitHeight = 100;
            //node.Content = Stencil.SelectedSymbol.Content;
            //node.ContentTemplate = Stencil.SelectedSymbol.ContentTemplate;
            //node.IsSelected = true;
            //this.SelectedDiagram.NodeCollection.Add(node);
            //e.Handled = true;
        }

        ////public static readonly string DefaultLogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        private DiagramVM GetNewDiagramVM(string file, bool isValidXml)
        {
            DiagramVM diagram = new DiagramVM(file, isValidXml) { Title = "Page" };
            diagram.Delete = Delete;
            diagram.PropertyChanged += (s, e) =>
                {
                    DiagramVM sender = s as DiagramVM;
                    if (e.PropertyName == "IsSelected")
                    {
                        if (sender.IsSelected == true)
                        {
                            this.SelectedDiagram = sender;
                        }
                    }
                };
            return diagram;
        }


        private DiagramCommandsViewModel _viewmodel;

        public DiagramCommandsViewModel DiagramCommandsVM
        {
            get
            {
                return _viewmodel;
            }
            set
            {
                if (_viewmodel != value)
                {
                    _viewmodel = value;
                }
            }
        }
        public DiagramVM SelectedDiagram
        {
            get { return _selectedDiagram; }
            set
            {
                var old = _selectedDiagram;
                if (_selectedDiagram != value)
                {
                    if (_selectedDiagram != null)
                    {
                        _selectedDiagram.IsSelected = false;
                    }
                    _selectedDiagram = value;
                    if (_selectedDiagram != null)
                    {
                        _selectedDiagram.IsSelected = true;
                    }
                    OnPropertyChanged("SelectedDiagram");
                }
                //if (_selectedDiagram == null && SelectedDiagram != old)
                //{
                //    SelectedDiagram = old;
                //}
            }
        }
        public ObservableCollection<DiagramVM> Diagrams { get; set; }

        #endregion

        #region PropertyPanel

        private void PropertyPanelVM()
        {
            Editors = new ObservableCollection<IPropertyEditor>();
            Editors.CollectionChanged += Editors_CollectionChanged;
            SelectEditor = new Command(OnSelectEditorCommand);
            EditorPicker = new Command(OnEditorPickerCommand);
            EditorVisbility = Visibility.Visible;
            EditorPickerVisibility = Visibility.Visible;
        }

        void Editors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (IPropertyEditor item in e.NewItems)
                {
                    item.PropertyChanged += (src, evt) =>
                        {
                            if (item.IsSelected)
                            {
                                SelectedEditor = item;
                            }
                        };
                    if (item.IsSelected)
                    {
                        SelectedEditor = item;
                    }
                }
            }
        }

        public StencilVM Stencil { get; set; }
        public ObservableCollection<IPropertyEditor> Editors { get; set; }
        public IPropertyEditor SelectedEditor
        {
            get
            {
                return _mSelectedEditor;
            }
            set
            {
                if (_mSelectedEditor != value)
                {
                    if (_mSelectedEditor != null)
                    {
                        _mSelectedEditor.IsSelected = false;
                    }
                    _mSelectedEditor = value;
                    if (_mSelectedEditor != null)
                    {
                        _mSelectedEditor.IsSelected = true;
                    }
                    OnPropertyChanged("SelectedEditor");
                    if (SelectedDiagram != null)
                    {
                        DiagramVM diagram = SelectedDiagram as DiagramVM;
                        SelectorVM sel = diagram.SelectedItems as SelectorVM;
                        sel.IsBrushEditing = Visibility.Collapsed;
                    }
                }
            }
        }

        private Visibility _mPanelVisibility = Visibility.Visible;
        private Visibility _mPanelPickerVisibility = Visibility.Visible;

        public Visibility PanelVisibility
        {
            get
            {
                return _mPanelVisibility;
            }
            set
            {
                if (_mPanelVisibility != value)
                {
                    _mPanelVisibility = value;
                    OnPropertyChanged("PanelVisibility");
                }
            }
        }

        public Visibility PanelPickerVisibility
        {
            get
            {
                return _mPanelPickerVisibility;
            }
            set
            {
                if (_mPanelPickerVisibility != value)
                {
                    _mPanelPickerVisibility = value;
                    OnPropertyChanged("PanelPickerVisibility");
                }
            }
        }

        #endregion

        #region Options

        public List<string> ToolTipConstraints
        {
            get
            {
                return _mToolTipConstraints;
            }
            set
            {
                if (_mToolTipConstraints != value)
                {
                    _mToolTipConstraints = value;
                }
            }
        }

        public List<Arrows> Caps
        {
            get
            {
                return _mCaps;
            }
            set
            {
                if (_mCaps != value)
                {
                    _mCaps = value;
                    OnPropertyChanged(ConnectorConstants.Caps);
                }
            }
        }
        public List<ConnectType> Types
        {
            get
            {
                return _mTypes;
            }
            set
            {
                if (_mTypes != value)
                {
                    _mTypes = value;
                    OnPropertyChanged(ConnectorConstants.Type);
                }
            }
        }
        public static List<FontFamily> Fonts
        {
            get
            {
                return _mFonts;
            }
            set
            {
                if (_mFonts != value)
                {
                    _mFonts = value;
                }
            }
        }
        public List<PageSize> Format
        {
            get
            {
                return _mFormat;
            }
            set
            {
                if (_mFormat != value)
                {
                    _mFormat = value;
                    OnPropertyChanged(PageConstants.Format);
                }
            }
        }
        public List<PageOrientation> Orientations
        {
            get
            {
                return _mOrientations;
            }
            set
            {
                if (_mOrientations != value)
                {
                    _mOrientations = value;
                    OnPropertyChanged(PageConstants.Orientations);
                }
            }
        }
        public List<LengthUnits> Units
        {
            get
            {
                return _mUnits;
            }
            set
            {
                if (_mUnits != value)
                {
                    _mUnits = value;
                    OnPropertyChanged(PageConstants.Units);
                }
            }
        }
        public List<string> DashDots { get { return _mDashDots; } }
        public Visibility EditorVisbility
        {
            get
            {
                return _mEditorVisbility;
            }
            set
            {
                if (_mEditorVisbility != value)
                {
                    _mEditorVisbility = value;
                    OnPropertyChanged("EditorVisbility");
                }
            }
        }
        public Visibility EditorPickerVisibility
        {
            get
            {
                return _mEditorPickerVisibility;
            }
            set
            {
                if (_mEditorPickerVisibility != value)
                {
                    _mEditorPickerVisibility = value;
                    OnPropertyChanged("EditorPickerVisibility");
                }
            }
        }

        public bool PointerTool
        {
            get { return _mPointerTool; }
            set
            {
                if (_mPointerTool != value)
                {
                    _mPointerTool = value;
                    OnPropertyChanged("PointerTool");
                }
            }
        }

        public bool DrawConnector
        {
            get { return _mDrawConnector; }
            set
            {
                if (_mDrawConnector != value)
                {
                    _mDrawConnector = value;
                    OnPropertyChanged("DrawConnector");
                }
            }
        }

        public bool PortVisible
        {
            get { return _mPortVisible; }
            set
            {
                if (_mPortVisible != value)
                {
                    _mPortVisible = value;
                    OnPropertyChanged("PortVisible");
                }
            }
        }

        public bool DrawTextNode
        {
            get { return _mDrawTextNode; }
            set
            {
                if (_mDrawTextNode != value)
                {
                    _mDrawTextNode = value;
                    OnPropertyChanged("DrawTextNode");
                }
            }
        }

        private bool _mIsDrawingToolEnable;
        public bool IsDrawingToolEnable
        {
            get { return _mIsDrawingToolEnable; }
            set
            {
                if (_mIsDrawingToolEnable != value)
                {
                    _mIsDrawingToolEnable = value;
                    OnPropertyChanged("IsDrawingToolEnable");
                }
            }
        }


        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {
                case "DrawConnector":
                    OnDrawConnectorChanged();
                    break;
                case "PortVisible":
                    OnPortVisibleChanged();
                    break;
                case "PointerTool":
                    OnPointerToolChanged();
                    break;
                case "DrawTextNode":
                    OnDrawTextNodeChanged();
                    break;
                case "IsDrawingToolEnable":
                    IsDrawingToolEnableChanged();
                    break;

            }
        }

        private void OnPointerToolChanged()
        {
            if (PointerTool)
            {
                foreach (DiagramVM diagram in Diagrams)
                {
                    diagram.DrawingTool = DrawingTool.None;
                    diagram.Tool = Tool.MultipleSelect;
                }
                DrawConnector = false;
                DrawTextNode = false;
                IsDrawingToolEnable = false;
            }
        }

        private void OnDrawConnectorChanged()
        {
            if (DrawConnector)
            {
                foreach (DiagramVM diagram in Diagrams)
                {
                    diagram.DrawingTool = DrawingTool.Connector;
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DefaultConnectorType = ConnectorType.Orthogonal;
                }
                PointerTool = false;
                DrawTextNode = false;
                IsDrawingToolEnable = false;
            }
            else if (!DrawTextNode && !IsDrawingToolEnable)
            {
                PointerTool = true;
            }
        }

        private void OnPortVisibleChanged()
        {
            if (PortVisible)
            {
                SelectedDiagram.PortVisibility = PortVisibility.Visible;
            }
            else
            {
                SelectedDiagram.PortVisibility = PortVisibility.Collapse;
            }
        }

        private void OnDrawTextNodeChanged()
        {
            if (DrawTextNode)
            {
                foreach (DiagramVM diagram in Diagrams)
                {
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Node;
                    diagram.IsDrawTextNode = true;
                }
                PointerTool = false;
                DrawConnector = false;
                IsDrawingToolEnable = false;
            }
            else if (!DrawConnector && !IsDrawingToolEnable)
            {
                PointerTool = true;
            }
        }

        private void IsDrawingToolEnableChanged()
        {
            if (IsDrawingToolEnable)
            {
                foreach (var diagram in Diagrams)
                {
                    if (diagram.Shape.Equals("Line"))
                    {
                        diagram.Tool = Tool.ContinuesDraw;
                        diagram.DrawingTool = DrawingTool.Connector;
                        diagram.IsDrawTextNode = false;
                        diagram.DefaultConnectorType = ConnectorType.Line;
                    }
                    else
                    {
                        diagram.Tool = Tool.ContinuesDraw;
                        diagram.DrawingTool = DrawingTool.Node;
                        diagram.IsDrawTextNode = false;
                    }
                }
                PointerTool = false;
                DrawTextNode = false;
                DrawConnector = false;
            }
            else if (!DrawTextNode && !DrawConnector)
            {
                PointerTool = true;
            }
        }

        private void OnDrawCommand(object param)
        {
            IsDrawingToolEnable = true;
            foreach (var diagram in Diagrams)
            {
                if (param.ToString().Equals("Line"))
                {
                    SmallIcon = ICons.DrawingTool_StraightLine.ToImageSource();
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Connector;
                    diagram.DefaultConnectorType = ConnectorType.Line;
                    diagram.IsDrawTextNode = false;
                    diagram.Shape = param.ToString();
                }
                else
                {
                    if (param.ToString().Equals("Rectangle"))
                        SmallIcon = ICons.DrawingTool_Rectangle.ToImageSource();
                    else if (param.ToString().Equals("Ellipse"))
                        SmallIcon = ICons.DrawingTool_Ellipse.ToImageSource();
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Node;
                    diagram.IsDrawTextNode = false;
                    diagram.Shape = param.ToString();
                }
            }
        }
        #endregion

        #region Commands

        public ICommand Bold
        {
            get;
            set;
        }

        public ICommand New
        {
            get;
            set;
        }

        public ICommand Save
        {
            get;
            set;
        }

        public ICommand SaveAs
        {
            get;
            set;
        }

        public ICommand SaveAll
        {
            get;
            set;
        }

        public ICommand Import
        {
            get;
            set;
        }

        public ICommand Delete { get; set; }

        public ICommand Export
        {
            get;
            set;
        }

        public ICommand Print
        {
            get;
            set;
        }

        public ICommand SelectEditor
        {
            get;
            set;
        }



        public ICommand EditorPicker { get; set; }

        public ICommand Exit { get; set; }
        public ICommand ZoomIn { get; set; }
        public ICommand ZoomOut { get; set; }
        public ICommand Zoom1 { get; set; }
        public ICommand Duplicate
        {
            get;
            set;
        }
        public ICommand Open { get; set; }

        public ICommand QuickStyle { get; set; }

        public async void OnDuplicateCommand(object param)
        {

            //StorageFile s = null;
            DiagramVM newDiagram = null;
            string parameter = Guid.NewGuid().ToString("N");
            string pathString = System.IO.Path.Combine(installedLocation, "Shape_Shifter");
            string file = parameter.ToString() + ".xml";
            System.IO.File.Create(file).Close();

            IGraphInfo graph = SelectedDiagram.Info as IGraphInfo;
            PageVM page = SelectedDiagram.PageSettings as PageVM;
            if (graph != null && graph.ScrollInfo != null)
            {
                page.HOffset = graph.ScrollInfo.HorizontalOffset;
                page.VOffset = graph.ScrollInfo.VerticalOffset;
                page.Scale = graph.ScrollInfo.CurrentZoom;

                using (FileStream fileStream = File.OpenWrite(file))
                {
                    graph.Save(fileStream);
                }
                newDiagram = new DiagramVM(file, true);

                Diagrams.Add(newDiagram);
                SelectedDiagram = newDiagram;
                newDiagram.PropertyChanged += (diagram, e) =>
                {
                    DiagramVM sender = diagram as DiagramVM;
                    if (e.PropertyName == "IsSelected")
                    {
                        if (sender.IsSelected == true)
                        {
                            this.SelectedDiagram = sender;
                        }
                    }
                };
                await SaveFileIndex();
            }
        }

        public void OnOpenCommand(object param)
        {
            OpenFileDialog openDialogBox = new OpenFileDialog();
            openDialogBox.Title = "Load";
            if (openDialogBox.ShowDialog() == true)
            {
                (this.SelectedDiagram.Nodes as ObservableCollection<NodeVM>).Clear();
                (this.SelectedDiagram.Connectors as ObservableCollection<ConnectorVM>).Clear();
                (this.SelectedDiagram.Groups as ObservableCollection<GroupVM>).Clear();
                IGraphInfo graph = this.SelectedDiagram.Info as IGraphInfo;

                using (Stream stream = openDialogBox.OpenFile())
                {
                    graph.Load(stream);
                }
                (this.SelectedDiagram.PageSettings as PageVM).InitDiagram();
                (this.SelectedDiagram.PageSettings as PageVM).InitDiagram(this.SelectedDiagram);
            }
        }

        public async void OnNewCommand(object param)
        {
            //StorageFile s = null;
            string parameter = Guid.NewGuid().ToString("N");
            string pathString = System.IO.Path.Combine(installedLocation, "Shape_Shifter");
            string file = parameter.ToString() + ".xml";
            string path = pathString + "/" + file;
            System.IO.File.Create(path);
            if (file != null)
            {
                DiagramVM newDiagram = GetNewDiagramVM(file, false);
                Diagrams.Add(newDiagram);
                SelectedDiagram = newDiagram;
            }
            await SaveFileIndex();
        }

        //private bool EnsureUnsnapped()
        //{
        //    bool unsnapped = ((ApplicationView.Value != ApplicationViewState.Snapped) || ApplicationView.TryUnsnap());
        //    if (!unsnapped)
        //    {
        //        //NotifyUser("Cannot unsnap the sample.", NotifyType.StatusMessage);
        //    }
        //    return unsnapped;
        //}

        public async void OnSaveCommand(object param)
        {
            await SelectedDiagram.Save();
            await SaveFileIndex();
        }

        public void OnSaveAsCommand(object param)
        {
            SaveFileDialog saveAsFileDialog = new SaveFileDialog() { Title = "Save As", DefaultExt = ".xml" };
            saveAsFileDialog.Filter = "Text file (*.xml)|*.xml";
            if (saveAsFileDialog.ShowDialog() == true)
            {
                IGraphInfo graph = this.SelectedDiagram.Info as IGraphInfo;
                PageVM page = this.SelectedDiagram.PageSettings as PageVM;
                page.Scale = graph.ScrollInfo.CurrentZoom;
                using (Stream fileStream = saveAsFileDialog.OpenFile())
                {
                    graph.Save(fileStream);
                }
            }
        }

        public async void OnDeleteCommand(object param)
        {
            DiagramVM diag = param as DiagramVM;
            int index = Diagrams.IndexOf(diag);
            Diagrams.Remove(diag);
            if (diag.IsSelected && Diagrams.Count > 0)
            {
                if (Diagrams.Count == index)
                {
                    Diagrams[index - 1].IsSelected = true;
                }
                else if (Diagrams.Count > index)
                {
                    Diagrams[index].IsSelected = true;
                }
            }
            await SaveFileIndex();
            if (Diagrams.Count == 0)
            {
                Exit.Execute(null);
            }
        }

        public async void OnSaveAllCommand(object param)
        {
            await SaveAllDiagrams();
        }


        public void OnImportCommand(object param)
        {

        }

        public void OnExportCommand(object param)
        {
            SelectedDiagram.Export.Execute(param);
        }

        public void OnPrintCommand(object param)
        {
#if SyncfusionFramework4_5_1
            PageVM page = SelectedDiagram.PageSettings as PageVM;

            PrintingService print = SelectedDiagram.PrintingService;
            print.PrintMargin = page.PrintMargin;
            switch (page.SelectedFormat)
            {
                case PageSize.A0:
                    print.PrintMediaSize = PrintMediaSize.IsoA0;
                    break;
                case PageSize.A1:
                    print.PrintMediaSize = PrintMediaSize.IsoA1;
                    break;
                case PageSize.A2:
                    print.PrintMediaSize = PrintMediaSize.IsoA2;
                    break;
                case PageSize.A3:
                    print.PrintMediaSize = PrintMediaSize.IsoA3;
                    break;
                case PageSize.A4:
                    print.PrintMediaSize = PrintMediaSize.IsoA4;
                    break;
                case PageSize.A5:
                    print.PrintMediaSize = PrintMediaSize.IsoA5;
                    break;
                case PageSize.Folio:
                    print.PrintMediaSize = PrintMediaSize.OtherMetricFolio;
                    break;
                case PageSize.Ledger:
                    print.PrintMediaSize = PrintMediaSize.NorthAmericaTabloid;
                    break;
                case PageSize.Legal:
                    print.PrintMediaSize = PrintMediaSize.NorthAmericaLegal;
                    break;
                case PageSize.Letter:
                    print.PrintMediaSize = PrintMediaSize.NorthAmericaLetter;
                    break;
            }
            if (page.PageOrientation == PageOrientation.Landscape)
            {
                print.PrintOrientation = PrintOrientation.Landscape;
            }
            else
            {
                print.PrintOrientation = PrintOrientation.Portrait;
            }

            print.UnregisterForPrinting();
             print.RegisterForPrinting();
            //await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync(); 
#endif
        }

        public void OnSelectEditorCommand(object param)
        {
            string type = param as string;
            switch (type)
            {
                case "Show":
                    EditorVisbility = Visibility.Visible;
                    break;
                case "Arrange":
                    SelectedEditor = Editors.FirstOrDefault(edit => edit.Title == type);
                    EditorVisbility = Visibility.Visible;
                    break;
                case "Property":
                    SelectedEditor = Editors.FirstOrDefault(edit => edit.Title == type);
                    EditorVisbility = Visibility.Visible;
                    break;
                case "Text":
                    SelectedEditor = Editors.FirstOrDefault(edit => edit.Title == type);
                    EditorVisbility = Visibility.Visible;
                    break;
                case "Stencil":
                    SelectedEditor = Editors.FirstOrDefault(edit => edit.Title == type);
                    EditorVisbility = Visibility.Visible;
                    break;
                case "Page":
                    SelectedEditor = Editors.FirstOrDefault(edit => edit.Title == type);
                    EditorVisbility = Visibility.Visible;
                    break;
                case "Hide":
                    EditorVisbility = Visibility.Collapsed;
                    break;
                case "Toggle":
                    if (EditorVisbility == Visibility.Collapsed)
                    {
                        EditorVisbility = Visibility.Visible;
                    }
                    else
                    {
                        EditorVisbility = Visibility.Collapsed;
                    }
                    break;
            }
        }

        public void OnEditorPickerCommand(object param)
        {
            string type = param as string;
            switch (type)
            {
                case "Current":
                    EditorPickerVisibility = Visibility.Visible;
                    break;
                case "Toggle":
                    if (EditorPickerVisibility == Visibility.Collapsed)
                    {
                        EditorPickerVisibility = Visibility.Visible;
                    }
                    else
                    {
                        EditorPickerVisibility = Visibility.Collapsed;
                    }
                    break;
            }
        }

        public async void LoadDiagram()
        {
            try
            {
                string pathString = System.IO.Path.Combine(installedLocation, "Shape_Shifter");
                if (!Directory.Exists(pathString))
                {
                    //Directory.Delete(pathString, true);
                    Directory.CreateDirectory(pathString);
                }

                List<string> files = Directory.GetFiles(pathString).ToList();
                string indexFile = string.Empty;
                foreach (string f in files)
                {
                    DirectoryInfo di = new DirectoryInfo(f);
                    if (di.Name == "index.xml")
                    {
                        indexFile = f;
                        break;
                    }
                }
                if (indexFile != null)
                {
                    XmlSerializer deSerializer = new XmlSerializer(typeof(List<FileInfo>), new Type[] { typeof(FileInfo) });
                    List<FileInfo> fileIndex = null;
                    using (FileStream fileStream = File.OpenWrite(pathString + "/" + indexFile.ToString() + ".xml"))
                    {
                        fileIndex = deSerializer.Deserialize(fileStream) as List<FileInfo>;
                    }

                    foreach (FileInfo fileInfo in fileIndex.OrderBy(e => e.Index))
                    {

                        foreach (string f in files)
                        {
                            DirectoryInfo di = new DirectoryInfo(f);
                            if (di.Name == fileInfo.FileName)
                            {
                                continue;
                            }
                        }
                        //if (!files.Any(f => f.Name == fileInfo.FileName))
                        //{
                        //    continue;
                        //}
                        string file = fileInfo.FileName;
                        DiagramVM newdiagram = GetNewDiagramVM(file, true);
                        newdiagram.IsSelected = fileInfo.Selected;
                        newdiagram.Title = fileInfo.Title;
                        Diagrams.Add(newdiagram);
                    }
                }
            }
            catch
            {
            }
            if (Diagrams.Count == 0)
            {
                OnNewCommand(null);
            }
            //else
            //{
            //    SelectedDiagram = Diagrams[0];
            //}
        }
        public void OnZoomInCommand(object param)
        {
            (SelectedDiagram.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParamenter() { ZoomFactor = 0.2, ZoomCommand = ZoomCommand.ZoomIn });


        }
        public void OnZoomOutCommand(object param)
        {
            (SelectedDiagram.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParamenter() { ZoomFactor = 0.2, ZoomCommand = ZoomCommand.ZoomOut });
        }
        public void OnZoomCommand(object param)
        {

            if (param != null)
            {
                if (IsDigitsOnly(param.ToString()) && param.ToString()!="")
                {
                    double _mZoomvalue = Convert.ToDouble(param) / 100;
                    (SelectedDiagram.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParamenter() { ZoomTo = _mZoomvalue, ZoomCommand = ZoomCommand.Zoom });
                }
                else if (param.ToString() == "Page")
                {
                    (SelectedDiagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToPage });
                }
                else if (param.ToString() == "Width")
                {
                    (SelectedDiagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToWidth });

                }
            }

        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private string indexFile;
        private async Task SaveFileIndex()
        {
            if (indexFile != null)
            {
                return;
            }
            List<FileInfo> fileIndex = new List<FileInfo>();
            int i = 0;
            foreach (var diagram in Diagrams)
            {
                FileInfo info = new FileInfo()
                {
                    FileName = diagram.GetFileName(),
                    Index = i++,
                    Selected = SelectedDiagram == diagram,
                    Title = diagram.Title
                };
                fileIndex.Add(info);
            }
            try
            {

                string pathString = System.IO.Path.Combine(installedLocation, "Shape_Shifter");

                string file = "index.xml";
                if (File.Exists(pathString + "/" + file.ToString() + ".xml"))
                {
                    File.Delete(pathString + "/" + file.ToString() + ".xml");
                }

                File.Create(pathString + "/" + file.ToString() + ".xml").Close();

                XmlSerializer serializer = new XmlSerializer(typeof(List<FileInfo>), new Type[] { typeof(FileInfo) });
                using (FileStream filestream = File.OpenWrite(pathString + "/" + file.ToString() + ".xml"))
                {
                    serializer.Serialize(filestream, fileIndex);
                }
            }
            //catch { }
            finally
            {
                indexFile = null;
            }
        }

        private async Task SaveAllDiagrams()
        {
            foreach (var diagram in Diagrams)
            {
                await diagram.Save();
            }
        }

        public async Task PrepareExit()
        {
            await SaveAllDiagrams();
            await SaveFileIndex();
        }



        public ICommand Copy
        {
            get;
            set;
        }

        public ICommand Cut
        {
            get;
            set;
        }

        public ICommand Paste
        {
            get;
            set;
        }
        public ICommand Draw { get; set; }
        private void OnPasteCommand(object obj)
        {
            (SelectedDiagram.Info as IGraphInfo).Commands.Paste.Execute(null);
        }

        private void OnCutCommand(object obj)
        {
            (SelectedDiagram.Info as IGraphInfo).Commands.Cut.Execute(null);
        }

        private void OnCopyCommand(object obj)
        {
            (SelectedDiagram.Info as IGraphInfo).Commands.Copy.Execute(null);
        }
        #endregion

        public Visibility Framework { get; set; }

        /*This property is used to change Drawing Tool icons at run time*/
        private string _mSmallIcon = ICons.DrawingTool_Rectangle.ToImageSource();
        public string SmallIcon
        {
            get { return _mSmallIcon; }
            set
            {
                if (_mSmallIcon != value)
                {
                    _mSmallIcon = value;
                    OnPropertyChanged("SmallIcon");
                }
            }
        }
    }

    public interface IDiagramBuilderVM
    {
        ICommand New { get; set; }
        ICommand Delete { get; set; }
        ICommand Save { get; set; }
        ICommand SaveAll { get; set; }
        ICommand Import { get; set; }
        ICommand Export { get; set; }
        ICommand Print { get; set; }
        ICommand SelectEditor { get; set; }
        ICommand EditorPicker { get; set; }
        ICommand ZoomIn { get; set; }
        ICommand ZoomOut { get; set; }
        ICommand Zoom1 { get; set; }
        ICommand Duplicate { get; set; }
        ICommand Open { get; set; }
        Visibility EditorVisbility { get; set; }
        Visibility EditorPickerVisibility { get; set; }
        ICommand Exit { get; set; }
        Task PrepareExit();
        ICommand Draw { get; set; }
        bool IsDrawingToolEnable { get; set; }


    }

    public class FileInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public int Index { get; set; }
        public bool Selected { get; set; }
    }
}

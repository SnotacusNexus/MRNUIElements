#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Markup;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using Shape_Shifter.ViewModel;

namespace Shape_Shifter.Utility
{
    public class BooleanToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility val = (Visibility)value;
            if (val == Visibility.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Inverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Visibility)value == Visibility.Visible)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class Ext
    {
        public static Color ToColor(this string value) {
            Color c;
            var match = Regex.Match(value, "#([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})");
            int a = Convert.ToInt32(match.Groups[1].Value, 16);
            int r = Convert.ToInt32(match.Groups[2].Value, 16);
            int g = Convert.ToInt32(match.Groups[3].Value, 16);
            int b = Convert.ToInt32(match.Groups[4].Value, 16);
            c = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            return c;
        }

        public static DoubleCollection Clone(this DoubleCollection item)
        {
            DoubleCollection col = new DoubleCollection();
            foreach (var dou in item)
            {
                col.Add(dou);
            }
            return col;
        }
    }

    public class StringtoCommandConverter : DependencyObject, IValueConverter
    {


        public DiagramBuilderVM Context
        {
            get { return (DiagramBuilderVM)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Context.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(DiagramBuilderVM), typeof(StringtoCommandConverter), new PropertyMetadata(null, onPropertychanged));

        private static void onPropertychanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string command = value.ToString();
            ////DiagramBuilderVM vm = values[1] as DiagramBuilderVM;
            //if (vm != null)
            //{
            //    switch (command)
            //    {
            //        case "Cut":
            //            return vm.Cut;
            //            break;
            //        case "Copy":
            //            return vm.Copy;
            //            break;
            //        case "Paste":
            //            return vm.Paste;
            //            break;

            //    }
            //}
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumtoVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string con = value.ToString();
            string check = parameter.ToString();
            if (con.Equals(check))
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TexttoPercentageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double scale = Math.Floor((Double)value * 100);
            return scale.ToString() + "%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class PickerVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Visibility)value == Visibility.Visible)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
               
                  Brush   brush = (Brush) converter.ConvertFromString(value.ToString());
             
                return (brush as SolidColorBrush).Color;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(value.ToString());
                return brush;
            }
            return null;
        }
    }

    //BindableStaticResource
    public class BindableStaticResource : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var multiBinding = new MultiBinding();
            multiBinding.Bindings.Add(new Binding() { RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self } });
            multiBinding.Bindings.Add(new Binding());
            multiBinding.Converter = new ResourceKeyToResourceConverter();
            return multiBinding.ProvideValue(serviceProvider);
        }
    }

    //ResourceKeyToResourceConverter
    class ResourceKeyToResourceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length < 2)
            {
                return null;
            }
            var element = values[0] as FrameworkElement;
            DependencyObject dobject = (element as FrameworkElement).Parent;
            var resourceKey = values[1];
            resourceKey = string.Format("{0}Style", resourceKey);
            var resource = element.TryFindResource(resourceKey);
            if (dobject != null && resource != null)
            {
                if (dobject is Grid)
                {
                    if ((dobject as Grid).Children.Count > 1)
                    {
                        var converter = new System.Windows.Media.BrushConverter();
                        if ((dobject as Grid).Children[0] is TextBlock)
                        {
                            TextBlock tt = (dobject as Grid).Children[0] as TextBlock;
                            foreach (Setter set in (resource as Style).Setters)
                            {
                                if (set.Property == FrameworkElement.TagProperty)
                                {
                                    var brush = (Brush) converter.ConvertFromString(set.Value.ToString());
                                    tt.Foreground = brush;
                                }
                            }
                        }
                        else if ((dobject as Grid).Children[0] is Path)
                        {
                            
                            Path tt = (dobject as Grid).Children[0] as Path;
                            foreach (Setter set in (resource as Style).Setters)
                            {
                                if (set.Property == FrameworkElement.TagProperty)
                                {
                                    var brush = (Brush)converter.ConvertFromString(set.Value.ToString());
                                    tt.Fill = brush;
                                }
                            }
                            
                        }
                    }
                }
              
            }
          

           
            return resource;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class GalarySelection 
    {

        public static ICommand SelectCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectCommandProperty);
        }
        public static void SetSelectCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectCommandProperty, value);
        }

        public static readonly DependencyProperty SelectCommandProperty =
            DependencyProperty.RegisterAttached("SelectCommand", typeof(ICommand), typeof(GalarySelection),
                new PropertyMetadata(null, OnPropertyChanged));
        

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonGallery rg = d as RibbonGallery;
            rg.SelectedItemChanged += rg_SelectedItemChanged;

        }

        static void rg_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = SelectCommand(d as DependencyObject);
            string name = e.NewValue.ToString();
            if (command != null)
            {
                command.Execute(name);
            }
        }
        
    }

    internal static class ShapeHelper
    {
        public static Dictionary<ICons, string> GeometryDictionary = new Dictionary<ICons, string>();

        static ShapeHelper()
        {
            GeometryDictionary.Add(ICons.Cut, "pack://application:,,,/Shape_Shifter;component/Resources/Cut.png");
            GeometryDictionary.Add(ICons.Copy, "pack://application:,,,/Shape_Shifter;component/Resources/Copy.png");
            GeometryDictionary.Add(ICons.Paste, "pack://application:,,,/Shape_Shifter;component/Resources/Paste.png");
            GeometryDictionary.Add(ICons.Bold, "pack://application:,,,/Shape_Shifter;component/Resources/bold.png");
            GeometryDictionary.Add(ICons.Italic, "pack://application:,,,/Shape_Shifter;component/Resources/italic.png");
            GeometryDictionary.Add(ICons.Center, "pack://application:,,,/Shape_Shifter;component/Resources/Align-center.png");
            GeometryDictionary.Add(ICons.Left, "pack://application:,,,/Shape_Shifter;component/Resources/Align-left.png");
            GeometryDictionary.Add(ICons.Right, "pack://application:,,,/Shape_Shifter;component/Resources/Align-right.png");
            GeometryDictionary.Add(ICons.BottomRight, "pack://application:,,,/Shape_Shifter;component/Resources/Bottomright.png");
            GeometryDictionary.Add(ICons.TopLeft, "pack://application:,,,/Shape_Shifter;component/Resources/Align-middle.png");
            GeometryDictionary.Add(ICons.TopRight, "pack://application:,,,/Shape_Shifter;component/Resources/Bottom.png");
            GeometryDictionary.Add(ICons.BottomLeft, "pack://application:,,,/Shape_Shifter;component/Resources/Bottomleft.png");
            GeometryDictionary.Add(ICons.Top, "pack://application:,,,/Shape_Shifter;component/Resources/Align-top.png");
            GeometryDictionary.Add(ICons.Bottom, "pack://application:,,,/Shape_Shifter;component/Resources/Align-bottom.png");
            GeometryDictionary.Add(ICons.PointerTool, "pack://application:,,,/Shape_Shifter;component/Resources/pointer.png");
            GeometryDictionary.Add(ICons.Select, "pack://application:,,,/Shape_Shifter;component/Resources/select1.png");
            GeometryDictionary.Add(ICons.Position, "pack://application:,,,/Shape_Shifter;component/Resources/position-icon.png");
            GeometryDictionary.Add(ICons.Connector, "pack://application:,,,/Shape_Shifter;component/Resources/connector.png");
            GeometryDictionary.Add(ICons.Port, "pack://application:,,,/Shape_Shifter;component/Resources/Port.png");
            GeometryDictionary.Add(ICons.Text, "pack://application:,,,/Shape_Shifter;component/Resources/Text.png");
            GeometryDictionary.Add(ICons.Zoom, "pack://application:,,,/Shape_Shifter;component/Resources/Zoom-1.png");
            GeometryDictionary.Add(ICons.FitToPage, "pack://application:,,,/Shape_Shifter;component/Resources/fullscreen-16x16-2.png");
            GeometryDictionary.Add(ICons.Label, "pack://application:,,,/Shape_Shifter;component/Resources/FontColor.png");
            GeometryDictionary.Add(ICons.Fill, "pack://application:,,,/Shape_Shifter;component/Resources/shape-fill.png");
            GeometryDictionary.Add(ICons.Stroke, "pack://application:,,,/Shape_Shifter;component/Resources/shape-fill.png");
            GeometryDictionary.Add(ICons.Align, "pack://application:,,,/Shape_Shifter;component/Resources/Align_Split.png");
            GeometryDictionary.Add(ICons.AlignLeft, "pack://application:,,,/Shape_Shifter;component/Resources/AlignLeft.png");
            GeometryDictionary.Add(ICons.AlignCenter, "pack://application:,,,/Shape_Shifter;component/Resources/AlignCenter.png");
            GeometryDictionary.Add(ICons.AlignRight, "pack://application:,,,/Shape_Shifter;component/Resources/AlignRight.png");
            GeometryDictionary.Add(ICons.AlignTop, "pack://application:,,,/Shape_Shifter;component/Resources/AlignTop.png");
            GeometryDictionary.Add(ICons.AlignMiddle, "pack://application:,,,/Shape_Shifter;component/Resources/AlignMiddle.png");
            GeometryDictionary.Add(ICons.AlignBottom, "pack://application:,,,/Shape_Shifter;component/Resources/AlignBottom.png");
            GeometryDictionary.Add(ICons.Group, "pack://application:,,,/Shape_Shifter;component/Resources/Group.png");
            GeometryDictionary.Add(ICons.UnGroup, "pack://application:,,,/Shape_Shifter;component/Resources/UnGroup.png");
            GeometryDictionary.Add(ICons.BringToFront, "pack://application:,,,/Shape_Shifter;component/Resources/BringToFront.png");
            GeometryDictionary.Add(ICons.SendToBack, "pack://application:,,,/Shape_Shifter;component/Resources/SendToBack.png");
            GeometryDictionary.Add(ICons.BringForward, "pack://application:,,,/Shape_Shifter;component/Resources/BringForward.png");
            GeometryDictionary.Add(ICons.SendBackward, "pack://application:,,,/Shape_Shifter;component/Resources/SendBackward.png");
            GeometryDictionary.Add(ICons.Size, "pack://application:,,,/Shape_Shifter;component/Resources/Size.png");
            GeometryDictionary.Add(ICons.NewPage, "pack://application:,,,/Shape_Shifter;component/Resources/New-page.png");
            GeometryDictionary.Add(ICons.DuplicatePage, "pack://application:,,,/Shape_Shifter;component/Resources/duplicate.png");
            GeometryDictionary.Add(ICons.Pictures, "pack://application:,,,/Shape_Shifter;component/Resources/Pictures.png");
            GeometryDictionary.Add(ICons.Orientation, "pack://application:,,,/Shape_Shifter;component/Resources/Orientation.png");
            GeometryDictionary.Add(ICons.Potrait, "pack://application:,,,/Shape_Shifter;component/Resources/Portrait.png");
            GeometryDictionary.Add(ICons.Landscape, "pack://application:,,,/Shape_Shifter;component/Resources/Landscape.png");
            GeometryDictionary.Add(ICons.A4, "pack://application:,,,/Shape_Shifter;component/Resources/A4.png");
            GeometryDictionary.Add(ICons.A5, "pack://application:,,,/Shape_Shifter;component/Resources/A5.png");
            GeometryDictionary.Add(ICons.Letter, "pack://application:,,,/Shape_Shifter;component/Resources/letter.png");
            GeometryDictionary.Add(ICons.Ledger, "pack://application:,,,/Shape_Shifter;component/Resources/Ledger.png");
            GeometryDictionary.Add(ICons.Legal, "pack://application:,,,/Shape_Shifter;component/Resources/Legal.png");

            GeometryDictionary.Add(ICons.Underline, "pack://application:,,,/Shape_Shifter;component/Resources/Underline16.png");
            GeometryDictionary.Add(ICons.GrowFont, "pack://application:,,,/Shape_Shifter;component/Resources/GrowFont16.png");
            GeometryDictionary.Add(ICons.DecreaseFont, "pack://application:,,,/Shape_Shifter;component/Resources/ShrinkFont16.png");
            GeometryDictionary.Add(ICons.Strike, "pack://application:,,,/Shape_Shifter;component/Resources/Strike.png");

            GeometryDictionary.Add(ICons.SelectAll, "pack://application:,,,/Shape_Shifter;component/Resources/Select-all.png");
            GeometryDictionary.Add(ICons.SelectNode, "pack://application:,,,/Shape_Shifter;component/Resources/select-nodes.png");
            GeometryDictionary.Add(ICons.SelectConnector, "pack://application:,,,/Shape_Shifter;component/Resources/select-connectors.png");

            GeometryDictionary.Add(ICons.SpaceAcross, "pack://application:,,,/Shape_Shifter;component/Resources/SpaceAcross.png");
            GeometryDictionary.Add(ICons.SpaceDown, "pack://application:,,,/Shape_Shifter;component/Resources/SpaceDown.png");
            GeometryDictionary.Add(ICons.DrawingTool_Ellipse, "pack://application:,,,/Shape_Shifter;component/Resources/DrawTool_Ellipse.png");
            GeometryDictionary.Add(ICons.DrawingTool_Rectangle, "pack://application:,,,/Shape_Shifter;component/Resources/DrawTool_Rectangle.png");
            GeometryDictionary.Add(ICons.DrawingTool_StraightLine, "pack://application:,,,/Shape_Shifter;component/Resources/DrawTool_StraightLine.png");

            GeometryDictionary.Add(ICons.ConnectorType, "pack://application:,,,/Shape_Shifter;component/Resources/Connectors.png");
            GeometryDictionary.Add(ICons.ConnectorType_Orthogonal, "pack://application:,,,/Shape_Shifter;component/Resources/Orthogonal.png");
            GeometryDictionary.Add(ICons.ConnectorType_StraightLine, "pack://application:,,,/Shape_Shifter;component/Resources/StraightLine.png");
            GeometryDictionary.Add(ICons.ConnectorType_CubicBeier, "pack://application:,,,/Shape_Shifter;component/Resources/CubicBezier.png");

            GeometryDictionary.Add(ICons.TaskPanes, "pack://application:,,,/Shape_Shifter;component/Resources/Taskpane.png");
            GeometryDictionary.Add(ICons.PanZoom, "pack://application:,,,/Shape_Shifter;component/Resources/PanZoom.png");
            GeometryDictionary.Add(ICons.SizeandPosition, "pack://application:,,,/Shape_Shifter;component/Resources/SizeandPosition.png");
        }

        public static string ToImageSource(this ICons source)
        {

            if (source == ICons.None)
            {
                return null;
            }
            return GeometryDictionary[source];
        }
    }

    public enum Controls
    {
        Button,
        ToggleButton,
        FontFamily,
        FontSize,
        Combobox,
        ColorPicker,
        SplitButton,
        CheckBox,
        Galary
    }

    public enum Tabs
    {
        HOME,
        INSERT,
        VIEW,
        DESIGN
    }

    public enum Groups
    {
        ClipBoard,
        Font,
        Paragraph,
        Alignment,
        Tools,
        ShapeStyle,
        Arrange,
        Editing,
        Show,
        Zoom,
        PageSetup,
        Pages,
        Illustrations
    }

    public enum ICons
    {
        Cut,
        SpaceDown,
        SpaceAcross,
        SelectAll,
        SelectNode,
        SelectConnector,
        Position,
        Copy,
        Paste,
        FontFamily,
        GrowFont,
        Bold,
        Strike,
        DecreaseFont,
        Italic,
        Underline,
        FontSize,
        Label,
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight,
        PointerTool,
        Connector,
        Text,
        Port,
        Fill,
        Stroke,
        Orientation,
        Potrait,
        Landscape,
        Size,
        A4,
        A5,
        Legal,
        Letter,
        Ledger,
        Ruler,
        Grid,
        PageBreaks,
        MultiplePage,
        SnapToObject,
        SnapToGrid,
        Zoom,
        FitToPage,
        Align,
        AlignLeft,
        AlignCenter,
        AlignRight,
        AlignTop,
        AlignBottom,
        AlignMiddle,
        Group,
        UnGroup,
        BringToFront,
        BringForward,
        SendToBack,
        SendBackward,
        NewPage,
        DuplicatePage,
        Pictures,
        None,
        Select,
        DrawingTool_Rectangle,
        DrawingTool_Ellipse,
        DrawingTool_StraightLine,
        ConnectorType,
        ConnectorType_Orthogonal,
        ConnectorType_StraightLine,
        ConnectorType_CubicBeier,
        TaskPanes,
        PanZoom,
        SizeandPosition,
    }

}

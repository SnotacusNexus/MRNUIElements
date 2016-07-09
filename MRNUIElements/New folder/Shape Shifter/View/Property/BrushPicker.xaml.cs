#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using Syncfusion.Windows.Controls.Input;
using System.Windows.Input;
using Syncfusion.Windows.Tools.Controls;

namespace Shape_Shifter.View
{
    public sealed partial class BrushPicker : UserControl
    {
        public BrushPicker()
        {
            this.InitializeComponent();
            
        }
     
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(BrushPicker), new PropertyMetadata(Colors.Transparent, OnColorChanged));

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BrushPicker brush = d as BrushPicker;
            //(brush.Brush as SolidColorBrush).Color = brush.Color;
            if ((brush.Brush as SolidColorBrush).Color != brush.Color)
            {
                brush.Brush = new SolidColorBrush(brush.Color);
            }
        }


        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Brush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register("Brush", typeof(Brush), typeof(BrushPicker), new PropertyMetadata(new SolidColorBrush(Colors.Black), OnBrushChanged));


        private static void OnBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BrushPicker brush = d as BrushPicker;
            if (brush.Brush != null)
            {
                if ((brush.Brush as SolidColorBrush).Color != brush.Color)
                {
                    brush.Color = (brush.Brush as SolidColorBrush).Color;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {	
            if (this.PickerTemp.IsDropDownOpen)
                this.PickerTemp.IsDropDownOpen = false;
            else
                this.PickerTemp.IsDropDownOpen = true;
        }

    

    }

    //public class SfColorPicker : SfColorPalette
    //{
    //    public SfColorPicker()
    //    {
         
    //    }

    //    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    //    {
    //        //base.OnPropertyChanged(e);
    //    }

    //    public Color Color
    //    {
    //        get { return (Color)GetValue(ColorProperty); }
    //        set { SetValue(ColorProperty, value); }
    //    }

    //    // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
    //    public static readonly DependencyProperty ColorProperty =
    //        DependencyProperty.Register("Color", typeof(Color), typeof(SfColorPicker), new PropertyMetadata(Colors.Black));


    //}

    class ListViewCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(ListViewCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            RibbonMenuItem listview = depObj as RibbonMenuItem;
            if (listview != null)
            {
               listview.Click+=listview_Click;
            }
        }

        private static void listview_Click(object sender, RoutedEventArgs e)
        {
            RibbonMenuItem listview = sender as RibbonMenuItem;
            if (listview != null)
            {

                ICommand command = listview.GetValue(CommandProperty) as ICommand;

                if (command != null)
                {
                    command.Execute(listview.Header);
                }
            }
        }

        
        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }
}

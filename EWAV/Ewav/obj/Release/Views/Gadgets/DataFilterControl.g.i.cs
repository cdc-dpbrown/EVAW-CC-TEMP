﻿#pragma checksum "C:\TFSCode\EWAV\Ewav\Ewav\Views\Gadgets\DataFilterControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FFF95F038916D70D3C6ED81F6D03B5E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ewav;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Ewav {
    
    
    public partial class DataFilterControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard rotatearrow;
        
        internal System.Windows.Media.Animation.Storyboard rotatearrow1;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Border Slider;
        
        internal System.Windows.Controls.TextBlock VerticalHeading;
        
        internal System.Windows.Controls.Image imgSlide;
        
        internal System.Windows.Shapes.Rectangle RectSlideIn;
        
        internal System.Windows.Controls.StackPanel pnlGuidedMode;
        
        internal System.Windows.Controls.TextBlock filterCount;
        
        internal System.Windows.Controls.ScrollViewer scroll_content;
        
        internal System.Windows.Controls.StackPanel pnlContainer;
        
        internal Ewav.EwavFilter FilterControl;
        
        internal System.Windows.Controls.StackPanel pnlAdvancedMode;
        
        internal System.Windows.Controls.TextBox txtAdvancedFilter;
        
        internal System.Windows.Controls.TextBox txtAdvancedFilterStatus;
        
        internal System.Windows.Controls.StackPanel pnlBtns;
        
        internal System.Windows.Controls.Button btnApply;
        
        internal System.Windows.Controls.Button btnClear;
        
        internal System.Windows.Controls.Button btnAdvMode;
        
        internal System.Windows.Controls.Button btnGuidedMode;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ewav;component/Views/Gadgets/DataFilterControl.xaml", System.UriKind.Relative));
            this.rotatearrow = ((System.Windows.Media.Animation.Storyboard)(this.FindName("rotatearrow")));
            this.rotatearrow1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("rotatearrow1")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Slider = ((System.Windows.Controls.Border)(this.FindName("Slider")));
            this.VerticalHeading = ((System.Windows.Controls.TextBlock)(this.FindName("VerticalHeading")));
            this.imgSlide = ((System.Windows.Controls.Image)(this.FindName("imgSlide")));
            this.RectSlideIn = ((System.Windows.Shapes.Rectangle)(this.FindName("RectSlideIn")));
            this.pnlGuidedMode = ((System.Windows.Controls.StackPanel)(this.FindName("pnlGuidedMode")));
            this.filterCount = ((System.Windows.Controls.TextBlock)(this.FindName("filterCount")));
            this.scroll_content = ((System.Windows.Controls.ScrollViewer)(this.FindName("scroll_content")));
            this.pnlContainer = ((System.Windows.Controls.StackPanel)(this.FindName("pnlContainer")));
            this.FilterControl = ((Ewav.EwavFilter)(this.FindName("FilterControl")));
            this.pnlAdvancedMode = ((System.Windows.Controls.StackPanel)(this.FindName("pnlAdvancedMode")));
            this.txtAdvancedFilter = ((System.Windows.Controls.TextBox)(this.FindName("txtAdvancedFilter")));
            this.txtAdvancedFilterStatus = ((System.Windows.Controls.TextBox)(this.FindName("txtAdvancedFilterStatus")));
            this.pnlBtns = ((System.Windows.Controls.StackPanel)(this.FindName("pnlBtns")));
            this.btnApply = ((System.Windows.Controls.Button)(this.FindName("btnApply")));
            this.btnClear = ((System.Windows.Controls.Button)(this.FindName("btnClear")));
            this.btnAdvMode = ((System.Windows.Controls.Button)(this.FindName("btnAdvMode")));
            this.btnGuidedMode = ((System.Windows.Controls.Button)(this.FindName("btnGuidedMode")));
        }
    }
}


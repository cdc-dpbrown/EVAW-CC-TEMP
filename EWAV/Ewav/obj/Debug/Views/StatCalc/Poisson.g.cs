﻿#pragma checksum "C:\TFSCode\EWAV\Ewav\Ewav\Views\StatCalc\Poisson.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0C6C8AD40C5060C6E5683E86945DBCB9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    
    public partial class Poisson : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard expand;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid GadgetWindow;
        
        internal System.Windows.Shapes.Rectangle GWindow;
        
        internal System.Windows.Controls.TextBlock GName;
        
        internal System.Windows.Shapes.Rectangle GHeader;
        
        internal System.Windows.Controls.Button ResizeButton;
        
        internal System.Windows.Controls.Button CloseButton;
        
        internal System.Windows.Controls.Grid GadgetContentGrid;
        
        internal System.Windows.Controls.StackPanel pnlMainContent;
        
        internal System.Windows.Controls.TextBox txtObserved;
        
        internal System.Windows.Controls.TextBox txtExpected;
        
        internal System.Windows.Controls.TextBlock lblLessThan;
        
        internal System.Windows.Controls.TextBlock lblLessThanEqual;
        
        internal System.Windows.Controls.TextBlock lblEqual;
        
        internal System.Windows.Controls.TextBlock lblGreaterThanEqual;
        
        internal System.Windows.Controls.TextBlock lblGreaterThan;
        
        internal System.Windows.Controls.TextBlock txtLessThan;
        
        internal System.Windows.Controls.TextBlock txtLessThanEqual;
        
        internal System.Windows.Controls.TextBlock txtEqual;
        
        internal System.Windows.Controls.TextBlock txtGreaterThanEqual;
        
        internal System.Windows.Controls.TextBlock txtGreaterThan;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ewav;component/Views/StatCalc/Poisson.xaml", System.UriKind.Relative));
            this.expand = ((System.Windows.Media.Animation.Storyboard)(this.FindName("expand")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.GadgetWindow = ((System.Windows.Controls.Grid)(this.FindName("GadgetWindow")));
            this.GWindow = ((System.Windows.Shapes.Rectangle)(this.FindName("GWindow")));
            this.GName = ((System.Windows.Controls.TextBlock)(this.FindName("GName")));
            this.GHeader = ((System.Windows.Shapes.Rectangle)(this.FindName("GHeader")));
            this.ResizeButton = ((System.Windows.Controls.Button)(this.FindName("ResizeButton")));
            this.CloseButton = ((System.Windows.Controls.Button)(this.FindName("CloseButton")));
            this.GadgetContentGrid = ((System.Windows.Controls.Grid)(this.FindName("GadgetContentGrid")));
            this.pnlMainContent = ((System.Windows.Controls.StackPanel)(this.FindName("pnlMainContent")));
            this.txtObserved = ((System.Windows.Controls.TextBox)(this.FindName("txtObserved")));
            this.txtExpected = ((System.Windows.Controls.TextBox)(this.FindName("txtExpected")));
            this.lblLessThan = ((System.Windows.Controls.TextBlock)(this.FindName("lblLessThan")));
            this.lblLessThanEqual = ((System.Windows.Controls.TextBlock)(this.FindName("lblLessThanEqual")));
            this.lblEqual = ((System.Windows.Controls.TextBlock)(this.FindName("lblEqual")));
            this.lblGreaterThanEqual = ((System.Windows.Controls.TextBlock)(this.FindName("lblGreaterThanEqual")));
            this.lblGreaterThan = ((System.Windows.Controls.TextBlock)(this.FindName("lblGreaterThan")));
            this.txtLessThan = ((System.Windows.Controls.TextBlock)(this.FindName("txtLessThan")));
            this.txtLessThanEqual = ((System.Windows.Controls.TextBlock)(this.FindName("txtLessThanEqual")));
            this.txtEqual = ((System.Windows.Controls.TextBlock)(this.FindName("txtEqual")));
            this.txtGreaterThanEqual = ((System.Windows.Controls.TextBlock)(this.FindName("txtGreaterThanEqual")));
            this.txtGreaterThan = ((System.Windows.Controls.TextBlock)(this.FindName("txtGreaterThan")));
        }
    }
}


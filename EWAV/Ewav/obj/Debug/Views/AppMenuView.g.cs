﻿#pragma checksum "C:\_CODE\EVAW-CC-TEMP\Ewav\Ewav\Views\AppMenuView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A225E9E973925DE7BD9B5D28FA70E370"
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


namespace EWAV {
    
    
    public partial class AppMenuView : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard Fader;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid AppHeader;
        
        internal System.Windows.Controls.StackPanel spMenu;
        
        internal System.Windows.Controls.Button SetDataSource;
        
        internal System.Windows.Controls.Button Open;
        
        internal System.Windows.Controls.Button Save;
        
        internal System.Windows.Controls.Button SaveAs;
        
        internal System.Windows.Controls.Button Reset;
        
        internal System.Windows.Controls.Button Delete;
        
        internal System.Windows.Controls.Button Share;
        
        internal System.Windows.Controls.Button Export;
        
        internal System.Windows.Controls.Button HTML;
        
        internal System.Windows.Controls.StackPanel spRefreshbtn;
        
        internal System.Windows.Controls.Button Refresh;
        
        internal System.Windows.Controls.Border brdrRefresh;
        
        internal System.Windows.Controls.TextBlock tbRefreshCount;
        
        internal System.Windows.Controls.StackPanel spAppName;
        
        internal System.Windows.Controls.TextBlock AppNameText;
        
        internal System.Windows.Controls.Image AppLogo;
        
        internal System.Windows.Controls.Grid SecBar;
        
        internal System.Windows.Controls.TextBlock tbDatasource;
        
        internal System.Windows.Controls.TextBlock tbDatasourceName;
        
        internal System.Windows.Controls.TextBlock tbRecordCount;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/EWAVD3;component/Views/AppMenuView.xaml", System.UriKind.Relative));
            this.Fader = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Fader")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.AppHeader = ((System.Windows.Controls.Grid)(this.FindName("AppHeader")));
            this.spMenu = ((System.Windows.Controls.StackPanel)(this.FindName("spMenu")));
            this.SetDataSource = ((System.Windows.Controls.Button)(this.FindName("SetDataSource")));
            this.Open = ((System.Windows.Controls.Button)(this.FindName("Open")));
            this.Save = ((System.Windows.Controls.Button)(this.FindName("Save")));
            this.SaveAs = ((System.Windows.Controls.Button)(this.FindName("SaveAs")));
            this.Reset = ((System.Windows.Controls.Button)(this.FindName("Reset")));
            this.Delete = ((System.Windows.Controls.Button)(this.FindName("Delete")));
            this.Share = ((System.Windows.Controls.Button)(this.FindName("Share")));
            this.Export = ((System.Windows.Controls.Button)(this.FindName("Export")));
            this.HTML = ((System.Windows.Controls.Button)(this.FindName("HTML")));
            this.spRefreshbtn = ((System.Windows.Controls.StackPanel)(this.FindName("spRefreshbtn")));
            this.Refresh = ((System.Windows.Controls.Button)(this.FindName("Refresh")));
            this.brdrRefresh = ((System.Windows.Controls.Border)(this.FindName("brdrRefresh")));
            this.tbRefreshCount = ((System.Windows.Controls.TextBlock)(this.FindName("tbRefreshCount")));
            this.spAppName = ((System.Windows.Controls.StackPanel)(this.FindName("spAppName")));
            this.AppNameText = ((System.Windows.Controls.TextBlock)(this.FindName("AppNameText")));
            this.AppLogo = ((System.Windows.Controls.Image)(this.FindName("AppLogo")));
            this.SecBar = ((System.Windows.Controls.Grid)(this.FindName("SecBar")));
            this.tbDatasource = ((System.Windows.Controls.TextBlock)(this.FindName("tbDatasource")));
            this.tbDatasourceName = ((System.Windows.Controls.TextBlock)(this.FindName("tbDatasourceName")));
            this.tbRecordCount = ((System.Windows.Controls.TextBlock)(this.FindName("tbRecordCount")));
        }
    }
}


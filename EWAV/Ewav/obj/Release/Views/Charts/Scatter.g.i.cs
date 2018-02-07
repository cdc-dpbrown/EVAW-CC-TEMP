﻿#pragma checksum "C:\TFSCode\EWAV\Ewav\Ewav\Views\Charts\Scatter.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2328CD38592FE8218025C26E531E4E23"
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
    
    
    public partial class Scatter : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid GadgetWindow;
        
        internal System.Windows.Shapes.Rectangle GWindow;
        
        internal System.Windows.Controls.TextBlock tbChartName;
        
        internal System.Windows.Shapes.Rectangle GHeader;
        
        internal System.Windows.Controls.Button FilterButton;
        
        internal System.Windows.Controls.Button HeaderButton;
        
        internal System.Windows.Controls.Button ResizeButton;
        
        internal System.Windows.Controls.Button CloseButton;
        
        internal System.Windows.Controls.Grid GadgetContentGrid;
        
        internal System.Windows.Controls.Expander gadgetExpander;
        
        internal System.Windows.Controls.StackPanel pnlScatterConfig;
        
        internal System.Windows.Controls.ComboBox cbxScatterXAxisField;
        
        internal System.Windows.Controls.ComboBox cbxScatterYAxisField;
        
        internal System.Windows.Controls.StackPanel pnlSingleConfig;
        
        internal System.Windows.Controls.ComboBox cbxSingleField;
        
        internal System.Windows.Controls.ComboBox cbxWeightField;
        
        internal System.Windows.Controls.TextBlock tblockStrataField;
        
        internal System.Windows.Controls.ComboBox cbxStrataField;
        
        internal System.Windows.Controls.ComboBox cbxChartSize;
        
        internal System.Windows.Controls.Button btnRun;
        
        internal System.Windows.Controls.StackPanel spContent;
        
        internal System.Windows.Controls.StackPanel pnlStatus;
        
        internal System.Windows.Controls.StackPanel pnlStatusTop;
        
        internal System.Windows.Controls.Image ErrorIcon;
        
        internal System.Windows.Controls.TextBlock txtStatus;
        
        internal System.Windows.Controls.StackPanel panelMain;
        
        internal System.Windows.Controls.TextBlock tbGadgetDescription;
        
        internal System.Windows.Controls.Grid grdChart;
        
        internal System.Windows.Controls.StackPanel pnlChartContainer;
        
        internal System.Windows.Controls.TextBlock lblNumberOfRecords;
        
        internal System.Windows.Controls.TextBlock tbNumberOfRecords;
        
        internal System.Windows.Controls.Grid waitCursor;
        
        internal System.Windows.Controls.BusyIndicator BusyIndicator;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ewav;component/Views/Charts/Scatter.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.GadgetWindow = ((System.Windows.Controls.Grid)(this.FindName("GadgetWindow")));
            this.GWindow = ((System.Windows.Shapes.Rectangle)(this.FindName("GWindow")));
            this.tbChartName = ((System.Windows.Controls.TextBlock)(this.FindName("tbChartName")));
            this.GHeader = ((System.Windows.Shapes.Rectangle)(this.FindName("GHeader")));
            this.FilterButton = ((System.Windows.Controls.Button)(this.FindName("FilterButton")));
            this.HeaderButton = ((System.Windows.Controls.Button)(this.FindName("HeaderButton")));
            this.ResizeButton = ((System.Windows.Controls.Button)(this.FindName("ResizeButton")));
            this.CloseButton = ((System.Windows.Controls.Button)(this.FindName("CloseButton")));
            this.GadgetContentGrid = ((System.Windows.Controls.Grid)(this.FindName("GadgetContentGrid")));
            this.gadgetExpander = ((System.Windows.Controls.Expander)(this.FindName("gadgetExpander")));
            this.pnlScatterConfig = ((System.Windows.Controls.StackPanel)(this.FindName("pnlScatterConfig")));
            this.cbxScatterXAxisField = ((System.Windows.Controls.ComboBox)(this.FindName("cbxScatterXAxisField")));
            this.cbxScatterYAxisField = ((System.Windows.Controls.ComboBox)(this.FindName("cbxScatterYAxisField")));
            this.pnlSingleConfig = ((System.Windows.Controls.StackPanel)(this.FindName("pnlSingleConfig")));
            this.cbxSingleField = ((System.Windows.Controls.ComboBox)(this.FindName("cbxSingleField")));
            this.cbxWeightField = ((System.Windows.Controls.ComboBox)(this.FindName("cbxWeightField")));
            this.tblockStrataField = ((System.Windows.Controls.TextBlock)(this.FindName("tblockStrataField")));
            this.cbxStrataField = ((System.Windows.Controls.ComboBox)(this.FindName("cbxStrataField")));
            this.cbxChartSize = ((System.Windows.Controls.ComboBox)(this.FindName("cbxChartSize")));
            this.btnRun = ((System.Windows.Controls.Button)(this.FindName("btnRun")));
            this.spContent = ((System.Windows.Controls.StackPanel)(this.FindName("spContent")));
            this.pnlStatus = ((System.Windows.Controls.StackPanel)(this.FindName("pnlStatus")));
            this.pnlStatusTop = ((System.Windows.Controls.StackPanel)(this.FindName("pnlStatusTop")));
            this.ErrorIcon = ((System.Windows.Controls.Image)(this.FindName("ErrorIcon")));
            this.txtStatus = ((System.Windows.Controls.TextBlock)(this.FindName("txtStatus")));
            this.panelMain = ((System.Windows.Controls.StackPanel)(this.FindName("panelMain")));
            this.tbGadgetDescription = ((System.Windows.Controls.TextBlock)(this.FindName("tbGadgetDescription")));
            this.grdChart = ((System.Windows.Controls.Grid)(this.FindName("grdChart")));
            this.pnlChartContainer = ((System.Windows.Controls.StackPanel)(this.FindName("pnlChartContainer")));
            this.lblNumberOfRecords = ((System.Windows.Controls.TextBlock)(this.FindName("lblNumberOfRecords")));
            this.tbNumberOfRecords = ((System.Windows.Controls.TextBlock)(this.FindName("tbNumberOfRecords")));
            this.waitCursor = ((System.Windows.Controls.Grid)(this.FindName("waitCursor")));
            this.BusyIndicator = ((System.Windows.Controls.BusyIndicator)(this.FindName("BusyIndicator")));
        }
    }
}


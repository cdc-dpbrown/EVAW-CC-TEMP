﻿#pragma checksum "C:\_CODE\EVAW-CC-TEMP\Ewav\Ewav\Views\Gadgets\MxNTableControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6715E9B8164E2D95105E0BA2C3F1B2A8"
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
    
    
    public partial class MxNTableControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid GadgetWindow;
        
        internal System.Windows.Shapes.Rectangle GWindow;
        
        internal System.Windows.Controls.TextBlock GName;
        
        internal System.Windows.Shapes.Rectangle GHeader;
        
        internal System.Windows.Controls.Button FilterButton;
        
        internal System.Windows.Controls.Button HeaderButton;
        
        internal System.Windows.Controls.Button ResizeButton;
        
        internal System.Windows.Controls.Button CloseButton;
        
        internal System.Windows.Controls.Grid GadgetContentGrid;
        
        internal System.Windows.Controls.Expander gadgetExpander;
        
        internal System.Windows.Controls.Grid editProperties;
        
        internal System.Windows.Controls.ComboBox cbxExposureField;
        
        internal System.Windows.Controls.ComboBox cbxOutcomeField;
        
        internal System.Windows.Controls.Expander AdvancedOptions;
        
        internal System.Windows.Controls.ComboBox cbxFieldWeight;
        
        internal System.Windows.Controls.ComboBox cbxFieldStrata;
        
        internal System.Windows.Controls.TextBox txtMaxRows;
        
        internal System.Windows.Controls.Button btn_Rows;
        
        internal System.Windows.Controls.TextBox txtMaxColumns;
        
        internal System.Windows.Controls.Button btn_Cols;
        
        internal System.Windows.Controls.TextBox txtMaxColumnLength;
        
        internal System.Windows.Controls.Button btn_Length;
        
        internal System.Windows.Controls.CheckBox checkboxIncludeMissing;
        
        internal System.Windows.Controls.CheckBox checkboxOutcomeContinuous;
        
        internal System.Windows.Controls.Button btnGo;
        
        internal System.Windows.Controls.StackPanel spContent;
        
        internal System.Windows.Controls.TextBlock txtGadgetDescription;
        
        internal System.Windows.Controls.StackPanel pnlStatus;
        
        internal System.Windows.Controls.StackPanel pnlStatusTop;
        
        internal System.Windows.Controls.Image ErrorIcon;
        
        internal System.Windows.Controls.TextBlock txtStatus;
        
        internal System.Windows.Controls.StackPanel panelMain;
        
        internal System.Windows.Controls.Grid grdFreq;
        
        internal System.Windows.Controls.TextBlock txtConfLimits;
        
        internal System.Windows.Controls.Grid grdConf;
        
        internal System.Windows.Controls.Grid grdTable;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/EWAVD3;component/Views/Gadgets/MxNTableControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.GadgetWindow = ((System.Windows.Controls.Grid)(this.FindName("GadgetWindow")));
            this.GWindow = ((System.Windows.Shapes.Rectangle)(this.FindName("GWindow")));
            this.GName = ((System.Windows.Controls.TextBlock)(this.FindName("GName")));
            this.GHeader = ((System.Windows.Shapes.Rectangle)(this.FindName("GHeader")));
            this.FilterButton = ((System.Windows.Controls.Button)(this.FindName("FilterButton")));
            this.HeaderButton = ((System.Windows.Controls.Button)(this.FindName("HeaderButton")));
            this.ResizeButton = ((System.Windows.Controls.Button)(this.FindName("ResizeButton")));
            this.CloseButton = ((System.Windows.Controls.Button)(this.FindName("CloseButton")));
            this.GadgetContentGrid = ((System.Windows.Controls.Grid)(this.FindName("GadgetContentGrid")));
            this.gadgetExpander = ((System.Windows.Controls.Expander)(this.FindName("gadgetExpander")));
            this.editProperties = ((System.Windows.Controls.Grid)(this.FindName("editProperties")));
            this.cbxExposureField = ((System.Windows.Controls.ComboBox)(this.FindName("cbxExposureField")));
            this.cbxOutcomeField = ((System.Windows.Controls.ComboBox)(this.FindName("cbxOutcomeField")));
            this.AdvancedOptions = ((System.Windows.Controls.Expander)(this.FindName("AdvancedOptions")));
            this.cbxFieldWeight = ((System.Windows.Controls.ComboBox)(this.FindName("cbxFieldWeight")));
            this.cbxFieldStrata = ((System.Windows.Controls.ComboBox)(this.FindName("cbxFieldStrata")));
            this.txtMaxRows = ((System.Windows.Controls.TextBox)(this.FindName("txtMaxRows")));
            this.btn_Rows = ((System.Windows.Controls.Button)(this.FindName("btn_Rows")));
            this.txtMaxColumns = ((System.Windows.Controls.TextBox)(this.FindName("txtMaxColumns")));
            this.btn_Cols = ((System.Windows.Controls.Button)(this.FindName("btn_Cols")));
            this.txtMaxColumnLength = ((System.Windows.Controls.TextBox)(this.FindName("txtMaxColumnLength")));
            this.btn_Length = ((System.Windows.Controls.Button)(this.FindName("btn_Length")));
            this.checkboxIncludeMissing = ((System.Windows.Controls.CheckBox)(this.FindName("checkboxIncludeMissing")));
            this.checkboxOutcomeContinuous = ((System.Windows.Controls.CheckBox)(this.FindName("checkboxOutcomeContinuous")));
            this.btnGo = ((System.Windows.Controls.Button)(this.FindName("btnGo")));
            this.spContent = ((System.Windows.Controls.StackPanel)(this.FindName("spContent")));
            this.txtGadgetDescription = ((System.Windows.Controls.TextBlock)(this.FindName("txtGadgetDescription")));
            this.pnlStatus = ((System.Windows.Controls.StackPanel)(this.FindName("pnlStatus")));
            this.pnlStatusTop = ((System.Windows.Controls.StackPanel)(this.FindName("pnlStatusTop")));
            this.ErrorIcon = ((System.Windows.Controls.Image)(this.FindName("ErrorIcon")));
            this.txtStatus = ((System.Windows.Controls.TextBlock)(this.FindName("txtStatus")));
            this.panelMain = ((System.Windows.Controls.StackPanel)(this.FindName("panelMain")));
            this.grdFreq = ((System.Windows.Controls.Grid)(this.FindName("grdFreq")));
            this.txtConfLimits = ((System.Windows.Controls.TextBlock)(this.FindName("txtConfLimits")));
            this.grdConf = ((System.Windows.Controls.Grid)(this.FindName("grdConf")));
            this.grdTable = ((System.Windows.Controls.Grid)(this.FindName("grdTable")));
            this.waitCursor = ((System.Windows.Controls.Grid)(this.FindName("waitCursor")));
            this.BusyIndicator = ((System.Windows.Controls.BusyIndicator)(this.FindName("BusyIndicator")));
        }
    }
}


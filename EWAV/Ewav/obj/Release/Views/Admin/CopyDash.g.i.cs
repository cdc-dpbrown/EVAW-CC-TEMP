﻿#pragma checksum "C:\TFSCode\EWAV\Ewav\Ewav\Views\Admin\CopyDash.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "31F07223B03D582516D7312FF45896AD"
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
    
    
    public partial class CopyDash : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid HeaderGrid;
        
        internal System.Windows.Shapes.Rectangle GHeader;
        
        internal System.Windows.Controls.StackPanel spMsg;
        
        internal System.Windows.Controls.Image imgerrMsg;
        
        internal System.Windows.Controls.Image imgSMsg;
        
        internal System.Windows.Controls.TextBlock errMsg;
        
        internal System.Windows.Controls.StackPanel spCopy;
        
        internal Ewav.MyComboBox cmbSavedDash;
        
        internal System.Windows.Controls.ComboBox cmbDataSource;
        
        internal System.Windows.Controls.TextBox txtCanvasName;
        
        internal System.Windows.Controls.Button btnCopyDash;
        
        internal System.Windows.Controls.Button btnClear;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ewav;component/Views/Admin/CopyDash.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.HeaderGrid = ((System.Windows.Controls.Grid)(this.FindName("HeaderGrid")));
            this.GHeader = ((System.Windows.Shapes.Rectangle)(this.FindName("GHeader")));
            this.spMsg = ((System.Windows.Controls.StackPanel)(this.FindName("spMsg")));
            this.imgerrMsg = ((System.Windows.Controls.Image)(this.FindName("imgerrMsg")));
            this.imgSMsg = ((System.Windows.Controls.Image)(this.FindName("imgSMsg")));
            this.errMsg = ((System.Windows.Controls.TextBlock)(this.FindName("errMsg")));
            this.spCopy = ((System.Windows.Controls.StackPanel)(this.FindName("spCopy")));
            this.cmbSavedDash = ((Ewav.MyComboBox)(this.FindName("cmbSavedDash")));
            this.cmbDataSource = ((System.Windows.Controls.ComboBox)(this.FindName("cmbDataSource")));
            this.txtCanvasName = ((System.Windows.Controls.TextBox)(this.FindName("txtCanvasName")));
            this.btnCopyDash = ((System.Windows.Controls.Button)(this.FindName("btnCopyDash")));
            this.btnClear = ((System.Windows.Controls.Button)(this.FindName("btnClear")));
            this.waitCursor = ((System.Windows.Controls.Grid)(this.FindName("waitCursor")));
            this.BusyIndicator = ((System.Windows.Controls.BusyIndicator)(this.FindName("BusyIndicator")));
        }
    }
}

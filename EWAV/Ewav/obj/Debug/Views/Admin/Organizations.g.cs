﻿#pragma checksum "C:\_CODE\EVAW-CC-TEMP\Ewav\Ewav\Views\Admin\Organizations.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9AF7CD00A045DCCE2E47FF4B35B9C0D5"
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
    
    
    public partial class Organizations : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid HeaderGrid;
        
        internal System.Windows.Shapes.Rectangle GHeader;
        
        internal System.Windows.Controls.StackPanel spOrganizationList;
        
        internal System.Windows.Controls.StackPanel spMsg;
        
        internal System.Windows.Controls.Image imgerrMsg;
        
        internal System.Windows.Controls.Image imgSMsg;
        
        internal System.Windows.Controls.TextBlock SucessMsg;
        
        internal System.Windows.Controls.Button btnAddOrg;
        
        internal System.Windows.Controls.DataGrid dgOrg;
        
        internal System.Windows.Controls.StackPanel spOrganizationEdit;
        
        internal System.Windows.Controls.TextBox tbOrganizationName;
        
        internal System.Windows.Controls.ComboBox cboActive;
        
        internal System.Windows.Controls.StackPanel spUser;
        
        internal System.Windows.Controls.TextBlock txtOrgAdmin;
        
        internal System.Windows.Controls.Grid grdWindows;
        
        internal System.Windows.Controls.TextBox tbEmailAddress;
        
        internal System.Windows.Controls.Button btnSearch;
        
        internal System.Windows.Controls.TextBox tbUserId;
        
        internal System.Windows.Controls.Grid grdForms;
        
        internal System.Windows.Controls.AutoCompleteBox autoEmail;
        
        internal System.Windows.Controls.TextBox tbFirstName;
        
        internal System.Windows.Controls.TextBox tbLastName;
        
        internal System.Windows.Controls.TextBox tbPhone;
        
        internal System.Windows.Controls.Button btnSaveOrgDetails;
        
        internal System.Windows.Controls.Button btnCancelOrgDetails;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/EWAVD3;component/Views/Admin/Organizations.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.HeaderGrid = ((System.Windows.Controls.Grid)(this.FindName("HeaderGrid")));
            this.GHeader = ((System.Windows.Shapes.Rectangle)(this.FindName("GHeader")));
            this.spOrganizationList = ((System.Windows.Controls.StackPanel)(this.FindName("spOrganizationList")));
            this.spMsg = ((System.Windows.Controls.StackPanel)(this.FindName("spMsg")));
            this.imgerrMsg = ((System.Windows.Controls.Image)(this.FindName("imgerrMsg")));
            this.imgSMsg = ((System.Windows.Controls.Image)(this.FindName("imgSMsg")));
            this.SucessMsg = ((System.Windows.Controls.TextBlock)(this.FindName("SucessMsg")));
            this.btnAddOrg = ((System.Windows.Controls.Button)(this.FindName("btnAddOrg")));
            this.dgOrg = ((System.Windows.Controls.DataGrid)(this.FindName("dgOrg")));
            this.spOrganizationEdit = ((System.Windows.Controls.StackPanel)(this.FindName("spOrganizationEdit")));
            this.tbOrganizationName = ((System.Windows.Controls.TextBox)(this.FindName("tbOrganizationName")));
            this.cboActive = ((System.Windows.Controls.ComboBox)(this.FindName("cboActive")));
            this.spUser = ((System.Windows.Controls.StackPanel)(this.FindName("spUser")));
            this.txtOrgAdmin = ((System.Windows.Controls.TextBlock)(this.FindName("txtOrgAdmin")));
            this.grdWindows = ((System.Windows.Controls.Grid)(this.FindName("grdWindows")));
            this.tbEmailAddress = ((System.Windows.Controls.TextBox)(this.FindName("tbEmailAddress")));
            this.btnSearch = ((System.Windows.Controls.Button)(this.FindName("btnSearch")));
            this.tbUserId = ((System.Windows.Controls.TextBox)(this.FindName("tbUserId")));
            this.grdForms = ((System.Windows.Controls.Grid)(this.FindName("grdForms")));
            this.autoEmail = ((System.Windows.Controls.AutoCompleteBox)(this.FindName("autoEmail")));
            this.tbFirstName = ((System.Windows.Controls.TextBox)(this.FindName("tbFirstName")));
            this.tbLastName = ((System.Windows.Controls.TextBox)(this.FindName("tbLastName")));
            this.tbPhone = ((System.Windows.Controls.TextBox)(this.FindName("tbPhone")));
            this.btnSaveOrgDetails = ((System.Windows.Controls.Button)(this.FindName("btnSaveOrgDetails")));
            this.btnCancelOrgDetails = ((System.Windows.Controls.Button)(this.FindName("btnCancelOrgDetails")));
            this.waitCursor = ((System.Windows.Controls.Grid)(this.FindName("waitCursor")));
            this.BusyIndicator = ((System.Windows.Controls.BusyIndicator)(this.FindName("BusyIndicator")));
        }
    }
}


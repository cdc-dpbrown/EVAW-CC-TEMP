﻿#pragma checksum "C:\_CODE\EVAW-CC-TEMP\Ewav\Ewav\Views\Admin\AddEditUser.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A379D857DC1F24FF0CEC9BDEC8D344F2"
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
    
    
    public partial class AddEditUser : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Media.Animation.Storyboard Storyboard1;
        
        internal System.Windows.Media.Animation.Storyboard Storyboard2;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel spMsg;
        
        internal System.Windows.Controls.TextBlock ErrMsg;
        
        internal System.Windows.Controls.StackPanel spWiz;
        
        internal System.Windows.Controls.StackPanel spStep1;
        
        internal System.Windows.Controls.TextBlock tbStep1;
        
        internal System.Windows.Shapes.Rectangle rectStep1;
        
        internal System.Windows.Controls.StackPanel spStep2;
        
        internal System.Windows.Controls.TextBlock tbStep2;
        
        internal System.Windows.Shapes.Rectangle rectStep2;
        
        internal System.Windows.Controls.StackPanel spSource;
        
        internal System.Windows.Controls.Grid grdEmail;
        
        internal System.Windows.Controls.AutoCompleteBox autoEmail;
        
        internal System.Windows.Controls.Grid grdUserId;
        
        internal System.Windows.Controls.TextBox tbEmailAddress;
        
        internal System.Windows.Controls.TextBox tbUserID;
        
        internal System.Windows.Controls.Button btnSearch;
        
        internal System.Windows.Controls.TextBox tbFirstName;
        
        internal System.Windows.Controls.TextBox tbLastName;
        
        internal System.Windows.Controls.TextBox tbPhone;
        
        internal System.Windows.Controls.TextBlock OrgName;
        
        internal System.Windows.Controls.StackPanel spRole;
        
        internal System.Windows.Controls.ComboBox cmbRole;
        
        internal System.Windows.Controls.ComboBox cmbActive;
        
        internal System.Windows.Controls.Button btnStep1Next;
        
        internal System.Windows.Controls.Button btnCancel1;
        
        internal System.Windows.Controls.StackPanel spAssocUser;
        
        internal System.Windows.Controls.TextBlock txtAdminDS;
        
        internal System.Windows.Controls.StackPanel spDatasource;
        
        internal System.Windows.Controls.ListBox lbxAvailable;
        
        internal System.Windows.Controls.Button btnAddSource;
        
        internal System.Windows.Controls.Button btnRemoveSource;
        
        internal System.Windows.Controls.ListBox lbxSelected;
        
        internal System.Windows.Controls.Button btnFinish;
        
        internal System.Windows.Controls.Button btnCancel3;
        
        internal System.Windows.Controls.Button btnCancel1_Copy;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/EWAVD3;component/Views/Admin/AddEditUser.xaml", System.UriKind.Relative));
            this.Storyboard1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard1")));
            this.Storyboard2 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard2")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.spMsg = ((System.Windows.Controls.StackPanel)(this.FindName("spMsg")));
            this.ErrMsg = ((System.Windows.Controls.TextBlock)(this.FindName("ErrMsg")));
            this.spWiz = ((System.Windows.Controls.StackPanel)(this.FindName("spWiz")));
            this.spStep1 = ((System.Windows.Controls.StackPanel)(this.FindName("spStep1")));
            this.tbStep1 = ((System.Windows.Controls.TextBlock)(this.FindName("tbStep1")));
            this.rectStep1 = ((System.Windows.Shapes.Rectangle)(this.FindName("rectStep1")));
            this.spStep2 = ((System.Windows.Controls.StackPanel)(this.FindName("spStep2")));
            this.tbStep2 = ((System.Windows.Controls.TextBlock)(this.FindName("tbStep2")));
            this.rectStep2 = ((System.Windows.Shapes.Rectangle)(this.FindName("rectStep2")));
            this.spSource = ((System.Windows.Controls.StackPanel)(this.FindName("spSource")));
            this.grdEmail = ((System.Windows.Controls.Grid)(this.FindName("grdEmail")));
            this.autoEmail = ((System.Windows.Controls.AutoCompleteBox)(this.FindName("autoEmail")));
            this.grdUserId = ((System.Windows.Controls.Grid)(this.FindName("grdUserId")));
            this.tbEmailAddress = ((System.Windows.Controls.TextBox)(this.FindName("tbEmailAddress")));
            this.tbUserID = ((System.Windows.Controls.TextBox)(this.FindName("tbUserID")));
            this.btnSearch = ((System.Windows.Controls.Button)(this.FindName("btnSearch")));
            this.tbFirstName = ((System.Windows.Controls.TextBox)(this.FindName("tbFirstName")));
            this.tbLastName = ((System.Windows.Controls.TextBox)(this.FindName("tbLastName")));
            this.tbPhone = ((System.Windows.Controls.TextBox)(this.FindName("tbPhone")));
            this.OrgName = ((System.Windows.Controls.TextBlock)(this.FindName("OrgName")));
            this.spRole = ((System.Windows.Controls.StackPanel)(this.FindName("spRole")));
            this.cmbRole = ((System.Windows.Controls.ComboBox)(this.FindName("cmbRole")));
            this.cmbActive = ((System.Windows.Controls.ComboBox)(this.FindName("cmbActive")));
            this.btnStep1Next = ((System.Windows.Controls.Button)(this.FindName("btnStep1Next")));
            this.btnCancel1 = ((System.Windows.Controls.Button)(this.FindName("btnCancel1")));
            this.spAssocUser = ((System.Windows.Controls.StackPanel)(this.FindName("spAssocUser")));
            this.txtAdminDS = ((System.Windows.Controls.TextBlock)(this.FindName("txtAdminDS")));
            this.spDatasource = ((System.Windows.Controls.StackPanel)(this.FindName("spDatasource")));
            this.lbxAvailable = ((System.Windows.Controls.ListBox)(this.FindName("lbxAvailable")));
            this.btnAddSource = ((System.Windows.Controls.Button)(this.FindName("btnAddSource")));
            this.btnRemoveSource = ((System.Windows.Controls.Button)(this.FindName("btnRemoveSource")));
            this.lbxSelected = ((System.Windows.Controls.ListBox)(this.FindName("lbxSelected")));
            this.btnFinish = ((System.Windows.Controls.Button)(this.FindName("btnFinish")));
            this.btnCancel3 = ((System.Windows.Controls.Button)(this.FindName("btnCancel3")));
            this.btnCancel1_Copy = ((System.Windows.Controls.Button)(this.FindName("btnCancel1_Copy")));
        }
    }
}


﻿#pragma checksum "C:\_CODE\EVAW-CC-TEMP\Ewav\Ewav\Views\Admin\AddEditDataSources.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0789A000AB24A5132C836A62CE2138B1"
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
    
    
    public partial class AddEditDataSources : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Media.Animation.Storyboard Storyboard1;
        
        internal System.Windows.Media.Animation.Storyboard Storyboard2;
        
        internal System.Windows.Media.Animation.Storyboard Storyboard3;
        
        internal System.Windows.Media.Animation.Storyboard Storyboard4;
        
        internal System.Windows.Media.Animation.Storyboard Storyboard5;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel spMsg;
        
        internal System.Windows.Controls.TextBlock errMsg;
        
        internal System.Windows.Controls.TextBox tbDSName;
        
        internal System.Windows.Controls.RadioButton radEnable;
        
        internal System.Windows.Controls.RadioButton radDisable;
        
        internal System.Windows.Controls.StackPanel spWiz;
        
        internal System.Windows.Controls.StackPanel spStep1;
        
        internal System.Windows.Controls.TextBlock tbStep1;
        
        internal System.Windows.Shapes.Rectangle rectStep1;
        
        internal System.Windows.Controls.StackPanel spStep2;
        
        internal System.Windows.Controls.TextBlock tbStep2;
        
        internal System.Windows.Shapes.Rectangle rectStep2;
        
        internal System.Windows.Controls.StackPanel spStep3;
        
        internal System.Windows.Controls.TextBlock tbStep3;
        
        internal System.Windows.Shapes.Rectangle rectStep3;
        
        internal System.Windows.Controls.StackPanel spSource;
        
        internal System.Windows.Controls.ComboBox cmbDBType;
        
        internal System.Windows.Controls.CheckBox chkEpiForm;
        
        internal System.Windows.Controls.TextBox tbServerName;
        
        internal System.Windows.Controls.TextBox tbPort;
        
        internal System.Windows.Controls.TextBox tbDbName;
        
        internal System.Windows.Controls.TextBox tbUserId;
        
        internal System.Windows.Controls.PasswordBox tbPassword;
        
        internal System.Windows.Controls.Button btnTestConn;
        
        internal System.Windows.Controls.Button btnStep1Next;
        
        internal System.Windows.Controls.Button btnCancel1;
        
        internal System.Windows.Controls.StackPanel spTable;
        
        internal System.Windows.Controls.StackPanel spDBInfo;
        
        internal System.Windows.Controls.StackPanel spDBObject;
        
        internal System.Windows.Controls.RadioButton radTableNm;
        
        internal System.Windows.Controls.RadioButton radSql;
        
        internal System.Windows.Controls.StackPanel spTableName;
        
        internal System.Windows.Controls.TextBox tbTableName;
        
        internal System.Windows.Controls.TextBox tbScript;
        
        internal System.Windows.Controls.StackPanel spSql;
        
        internal System.Windows.Controls.RichTextBox tbSqlScript;
        
        internal System.Windows.Controls.StackPanel spEIWS;
        
        internal System.Windows.Controls.TextBox tbSurveyId;
        
        internal System.Windows.Controls.TextBox tbSecurityToken;
        
        internal System.Windows.Controls.Button btnTestData;
        
        internal System.Windows.Controls.Button btnStep2Next;
        
        internal System.Windows.Controls.Button btnCancel2;
        
        internal System.Windows.Controls.Button btnCancel1_Copy;
        
        internal System.Windows.Controls.StackPanel spAssocUser;
        
        internal System.Windows.Controls.ListBox lbxAvailable;
        
        internal System.Windows.Controls.Button btnAddSource;
        
        internal System.Windows.Controls.Button btnRemoveSource;
        
        internal System.Windows.Controls.ListBox lbxSelected;
        
        internal System.Windows.Controls.Button btnFinish;
        
        internal System.Windows.Controls.Button btnCancel3;
        
        internal System.Windows.Controls.Button btnCancel1_Copy1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/EWAVD3;component/Views/Admin/AddEditDataSources.xaml", System.UriKind.Relative));
            this.Storyboard1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard1")));
            this.Storyboard2 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard2")));
            this.Storyboard3 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard3")));
            this.Storyboard4 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard4")));
            this.Storyboard5 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard5")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.spMsg = ((System.Windows.Controls.StackPanel)(this.FindName("spMsg")));
            this.errMsg = ((System.Windows.Controls.TextBlock)(this.FindName("errMsg")));
            this.tbDSName = ((System.Windows.Controls.TextBox)(this.FindName("tbDSName")));
            this.radEnable = ((System.Windows.Controls.RadioButton)(this.FindName("radEnable")));
            this.radDisable = ((System.Windows.Controls.RadioButton)(this.FindName("radDisable")));
            this.spWiz = ((System.Windows.Controls.StackPanel)(this.FindName("spWiz")));
            this.spStep1 = ((System.Windows.Controls.StackPanel)(this.FindName("spStep1")));
            this.tbStep1 = ((System.Windows.Controls.TextBlock)(this.FindName("tbStep1")));
            this.rectStep1 = ((System.Windows.Shapes.Rectangle)(this.FindName("rectStep1")));
            this.spStep2 = ((System.Windows.Controls.StackPanel)(this.FindName("spStep2")));
            this.tbStep2 = ((System.Windows.Controls.TextBlock)(this.FindName("tbStep2")));
            this.rectStep2 = ((System.Windows.Shapes.Rectangle)(this.FindName("rectStep2")));
            this.spStep3 = ((System.Windows.Controls.StackPanel)(this.FindName("spStep3")));
            this.tbStep3 = ((System.Windows.Controls.TextBlock)(this.FindName("tbStep3")));
            this.rectStep3 = ((System.Windows.Shapes.Rectangle)(this.FindName("rectStep3")));
            this.spSource = ((System.Windows.Controls.StackPanel)(this.FindName("spSource")));
            this.cmbDBType = ((System.Windows.Controls.ComboBox)(this.FindName("cmbDBType")));
            this.chkEpiForm = ((System.Windows.Controls.CheckBox)(this.FindName("chkEpiForm")));
            this.tbServerName = ((System.Windows.Controls.TextBox)(this.FindName("tbServerName")));
            this.tbPort = ((System.Windows.Controls.TextBox)(this.FindName("tbPort")));
            this.tbDbName = ((System.Windows.Controls.TextBox)(this.FindName("tbDbName")));
            this.tbUserId = ((System.Windows.Controls.TextBox)(this.FindName("tbUserId")));
            this.tbPassword = ((System.Windows.Controls.PasswordBox)(this.FindName("tbPassword")));
            this.btnTestConn = ((System.Windows.Controls.Button)(this.FindName("btnTestConn")));
            this.btnStep1Next = ((System.Windows.Controls.Button)(this.FindName("btnStep1Next")));
            this.btnCancel1 = ((System.Windows.Controls.Button)(this.FindName("btnCancel1")));
            this.spTable = ((System.Windows.Controls.StackPanel)(this.FindName("spTable")));
            this.spDBInfo = ((System.Windows.Controls.StackPanel)(this.FindName("spDBInfo")));
            this.spDBObject = ((System.Windows.Controls.StackPanel)(this.FindName("spDBObject")));
            this.radTableNm = ((System.Windows.Controls.RadioButton)(this.FindName("radTableNm")));
            this.radSql = ((System.Windows.Controls.RadioButton)(this.FindName("radSql")));
            this.spTableName = ((System.Windows.Controls.StackPanel)(this.FindName("spTableName")));
            this.tbTableName = ((System.Windows.Controls.TextBox)(this.FindName("tbTableName")));
            this.tbScript = ((System.Windows.Controls.TextBox)(this.FindName("tbScript")));
            this.spSql = ((System.Windows.Controls.StackPanel)(this.FindName("spSql")));
            this.tbSqlScript = ((System.Windows.Controls.RichTextBox)(this.FindName("tbSqlScript")));
            this.spEIWS = ((System.Windows.Controls.StackPanel)(this.FindName("spEIWS")));
            this.tbSurveyId = ((System.Windows.Controls.TextBox)(this.FindName("tbSurveyId")));
            this.tbSecurityToken = ((System.Windows.Controls.TextBox)(this.FindName("tbSecurityToken")));
            this.btnTestData = ((System.Windows.Controls.Button)(this.FindName("btnTestData")));
            this.btnStep2Next = ((System.Windows.Controls.Button)(this.FindName("btnStep2Next")));
            this.btnCancel2 = ((System.Windows.Controls.Button)(this.FindName("btnCancel2")));
            this.btnCancel1_Copy = ((System.Windows.Controls.Button)(this.FindName("btnCancel1_Copy")));
            this.spAssocUser = ((System.Windows.Controls.StackPanel)(this.FindName("spAssocUser")));
            this.lbxAvailable = ((System.Windows.Controls.ListBox)(this.FindName("lbxAvailable")));
            this.btnAddSource = ((System.Windows.Controls.Button)(this.FindName("btnAddSource")));
            this.btnRemoveSource = ((System.Windows.Controls.Button)(this.FindName("btnRemoveSource")));
            this.lbxSelected = ((System.Windows.Controls.ListBox)(this.FindName("lbxSelected")));
            this.btnFinish = ((System.Windows.Controls.Button)(this.FindName("btnFinish")));
            this.btnCancel3 = ((System.Windows.Controls.Button)(this.FindName("btnCancel3")));
            this.btnCancel1_Copy1 = ((System.Windows.Controls.Button)(this.FindName("btnCancel1_Copy1")));
            this.waitCursor = ((System.Windows.Controls.Grid)(this.FindName("waitCursor")));
            this.BusyIndicator = ((System.Windows.Controls.BusyIndicator)(this.FindName("BusyIndicator")));
        }
    }
}


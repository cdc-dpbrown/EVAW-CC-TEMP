﻿#pragma checksum "C:\TFSCode\EWAV\Ewav\Ewav\Views\Dialogs\ForgotPwd.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6B7B366EC0D00777010E24180F8F63AA"
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
    
    
    public partial class ForgotPwd : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel spMsg;
        
        internal System.Windows.Controls.TextBlock tbErrMsg;
        
        internal System.Windows.Controls.Grid grdPwd;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.TextBox tbEmail;
        
        internal System.Windows.Controls.StackPanel spMsg_Success;
        
        internal System.Windows.Controls.Button btnLoginReturn;
        
        internal System.Windows.Controls.StackPanel spMsg_Error;
        
        internal System.Windows.Controls.Button btnLoginReturn1;
        
        internal System.Windows.Controls.BusyIndicator bsyInd;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ewav;component/Views/Dialogs/ForgotPwd.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.spMsg = ((System.Windows.Controls.StackPanel)(this.FindName("spMsg")));
            this.tbErrMsg = ((System.Windows.Controls.TextBlock)(this.FindName("tbErrMsg")));
            this.grdPwd = ((System.Windows.Controls.Grid)(this.FindName("grdPwd")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.tbEmail = ((System.Windows.Controls.TextBox)(this.FindName("tbEmail")));
            this.spMsg_Success = ((System.Windows.Controls.StackPanel)(this.FindName("spMsg_Success")));
            this.btnLoginReturn = ((System.Windows.Controls.Button)(this.FindName("btnLoginReturn")));
            this.spMsg_Error = ((System.Windows.Controls.StackPanel)(this.FindName("spMsg_Error")));
            this.btnLoginReturn1 = ((System.Windows.Controls.Button)(this.FindName("btnLoginReturn1")));
            this.bsyInd = ((System.Windows.Controls.BusyIndicator)(this.FindName("bsyInd")));
        }
    }
}


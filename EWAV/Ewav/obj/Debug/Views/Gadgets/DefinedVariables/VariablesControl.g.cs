﻿#pragma checksum "C:\TFSCode\EWAV\Ewav\Ewav\Views\Gadgets\DefinedVariables\VariablesControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "69B309D8A262C652E3D93ED7E3316D85"
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
    
    
    public partial class VariablesControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard rotatearrow;
        
        internal System.Windows.Media.Animation.Storyboard rotatearrow1;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Border VSlider;
        
        internal System.Windows.Controls.TextBlock VerticalHeading;
        
        internal System.Windows.Controls.Image imgSlide;
        
        internal System.Windows.Shapes.Rectangle RectSlideIn;
        
        internal System.Windows.Controls.TextBlock filterCount;
        
        internal System.Windows.Controls.Grid grdFormattingProperties;
        
        internal System.Windows.Controls.ScrollViewer scroll_content;
        
        internal System.Windows.Controls.StackPanel pnlContainer;
        
        internal System.Windows.Controls.ListBox lbxRules;
        
        internal System.Windows.Controls.Button btnRemoveRule;
        
        internal System.Windows.Controls.Button btnEditRule;
        
        internal System.Windows.Controls.Button btnNewRule;
        
        internal System.Windows.Controls.ContextMenu menuVar;
        
        internal System.Windows.Controls.MenuItem varRecode;
        
        internal System.Windows.Controls.MenuItem varFormat;
        
        internal System.Windows.Controls.MenuItem varSimple;
        
        internal System.Windows.Controls.MenuItem varAssign;
        
        internal System.Windows.Controls.MenuItem varCondition;
        
        internal System.Windows.Controls.MenuItem varGroup;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ewav;component/Views/Gadgets/DefinedVariables/VariablesControl.xaml", System.UriKind.Relative));
            this.rotatearrow = ((System.Windows.Media.Animation.Storyboard)(this.FindName("rotatearrow")));
            this.rotatearrow1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("rotatearrow1")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.VSlider = ((System.Windows.Controls.Border)(this.FindName("VSlider")));
            this.VerticalHeading = ((System.Windows.Controls.TextBlock)(this.FindName("VerticalHeading")));
            this.imgSlide = ((System.Windows.Controls.Image)(this.FindName("imgSlide")));
            this.RectSlideIn = ((System.Windows.Shapes.Rectangle)(this.FindName("RectSlideIn")));
            this.filterCount = ((System.Windows.Controls.TextBlock)(this.FindName("filterCount")));
            this.grdFormattingProperties = ((System.Windows.Controls.Grid)(this.FindName("grdFormattingProperties")));
            this.scroll_content = ((System.Windows.Controls.ScrollViewer)(this.FindName("scroll_content")));
            this.pnlContainer = ((System.Windows.Controls.StackPanel)(this.FindName("pnlContainer")));
            this.lbxRules = ((System.Windows.Controls.ListBox)(this.FindName("lbxRules")));
            this.btnRemoveRule = ((System.Windows.Controls.Button)(this.FindName("btnRemoveRule")));
            this.btnEditRule = ((System.Windows.Controls.Button)(this.FindName("btnEditRule")));
            this.btnNewRule = ((System.Windows.Controls.Button)(this.FindName("btnNewRule")));
            this.menuVar = ((System.Windows.Controls.ContextMenu)(this.FindName("menuVar")));
            this.varRecode = ((System.Windows.Controls.MenuItem)(this.FindName("varRecode")));
            this.varFormat = ((System.Windows.Controls.MenuItem)(this.FindName("varFormat")));
            this.varSimple = ((System.Windows.Controls.MenuItem)(this.FindName("varSimple")));
            this.varAssign = ((System.Windows.Controls.MenuItem)(this.FindName("varAssign")));
            this.varCondition = ((System.Windows.Controls.MenuItem)(this.FindName("varCondition")));
            this.varGroup = ((System.Windows.Controls.MenuItem)(this.FindName("varGroup")));
        }
    }
}


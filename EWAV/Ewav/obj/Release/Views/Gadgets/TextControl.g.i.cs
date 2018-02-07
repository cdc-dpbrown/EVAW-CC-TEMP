﻿#pragma checksum "C:\TFSCode\EWAV\Ewav\Ewav\Views\Gadgets\TextControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "39389B0832F6FAF7224F804337EEBFA4"
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
    
    
    public partial class TextControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid GadgetWindow;
        
        internal System.Windows.Shapes.Rectangle GWindow;
        
        internal System.Windows.Controls.Grid GadgetContentGrid;
        
        internal System.Windows.VisualStateGroup DragStates;
        
        internal System.Windows.VisualState Normal;
        
        internal System.Windows.VisualState DragOver;
        
        internal System.Windows.Controls.Border ApplicationBorder;
        
        internal System.Windows.Controls.Grid MainGrid;
        
        internal System.Windows.Shapes.Rectangle rct42;
        
        internal System.Windows.Controls.Grid ToolBarGrid;
        
        internal System.Windows.Controls.StackPanel spFontFam;
        
        internal System.Windows.Controls.ComboBox cmbFonts;
        
        internal System.Windows.Controls.ComboBox cmbFontSizes;
        
        internal System.Windows.Controls.StackPanel spBoldColor;
        
        internal System.Windows.Controls.ComboBox cmbFontColors;
        
        internal System.Windows.Controls.Button btnBold;
        
        internal System.Windows.Controls.Button btnItalic;
        
        internal System.Windows.Controls.Button btnUnderline;
        
        internal System.Windows.Controls.StackPanel spCutCopyPaste;
        
        internal System.Windows.Controls.Button btnPaste;
        
        internal System.Windows.Controls.Button btnCopy;
        
        internal System.Windows.Controls.Button btnCut;
        
        internal System.Windows.Controls.Button btnImage;
        
        internal System.Windows.Controls.Button btnHyperlink;
        
        internal System.Windows.Controls.Button btnDatagrid;
        
        internal System.Windows.Controls.Button btnCalendar;
        
        internal System.Windows.Controls.Button btnPrint;
        
        internal System.Windows.Controls.Primitives.ToggleButton btnRTL;
        
        internal System.Windows.Controls.Primitives.ToggleButton btnRO;
        
        internal System.Windows.Controls.Primitives.ToggleButton btnHighlight;
        
        internal System.Windows.Controls.Primitives.ToggleButton btnMarkUp;
        
        internal System.Windows.Controls.Button btnNew;
        
        internal System.Windows.Controls.Button btnOpen;
        
        internal System.Windows.Controls.Button btnSave;
        
        internal System.Windows.Controls.Grid RTBGrid;
        
        internal System.Windows.Controls.RichTextBox rtb;
        
        internal System.Windows.Controls.Canvas highlightCanvas;
        
        internal System.Windows.Controls.TextBox xamlTb;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ewav;component/Views/Gadgets/TextControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.GadgetWindow = ((System.Windows.Controls.Grid)(this.FindName("GadgetWindow")));
            this.GWindow = ((System.Windows.Shapes.Rectangle)(this.FindName("GWindow")));
            this.GadgetContentGrid = ((System.Windows.Controls.Grid)(this.FindName("GadgetContentGrid")));
            this.DragStates = ((System.Windows.VisualStateGroup)(this.FindName("DragStates")));
            this.Normal = ((System.Windows.VisualState)(this.FindName("Normal")));
            this.DragOver = ((System.Windows.VisualState)(this.FindName("DragOver")));
            this.ApplicationBorder = ((System.Windows.Controls.Border)(this.FindName("ApplicationBorder")));
            this.MainGrid = ((System.Windows.Controls.Grid)(this.FindName("MainGrid")));
            this.rct42 = ((System.Windows.Shapes.Rectangle)(this.FindName("rct42")));
            this.ToolBarGrid = ((System.Windows.Controls.Grid)(this.FindName("ToolBarGrid")));
            this.spFontFam = ((System.Windows.Controls.StackPanel)(this.FindName("spFontFam")));
            this.cmbFonts = ((System.Windows.Controls.ComboBox)(this.FindName("cmbFonts")));
            this.cmbFontSizes = ((System.Windows.Controls.ComboBox)(this.FindName("cmbFontSizes")));
            this.spBoldColor = ((System.Windows.Controls.StackPanel)(this.FindName("spBoldColor")));
            this.cmbFontColors = ((System.Windows.Controls.ComboBox)(this.FindName("cmbFontColors")));
            this.btnBold = ((System.Windows.Controls.Button)(this.FindName("btnBold")));
            this.btnItalic = ((System.Windows.Controls.Button)(this.FindName("btnItalic")));
            this.btnUnderline = ((System.Windows.Controls.Button)(this.FindName("btnUnderline")));
            this.spCutCopyPaste = ((System.Windows.Controls.StackPanel)(this.FindName("spCutCopyPaste")));
            this.btnPaste = ((System.Windows.Controls.Button)(this.FindName("btnPaste")));
            this.btnCopy = ((System.Windows.Controls.Button)(this.FindName("btnCopy")));
            this.btnCut = ((System.Windows.Controls.Button)(this.FindName("btnCut")));
            this.btnImage = ((System.Windows.Controls.Button)(this.FindName("btnImage")));
            this.btnHyperlink = ((System.Windows.Controls.Button)(this.FindName("btnHyperlink")));
            this.btnDatagrid = ((System.Windows.Controls.Button)(this.FindName("btnDatagrid")));
            this.btnCalendar = ((System.Windows.Controls.Button)(this.FindName("btnCalendar")));
            this.btnPrint = ((System.Windows.Controls.Button)(this.FindName("btnPrint")));
            this.btnRTL = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("btnRTL")));
            this.btnRO = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("btnRO")));
            this.btnHighlight = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("btnHighlight")));
            this.btnMarkUp = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("btnMarkUp")));
            this.btnNew = ((System.Windows.Controls.Button)(this.FindName("btnNew")));
            this.btnOpen = ((System.Windows.Controls.Button)(this.FindName("btnOpen")));
            this.btnSave = ((System.Windows.Controls.Button)(this.FindName("btnSave")));
            this.RTBGrid = ((System.Windows.Controls.Grid)(this.FindName("RTBGrid")));
            this.rtb = ((System.Windows.Controls.RichTextBox)(this.FindName("rtb")));
            this.highlightCanvas = ((System.Windows.Controls.Canvas)(this.FindName("highlightCanvas")));
            this.xamlTb = ((System.Windows.Controls.TextBox)(this.FindName("xamlTb")));
        }
    }
}


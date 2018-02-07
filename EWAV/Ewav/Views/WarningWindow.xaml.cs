﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace EWAV
{
    public partial class WarningWindow : ChildWindow
    {
        public WarningWindow(Exception e)
        {
            InitializeComponent();
            if (e != null)
            {
                //ErrorTextBox.Text = e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;
            }
        }

        public WarningWindow(Uri uri)
        {
            InitializeComponent();
            if (uri != null)
            {
                //ErrorTextBox.Text = "Page not found: \"" + uri.ToString() + "\"";
            }
        }

        public WarningWindow(string message, string details)
        {
            InitializeComponent();
//            ErrorTextBox.Text = message + Environment.NewLine + Environment.NewLine + details;

//#if DEBUG
//            ContentStackPanel.Visibility = System.Windows.Visibility.Visible;
//#endif
            IntroductoryText.Text = message;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FormValidatorDemo.UserControls
{
    public sealed partial class DateTimeFieldInput : UserControl
    {
        public DateTimeFieldInput()
        {
            this.InitializeComponent();
        }

        private void control_LostFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.DateTimeFieldInputViewModel viewModel = this.DataContext as ViewModel.DateTimeFieldInputViewModel;
            if (viewModel != null)
            {
                viewModel.ValidateData();
            }
        }
    }
}

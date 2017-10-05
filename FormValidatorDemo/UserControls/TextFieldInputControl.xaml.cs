using System;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FormValidatorDemo.UserControls
{
    public sealed partial class TextFieldInputControl : UserControl
    {
        public TextFieldInputControl()
        {
            this.InitializeComponent();
        }

        public event EventHandler FocusLost;

        private void control_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.TextFieldInputControlViewModel viewModel = this.DataContext as ViewModel.TextFieldInputControlViewModel;
            if (viewModel != null)
            {
                viewModel.ValidateData();
                FocusLost?.Invoke(this, null);
            }
        }
    }
}

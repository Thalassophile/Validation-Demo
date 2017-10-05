using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FormValidatorDemo.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrganizedAndDynamic : Page
    {
        public OrganizedAndDynamic()
        {
            this.InitializeComponent();
        }

        internal ObservableCollection<ComponentModel.IFormControl> FormFields
        {
            get
            {
                return new ObservableCollection<ComponentModel.IFormControl>(new List<ComponentModel.IFormControl>()
                {
                    new ViewModel.TextFieldInputControlViewModel(){HeaderName = "Name",PlaceholderText="e.g. John Doe",IsMandatory = true },
                    new ViewModel.TextFieldInputControlViewModel(){HeaderName = "Admin No" , PlaceholderText = "e.g. ABC123"},
                    new ViewModel.TextFieldInputControlViewModel(){HeaderName = "Phone" , PlaceholderText = "e.g. +32538349182" ,IsMandatory = true,MatchingPattern = @"^[\+]?[1-9]{1,3}\s?[0-9]{6,11}$"},
                    new ViewModel.TextFieldInputControlViewModel(){HeaderName = "Item Description", PlaceholderText = "e.g. My Fav Item",IsMandatory = true },
                    new ViewModel.TextFieldInputControlViewModel(){HeaderName = "Location Lost", PlaceholderText = "e.g. Alaska",IsMandatory = true },
                    new ViewModel.DateTimeFieldInputViewModel(){ HeaderName = "Date Lost",IsMandatory = true}
                });
            }
        }

        private async void ValidateContent(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //just check for 1 invalid field as only 1 is enough to break the flow. 
            var invalidField = FormFields.FirstOrDefault(x => x.IsError);
            if (invalidField != null)
            {
                //handle error here!!
                MessageDialog messageDialog = new MessageDialog("Please check the above values for invalid data");
                await messageDialog.ShowAsync();
            }
        }
    }
}

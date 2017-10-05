using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FormValidatorDemo.Helpers
{
    internal class FormTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TemplateWithDate { get; set; }
        public DataTemplate TemplateWithText { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item as ViewModel.DateTimeFieldInputViewModel != null)
                return TemplateWithDate;
            if (item as ViewModel.TextFieldInputControlViewModel != null)
                return TemplateWithText;

            return base.SelectTemplateCore(item, container);
        }
    }
}

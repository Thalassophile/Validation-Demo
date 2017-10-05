using FormValidatorDemo.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormValidatorDemo.ViewModel
{
    public class TextFieldInputControlViewModel : INotifyPropertyChanged, IFormControl
    {
        private bool isError;
        public bool IsError
        {
            get { return isError; }
            set
            {
                if (value == isError)
                    return;

                isError = value;
                RaisePropertyChanged(nameof(IsError));
            }
        }

        private string headerName;
        public string HeaderName
        {
            get { return headerName; }
            set
            {
                if (value == headerName)
                    return;
                headerName = value;
                RaisePropertyChanged(nameof(HeaderName));
            }
        }

        private string controlContent;
        public string ControlContent
        {
            get { return controlContent; }
            set
            {
                if (value == controlContent)
                    return;

                controlContent = value;
                ValueInitialized = true;
                RaisePropertyChanged(nameof(ControlContent));
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (value != errorMessage)
                {
                    errorMessage = value;
                    RaisePropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        private string placeholderText;
        public string PlaceholderText
        {
            get { return placeholderText; }
            set { placeholderText = value; RaisePropertyChanged(nameof(PlaceholderText)); }
        }

        public bool IsMandatory { get; set; }

        public string MatchingPattern { get; set; }

        public bool ValueInitialized { get; set; } = false;

        public void ValidateData()
        {
            IsError = false;

            if (IsMandatory && string.IsNullOrEmpty(ControlContent))
            {
                IsError = true;
                ErrorMessage = $"{HeaderName} cannot be empty.";
                return;
            }

            if (!string.IsNullOrEmpty(MatchingPattern) && !Regex.IsMatch(ControlContent, MatchingPattern))
            {
                IsError = true;
                ErrorMessage = $"{HeaderName} is invalid.";

                return;
            }

            IsError = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using FormValidatorDemo.ComponentModel;
using System;
using System.ComponentModel;

namespace FormValidatorDemo.ViewModel
{
    internal class DateTimeFieldInputViewModel : INotifyPropertyChanged, IFormControl
    {

        public DateTimeFieldInputViewModel()
        {
            ValueInitialized = false;
        }

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

        public bool IsMandatory { get; set; }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; ValueInitialized = true; RaisePropertyChanged(nameof(SelectedDate)); }
        }

        public bool ValueInitialized { get; set; }

        public void ValidateData()
        {
            IsError = false;

            if (IsMandatory && SelectedDate.Date.Year < DateTime.Now.Year)
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

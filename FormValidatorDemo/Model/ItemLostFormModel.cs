using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormValidatorDemo.Model
{
    internal class ItemLostFormModel
    {
        private int itemID;
        public int ItemID
        {
            get { return itemID; }
            private set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Item ID cannot be less than 1");
                itemID = value;
            }
        }


        private string itemDescription;
        public string ItemDescription
        {
            get { return itemDescription; }
            private set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                    throw new ArgumentNullException("Please enter your item description.");
                itemDescription = value;
            }
        }


        private string locationLost;
        public string LocationLost
        {
            get { return locationLost; }
            private set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                    throw new ArgumentNullException("Please enter the location.");
                locationLost = value;
            }
        }


        private string personName;
        public string PersonName
        {
            get { return personName; }
            private set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                    throw new ArgumentNullException("Please enter your name.");
                personName = value;
            }
        }


        public string contactNo;
        public string ContactNo
        {
            get { return contactNo; }
            private set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                    throw new ArgumentNullException("Please enter your contact no.");
                else if (!Regex.IsMatch(contactNo, @"^[\+]?[1-9]{1,3}\s?[0-9]{6,11}$"))
                    throw new FormatException("Please enter a valid phone number.");
                contactNo = value;
            }
        }


        private string adminNo;
        public string AdminNo
        {
            get { return adminNo; }
            private set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                    throw new ArgumentNullException("Please enter your admin no.");
                else if (!Regex.IsMatch(adminNo, @"^[1-9]{1}[0-9]{5}[a-zA-Z]{1}$"))
                    throw new FormatException("Please enter a valid admin no.");
                adminNo = value;
            }
        }


        private DateTime dateLost;
        public DateTime DateLost
        {
            get { return dateLost; }
            private set
            {
                if (value == null || value == new DateTime())
                    throw new ArgumentNullException("Please select time");
                dateLost = value;
            }
        }


        public DateTime CreatedDate
        {
            get
            {
                return DateTime.Now.Date;
            }
        }

        /// <summary>
        /// Handles the data insertion and error handling.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="itemDescription"></param>
        /// <param name="locationLost"></param>
        /// <param name="personName"></param>
        /// <param name="contactNo"></param>
        /// <param name="adminNo"></param>
        /// <param name="dateLost"></param>
        /// <returns></returns>
        internal IEnumerable<ValidationError> GetValidationError(int itemID, string itemDescription, string locationLost, string personName, string contactNo, string adminNo, DateTime dateLost)
        {
            ICollection<ValidationError> errorList = new List<ValidationError>();

            //check for ItemID errors
            try { ItemID = itemID; }
            catch (Exception ex) { errorList.Add(new ValidationError() { ErrorType = ValidationErrors.ID, ErrorMessage = ex.Message }); }

            //check for ItemDescription errors
            try { ItemDescription = itemDescription; }
            catch (Exception ex) { errorList.Add(new ValidationError() { ErrorType = ValidationErrors.Description, ErrorMessage = ex.Message }); }

            //check for LocationLost errors
            try { LocationLost = locationLost; }
            catch (Exception ex) { errorList.Add(new ValidationError() { ErrorType = ValidationErrors.LocationLost, ErrorMessage = ex.Message }); }

            //check for PersonName errors
            try { PersonName = personName; }
            catch (Exception ex) { errorList.Add(new ValidationError() { ErrorType = ValidationErrors.PersonName, ErrorMessage = ex.Message }); }

            //check for ContactNo errors
            try { ContactNo = contactNo; }
            catch (Exception ex) { errorList.Add(new ValidationError() { ErrorType = ValidationErrors.ContactNo, ErrorMessage = ex.Message }); }

            //check for AdminNo errors
            try { AdminNo = adminNo; }
            catch (Exception ex) { errorList.Add(new ValidationError() { ErrorType = ValidationErrors.AdminNo, ErrorMessage = ex.Message }); }

            //check for DateLost errors
            try { DateLost = dateLost; }
            catch (Exception ex) { errorList.Add(new ValidationError() { ErrorType = ValidationErrors.DateLost, ErrorMessage = ex.Message }); }

            if (errorList.Count == 0)
                return null;

            return errorList;
        }

    }
}

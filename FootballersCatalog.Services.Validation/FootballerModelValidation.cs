using FootballersCatalog.Services.Interfaces;
using System;

namespace FootballersCatalog.Services.Validation
{
    public class FootballerModelValidation : IValidation
    {
        public FootballerModelValidation() { }

        public bool ValidateFootballerForm(string firstName, string lastName,
            string middleName, string birthDate, string gender)
        {
            return ValidateString(firstName)
                && ValidateString(lastName)
                && ValidateString(middleName)
                && ValidateString(birthDate)
                && ValidateBirthDate(birthDate)
                && ValidateString(gender);
        }

        private bool ValidateString(string stringValue)
        {
            return !string.IsNullOrWhiteSpace(stringValue);
        }

        private bool ValidateBirthDate(string birthDate)
        {
            var date = birthDate.Split(".");
            if (date.Length != 3 
                || int.TryParse(date[0], out int day) == false
                || int.TryParse(date[1], out int month) == false
                || int.TryParse(date[2], out int year) == false)
            {
                return false;
            }

            var currentDate = DateTime.Now;

            if ((currentDate.Year - year > 5 && currentDate.Year - year < 100)
                || (currentDate.Year - year == 5 && CheckDateMin(currentDate, month, day))
                || (currentDate.Year - year == 100 && CheckDateMax(currentDate, month, day)))
            {
                return true;
            }

            return false;
        }

        private bool CheckDateMin(DateTime currentDate, int month, int day)
        {
            var monthDif = currentDate.Month - month;
            return monthDif < 0 
                || (monthDif == 0 && day - currentDate.Day < 0);
        }

        private bool CheckDateMax(DateTime currentDate, int month, int day)
        {
            var monthDif = currentDate.Month - month;
            return monthDif > 0 
                || (monthDif == 0 && day - currentDate.Day > 0);
        }
    }
}

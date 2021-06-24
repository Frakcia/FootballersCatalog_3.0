

namespace FootballersCatalog.Services.Interfaces
{
    public interface IValidation
    {
        bool ValidateFootballerForm(string firstName, string lastName,
            string middleName, string birthDate, string gender);
    }
}

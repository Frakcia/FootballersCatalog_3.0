

namespace FootballersCatalog.Domain.Core.Entities
{
    public class Footballer
    {
        public Footballer() { }

        public Footballer(string lastName, string firstName,
            string middleName, string gender, string birthDate)
        {
            Name = lastName + " " + firstName + " " + middleName;
            Gender = gender;
            BirthDate = birthDate;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public virtual Team Team { get; set; }
        public virtual Country Country { get; set; }

        public void Edit(string firstName, string lastName, 
            string middleName, string gender, string birthDate)
        {
            Name = lastName + " " + firstName + " " + middleName;
            Gender = gender;
            BirthDate = birthDate;
        }
    }
}

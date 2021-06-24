using FootballersCatalog.Web.ViewModel.Team;

namespace FootballersCatalog.Web.ViewModel
{
    public class FootballerViewModel
    {
        public FootballerViewModel() { }
        public FootballerViewModel(int id, string name, string birthDate, 
            string gender, CountryViewModel countryViewModel, TeamViewModel teamViewModel)
        {
            Id = id;
            var namesParts = name.Split(" ");
            LastName = namesParts[0];
            FirstName = namesParts[1];
            MiddleName = namesParts[2];
            BirthDate = birthDate;
            Gender = gender;
            SelectedCountry = countryViewModel;
            SelectedTeam = teamViewModel;
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public CountryViewModel SelectedCountry
        {
            get { return selectedCountry ?? (selectedCountry = new CountryViewModel()); }
            set { selectedCountry = value; }
        }

        private CountryViewModel selectedCountry;

        public TeamViewModel SelectedTeam
        {
            get { return selectedTeam ?? (selectedTeam = new TeamViewModel()); }
            set { selectedTeam = value; }
        }

        private TeamViewModel selectedTeam;

    }
}

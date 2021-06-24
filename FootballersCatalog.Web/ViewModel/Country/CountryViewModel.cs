

namespace FootballersCatalog.Web.ViewModel
{
    public class CountryViewModel
    {
        public CountryViewModel() { }
        public CountryViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

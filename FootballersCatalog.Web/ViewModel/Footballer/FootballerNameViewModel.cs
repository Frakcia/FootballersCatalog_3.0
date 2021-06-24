

namespace FootballersCatalog.Web.ViewModel
{
    public class FootballerNameViewModel
    {
        public FootballerNameViewModel() { }
        public FootballerNameViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

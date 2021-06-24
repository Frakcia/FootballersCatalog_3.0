using System.Collections.Generic;

namespace FootballersCatalog.Web.ViewModel
{
    public class FootballerExtendedViewModel
    {
        public FootballerExtendedViewModel(IEnumerable<CountryViewModel> countryViewModels,
            IEnumerable<FootballerViewModel> footballerViewModel)
        {
            CountryViewModels = countryViewModels;
            FootballerViewModel = footballerViewModel;
        }
        public IEnumerable<FootballerViewModel> FootballerViewModel { get; set; }
        public IEnumerable<CountryViewModel> CountryViewModels { get; set; }
    }
}

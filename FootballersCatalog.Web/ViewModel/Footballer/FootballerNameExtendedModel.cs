using FootballersCatalog.Web.ViewModel.Team;
using System.Collections.Generic;

namespace FootballersCatalog.Web.ViewModel
{
    public class FootballerNameExtendedModel
    {
        public FootballerNameExtendedModel(IEnumerable<FootballerNameViewModel> footballerNameViewModels,
            IEnumerable<CountryViewModel> countryViewModels, IEnumerable<TeamViewModel> teamViewModels)
        {
            FootballerNameViewModels = footballerNameViewModels;
            CountryViewModels = countryViewModels;
            TeamViewModels = teamViewModels;
        }
        public IEnumerable<FootballerNameViewModel> FootballerNameViewModels { get; set; }
        public IEnumerable<CountryViewModel>  CountryViewModels { get; set; }
        public IEnumerable<TeamViewModel> TeamViewModels { get; set; }
    }
}

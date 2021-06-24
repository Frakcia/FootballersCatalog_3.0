using FootballersCatalog.Web.ViewModel.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballersCatalog.Web.ViewModel.CountryTeam
{
    public class CountryTeamViewModel
    {
        public CountryTeamViewModel(IEnumerable<CountryViewModel> countryViewModels, 
            IEnumerable<TeamViewModel> teamViewModels)
        {
            CountryViewModels = countryViewModels;
            TeamViewModels = teamViewModels;
        }
        public IEnumerable<CountryViewModel> CountryViewModels { get; set; }
        public IEnumerable<TeamViewModel> TeamViewModels { get; set; }
    }
}

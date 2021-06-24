using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballersCatalog.Web.ViewModel.Team
{
    public class TeamViewModel
    {
        public TeamViewModel() { }
        public TeamViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

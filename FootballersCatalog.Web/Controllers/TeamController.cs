using FootballersCatalog.Domain.Core.Entities;
using FootballersCatalog.Domain.Core.TransactionScopeFactory;
using FootballersCatalog.Interfaces.RepositoryInterfaces;
using FootballersCatalog.Services.Interfaces;
using FootballersCatalog.Web.Models;
using FootballersCatalog.Web.ViewModel.Team;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace FootballersCatalog.Web.Controllers
{
    public class TeamController : BaseController
    {
        public TeamController(IRepository _repository, IValidation _validator) 
            : base(_repository, _validator)
        {
        }

        public IActionResult Add(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) return Json(GetWrongResonseTeamModel());   
            
            var team = new Team(name);

            try
            {
                using (TransactionScope transactionScope = TransactionScopeFactory.Serializable())
                {
                    repository.Add(team);
                    repository.Save();
                    transactionScope.Complete();
                }
            }
            catch
            {
                return Json(GetWrongResonseTeamModel());
            }

            TeamResponseViewModel teamResponseViewModel =
                new TeamResponseViewModel(new ResponseModel(), new TeamViewModel(team.Id, team.Name));

            return Json(teamResponseViewModel);
        }

        private TeamResponseViewModel GetWrongResonseTeamModel()
        {
            return new TeamResponseViewModel(new ResponseModel(false, "Во время выполнения операции произошла ошибка")); 
        }
    }
}

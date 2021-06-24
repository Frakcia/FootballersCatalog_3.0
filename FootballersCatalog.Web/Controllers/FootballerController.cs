using FootballersCatalog.Domain.Core.Entities;
using FootballersCatalog.Domain.Core.TransactionScopeFactory;
using FootballersCatalog.Interfaces.RepositoryInterfaces;
using FootballersCatalog.Services.Interfaces;
using FootballersCatalog.Web.Models;
using FootballersCatalog.Web.ViewModel;
using FootballersCatalog.Web.ViewModel.CountryTeam;
using FootballersCatalog.Web.ViewModel.Team;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace FootballersCatalog.Web.Controllers
{
    public class FootballerController : BaseController
    {
        public FootballerController(IRepository _repository, IValidation _validator) 
            : base(_repository, _validator)
        {
        }

        public IActionResult AddFootballer()
        {           
            List<CountryViewModel> countryViewModels = repository.GetAll<Country>()
                .ToList().Select(c => new CountryViewModel(c.Id, c.Name)).ToList();

            List<TeamViewModel> teamViewModel = repository.GetAll<Team>()
                .ToList().Select(c => new TeamViewModel(c.Id, c.Name)).ToList();

            CountryTeamViewModel countryTeamViewModel = 
                new CountryTeamViewModel(countryViewModels, teamViewModel);

            return View(countryTeamViewModel);
        }

        private ResponseFootballerNameModel GetWrongResonseFootballerModel()
        {
            return new ResponseFootballerNameModel(new ResponseModel(false, "Произошла ошибка при сохранении"));
        }

        public IActionResult Add(FootballerViewModel footballerViewModel)
        {
            ResponseFootballerNameModel responseFootballerNameModel;

            if (!validator.ValidateFootballerForm(footballerViewModel.FirstName, footballerViewModel.LastName,
                footballerViewModel.MiddleName, footballerViewModel.BirthDate, footballerViewModel.Gender))
            {
                return Json(GetWrongResonseFootballerModel());
            }

            Footballer footbaler = new Footballer(footballerViewModel.LastName, footballerViewModel.FirstName,
                    footballerViewModel.MiddleName, footballerViewModel.Gender, footballerViewModel.BirthDate);

            var country = repository.GetById<Country>(footballerViewModel.SelectedCountry.Id);
            var team = repository.GetById<Team>(footballerViewModel.SelectedTeam.Id);

            try
            {
                using (TransactionScope transactionScope = TransactionScopeFactory.Serializable())
                {
                    country.Footballers.Add(footbaler);
                    team.Footballers.Add(footbaler);
                    repository.Save();
                    transactionScope.Complete();
                }
            }
            catch
            {
                return Json(GetWrongResonseFootballerModel());
            }       

            responseFootballerNameModel = new ResponseFootballerNameModel(
                new FootballerNameViewModel(footbaler.Id, footbaler.Name), new ResponseModel());

            return Json(responseFootballerNameModel);
        }

        public IActionResult EditFootballer()
        {
            List<CountryViewModel> countryViewModels = repository.GetAll<Country>()
                .ToList().Select(c => new CountryViewModel(c.Id, c.Name)).ToList();

            List<FootballerNameViewModel> footballersNamesViewModels = repository.GetAll<Footballer>()
                .Select(f => new FootballerNameViewModel(f.Id, f.Name)).ToList();

            List<TeamViewModel> teamViewModel = repository.GetAll<Team>()
                .ToList().Select(c => new TeamViewModel(c.Id, c.Name)).ToList();

            FootballerNameExtendedModel footballerNameExtendedModel =
                new FootballerNameExtendedModel(footballersNamesViewModels, countryViewModels, teamViewModel);

            return View(footballerNameExtendedModel);
        }

        public IActionResult GetData(int footballerId)
        {
            ResponseFootballerModel responseFootballerModel;
            FootballerViewModel footballerViewModel;

            try
            {
                var footballer = repository.GetById<Footballer>(footballerId);
                var country = repository.GetAll<Country>().Where(c => c.Footballers.Contains(footballer)).FirstOrDefault();
                var team = repository.GetAll<Team>().Where(c => c.Footballers.Contains(footballer)).FirstOrDefault();

                footballerViewModel = new FootballerViewModel(footballer.Id,
                    footballer.Name, footballer.BirthDate, footballer.Gender,
                    new CountryViewModel(footballer.Country.Id, footballer.Country.Name),
                    new TeamViewModel(footballer.Team.Id, footballer.Team.Name));
            }
            catch
            {
                return Json(new ResponseFootballerModel(null, new ResponseModel(false, "Произошла ошибка, при выполнении операции")));
            }

            responseFootballerModel = new ResponseFootballerModel(footballerViewModel, new ResponseModel());

            return Json(responseFootballerModel);
        }

        public IActionResult Edit(FootballerViewModel footballerViewModel)
        {
            if (!validator.ValidateFootballerForm(footballerViewModel.FirstName, footballerViewModel.LastName,
                footballerViewModel.MiddleName,  footballerViewModel.BirthDate, footballerViewModel.Gender))
            {
                return Json(GetWrongResonseFootballerModel());
            }

            ResponseFootballerNameModel responseFootballerNameModel;
            var footballer = repository.GetById<Footballer>(footballerViewModel.Id);
            var currentCountry = repository.GetAll<Country>().Where(c => c.Footballers.Contains(footballer)).FirstOrDefault();
            var country = repository.GetById<Country>(footballerViewModel.SelectedCountry.Id);
            var currentTeam = repository.GetAll<Team>().Where(c => c.Footballers.Contains(footballer)).FirstOrDefault();
            var team = repository.GetById<Team>(footballerViewModel.SelectedTeam.Id);

            try
            {
                using (TransactionScope transactionScope = TransactionScopeFactory.Serializable())
                {
                    if(currentCountry.Id != country.Id)
                    {
                        currentCountry.Footballers.Remove(footballer);
                        country.Footballers.Add(footballer);
                    }
                    if(currentTeam.Id != team.Id)
                    {
                        currentTeam.Footballers.Remove(footballer);
                        team.Footballers.Add(footballer);
                    }

                    footballer.Edit(footballerViewModel.FirstName, footballerViewModel.LastName,
                        footballerViewModel.MiddleName, footballerViewModel.Gender,
                        footballerViewModel.BirthDate);

                    repository.Save();
                    transactionScope.Complete();
                }
            }
            catch
            {
                return Json(GetWrongResonseFootballerModel());
            }

            responseFootballerNameModel = new ResponseFootballerNameModel(
                new FootballerNameViewModel(footballer.Id, footballer.Name), new ResponseModel());

            return Json(responseFootballerNameModel);
        }

        public IActionResult TeamModalWindowPartial()
        {
            return View();
        }
    }
}

using FootballersCatalog.Interfaces.RepositoryInterfaces;
using FootballersCatalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballersCatalog.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IRepository repository;
        protected readonly IValidation validator;
        public BaseController(IRepository _repository, IValidation _validator)
        {
            repository = _repository;
            validator = _validator;
        }
    }
}

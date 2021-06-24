using FootballersCatalog.Web.Models;

namespace FootballersCatalog.Web.ViewModel.Team
{
    public class TeamResponseViewModel
    {
        public TeamResponseViewModel(ResponseModel responseModel)
        {
            ResponseModel = responseModel;
        }
        public TeamResponseViewModel(ResponseModel responseModel, TeamViewModel teamViewModel)
        {
            ResponseModel = responseModel;
            TeamViewModel = teamViewModel;
        }


        public ResponseModel ResponseModel
        {
            get { return _responseModel ?? (_responseModel = new ResponseModel()); }
            set { _responseModel = value; }
        }
        private ResponseModel _responseModel;


        public TeamViewModel TeamViewModel
        {
            get { return _teamViewModel ?? (_teamViewModel = new TeamViewModel()); }
            set { _teamViewModel = value; }
        }
        private TeamViewModel _teamViewModel { get; set; }
    
}
}

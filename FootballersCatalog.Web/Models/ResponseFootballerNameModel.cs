using FootballersCatalog.Web.ViewModel;

namespace FootballersCatalog.Web.Models
{
    public class ResponseFootballerNameModel
    {
        public ResponseFootballerNameModel(FootballerNameViewModel footballerNameViewModel,
            ResponseModel responseModel)
        {
            FootballerNameViewModel = footballerNameViewModel;
            ResponseModel = responseModel;
        }

        public ResponseFootballerNameModel(ResponseModel responseModel)
        {
            ResponseModel = responseModel;
        }
        public FootballerNameViewModel FootballerNameViewModel { get; set; }
        public ResponseModel ResponseModel { get; set; }
    }
}

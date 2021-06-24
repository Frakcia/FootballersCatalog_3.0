using FootballersCatalog.Web.ViewModel;

namespace FootballersCatalog.Web.Models
{
    public class ResponseFootballerModel
    {
        public ResponseFootballerModel() { }

        public ResponseFootballerModel(FootballerViewModel footballerViewModel, ResponseModel responseModel)
        {
            FootballerViewModel = footballerViewModel;
            ResponseModel = responseModel;
        }

        public ResponseFootballerModel(ResponseModel responseModel)
        {
            ResponseModel = responseModel;
        }
        public FootballerViewModel FootballerViewModel { get; set; } 
        public ResponseModel ResponseModel { get; set; } 
    }
}

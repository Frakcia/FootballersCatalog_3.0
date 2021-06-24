

namespace FootballersCatalog.Web.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Success = true;
            Message = "Операция выполнена успешно";
        }

        public ResponseModel(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; } 
        public string Message { get; set; }
    }
}

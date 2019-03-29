namespace bookbooking.Common.ViewModels
{
    public class ServiceResult
    {

        public bool Sonuc { get; set; }
        public string Message { get; set; }
        public ServiceResult()
        {
            if (Sonuc == true)
                Message = "Başarılı";
            else
                Message = "Başarısız";
        }
    }
}

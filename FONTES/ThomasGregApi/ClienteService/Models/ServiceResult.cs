namespace ClienteService.Models
{
    public class ServiceResult<T>
    {
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success => ErrorMessage == null;
    }
}

namespace ArticlesAPI.Models
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public bool Succes { get; set; } = true;
        public string ErrorMessage { get; set; } = "No Erros Found";
    }
}
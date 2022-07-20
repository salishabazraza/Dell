namespace WebFront.Core.Helper
{
    public class APISystemReturnModel<T>
    {
            public T data { get; set; }
            public int code { get; set; }
            public string description { get; set; }
        
    }
}

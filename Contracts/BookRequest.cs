namespace dotnet.Contracts
{

    #pragma warning disable CS8618
    public record CreateBookRequest
    { 

        public string Title { get; init; }
        public string Author { get; init; }
        public string Description { get; init; }
        public string Category { get; init; }
        public string Language { get; init; }
        public int TotalPages { get; init; }
    }

    public record UpdateBookRequest
    {
       public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int TotalPages { get; set; }

    }

    public record BookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int TotalPages { get; set; }
    }

    public record ErrorResponse
    {
        public string Title { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }

    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }

        public ApiResponse(T data, string message)
        {
            Data = data;
            Message = message;
        }
    }
    #pragma warning restore CS8618
}
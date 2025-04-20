namespace dotnet.Exceptions
{

    public class NoBookFoundException : Exception
    {

        public NoBookFoundException() : base("No books found")
        {}
    }

    public class BookDoesNotExistException : Exception
    {
        private int id { get; set; }

        public BookDoesNotExistException(int id) : base($"Book with id {id} does not exist")
        {
            this.id = id;
        } 

    }
}
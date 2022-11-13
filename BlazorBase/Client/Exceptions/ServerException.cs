namespace BlazorBase.Client.Exceptions
{
    public class ServerException : Exception
    {
        public ServerException(string msg) : base(msg) { }
    }
}

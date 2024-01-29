namespace MultishopOnion.Application.Exceptions.Base
{
    public abstract class BaseException:Exception
    {
        public BaseException(string mess):base(mess) { }
        public abstract int StatusCode { get; }
    }
}

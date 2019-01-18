namespace BaseExchange.Interfaces
{
    public interface IRequestFactory
    {
        IRequest Create(string uri);
    }
}

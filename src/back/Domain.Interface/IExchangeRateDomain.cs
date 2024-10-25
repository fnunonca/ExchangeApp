using Domain.Entity;

namespace Domain.Interface;

public interface IExchangeRateDomain
{
    Task<List<ExchangeRate>> GetAll();
}

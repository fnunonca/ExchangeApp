namespace Infraestructure.Interface;
using Domain.Entity;
public interface IExchangeRateRepository
{
    Task<List<ExchangeRate>> GetAll();
}

using Domain.Entity;
using Domain.Interface;
using Infraestructure.Interface;

namespace Domain.Core
{
    public class ExchangeRateDomain: IExchangeRateDomain
    {
        private readonly IExchangeRateRepository _repository;
        public ExchangeRateDomain(IExchangeRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExchangeRate>> GetAll()
            => await _repository.GetAll();
    }
}

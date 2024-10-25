using Application.DTO;

namespace Application.Interface;

public interface IExchangeRateApplication
{
    Task<ResponseBaseDto<List<ExchangeRateDto>>> GetAll();

}

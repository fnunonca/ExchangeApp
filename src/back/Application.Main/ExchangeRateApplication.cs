using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Transversal.Common;

namespace Application.Main;

public class ExchangeRateApplication : IExchangeRateApplication
{
    private readonly IExchangeRateDomain _exchangeRateDomain;
    private readonly IAppLogger _logger;

    public ExchangeRateApplication(
        IExchangeRateDomain exchangeRateDomain,
        IAppLogger logger)
    {
        _exchangeRateDomain = exchangeRateDomain;
        _logger = logger;
    }

    public async Task<ResponseBaseDto<List<ExchangeRateDto>>> GetAll()
    {
        try
        {
            var listExchange = await _exchangeRateDomain.GetAll();

            var listDto = listExchange.Select(exchangeRate => new ExchangeRateDto(
                exchangeRate.FromCurrencyCode,
                exchangeRate.ToCurrencyCode,
                exchangeRate.Rate,
                exchangeRate.LastUpdated
            )).ToList();

            var response = new ResponseBaseDto<List<ExchangeRateDto>>(
                StatusCode: 200,
                Message: "Success",
                Response: listDto
            );

            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in GetAll");

            var response = new ResponseBaseDto<List<ExchangeRateDto>>(
                StatusCode: 500,
                Message: "An error occurred",
                Response: null
            );

            return response;
        }
    }
}

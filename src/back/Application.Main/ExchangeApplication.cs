using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Transversal.Common;

namespace Application.Main
{
    public class ExchangeApplication: IExchangeApplication
    {
        private readonly IExchangeRateDomain _exchangeRateDomain;
        private readonly IAppLogger _logger;

        public ExchangeApplication(
            IExchangeRateDomain exchangeRateDomain,
            IAppLogger logger)
        {
            _exchangeRateDomain = exchangeRateDomain;
            _logger = logger;
        }

        public async Task<ResponseBaseDto<ResponseExchangeDto>> Process(RequestExchangeDto request)
        {
            try
            {
                #region Validaciones
                if (request.Monto <= 0)
                {
                    return new ResponseBaseDto<ResponseExchangeDto>(
                        StatusCode: 400,
                        Message: "El monto debe ser mayor que cero",
                        Response: null
                    );
                }

                if (string.IsNullOrWhiteSpace(request.MonedaOrigen) || string.IsNullOrWhiteSpace(request.MonedaDestino))
                {
                    return new ResponseBaseDto<ResponseExchangeDto>(
                        StatusCode: 400,
                        Message: "Los códigos de moneda no pueden estar vacíos",
                        Response: null
                    );
                }
                #endregion

                var listExchange = await _exchangeRateDomain.GetAll();

                var exchangeRate = listExchange.FirstOrDefault(rate =>
                    rate.FromCurrencyCode.Equals(request.MonedaOrigen, StringComparison.OrdinalIgnoreCase) &&
                    rate.ToCurrencyCode.Equals(request.MonedaDestino, StringComparison.OrdinalIgnoreCase));

                if (exchangeRate == null)
                {
                    return new ResponseBaseDto<ResponseExchangeDto>(
                        StatusCode: 404,
                        Message: "Tipo de cambio no encontrado",
                        Response: null
                    );
                }

                double montoConvertido = request.Monto * exchangeRate.Rate;

                var responseExchange = new ResponseExchangeDto(
                    Monto: request.Monto.ToString(),
                    MontoConTipoDeCambio: montoConvertido.ToString(),
                    MonedaOrigen: request.MonedaOrigen,
                    MonedaDestino: request.MonedaDestino,
                    TipoDeCambio: exchangeRate.Rate
                );

                return new ResponseBaseDto<ResponseExchangeDto>(
                    StatusCode: 200,
                    Message: "Success",
                    Response: responseExchange
                );
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in Process");

                return new ResponseBaseDto<ResponseExchangeDto>(
                    StatusCode: 500,
                    Message: "An error occurred",
                    Response: null
                );
            }
        }


    }
}

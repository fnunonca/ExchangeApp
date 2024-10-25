namespace Application.DTO;

public record ExchangeRateDto
(
    string FromCurrencyCode,
    string ToCurrencyCode,
    double Rate,
    string LastUpdated
);
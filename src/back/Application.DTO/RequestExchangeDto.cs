namespace Application.DTO;

public record RequestExchangeDto
(
    double Monto,
    string MonedaOrigen,
    string MonedaDestino
);
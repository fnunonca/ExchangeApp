namespace Application.DTO;

public record ResponseExchangeDto
(
    string Monto,
    string MontoConTipoDeCambio,
    string MonedaOrigen,
    string MonedaDestino,
    double TipoDeCambio
);
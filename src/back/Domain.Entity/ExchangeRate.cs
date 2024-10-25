namespace Domain.Entity;

public class ExchangeRate
{
    public string FromCurrencyCode { get; set; }
    public string ToCurrencyCode { get; set; }
    public double Rate { get; set; }
    public string LastUpdated { get; set; }
}

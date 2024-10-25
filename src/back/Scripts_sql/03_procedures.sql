CREATE PROCEDURE SP_Get_ExchangeRate
AS
BEGIN
	SELECT 
		ER.FromCurrencyCode, 
		ER.ToCurrencyCode, 
		ER.ExchangeRate, 
		ER.LastUpdated
	FROM dbo.ExchangeRate ER WITH (NOLOCK)
END 
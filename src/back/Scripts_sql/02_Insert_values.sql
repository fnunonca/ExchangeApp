INSERT INTO dbo.Currency (Code, Name, Symbol)
VALUES ('PEN', 'Sol Peruano', 'S/')

INSERT INTO dbo.Currency (Code, Name, Symbol)
VALUES ('USD', 'Dolar Estadounidense', '$')

INSERT INTO dbo.Currency (Code, Name, Symbol)
VALUES ('EUR', 'Euro', '€')


INSERT INTO dbo.ExchangeRate (FromCurrencyCode, ToCurrencyCode, ExchangeRate, LastUpdated)
VALUES ('PEN', 'USD', 3.85, GETDATE())

INSERT INTO dbo.ExchangeRate (FromCurrencyCode, ToCurrencyCode, ExchangeRate, LastUpdated)
VALUES ('USD', 'PEN', 3.65, GETDATE())

INSERT INTO dbo.ExchangeRate (FromCurrencyCode, ToCurrencyCode, ExchangeRate, LastUpdated)
VALUES ('PEN', 'EUR', 4.00, GETDATE())

INSERT INTO dbo.ExchangeRate (FromCurrencyCode, ToCurrencyCode, ExchangeRate, LastUpdated)
VALUES ('EUR', 'PEN', 3.95, GETDATE())

INSERT INTO dbo.ExchangeRate (FromCurrencyCode, ToCurrencyCode, ExchangeRate, LastUpdated)
VALUES ('USD', 'EUR', 0.95, GETDATE())

INSERT INTO dbo.ExchangeRate (FromCurrencyCode, ToCurrencyCode, ExchangeRate, LastUpdated)
VALUES ('EUR', 'USD', 1.05, GETDATE())
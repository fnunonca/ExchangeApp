
CREATE TABLE Currency (
    Code VARCHAR(3) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    Symbol VARCHAR(10)
);


CREATE TABLE ExchangeRate (
    FromCurrencyCode VARCHAR(3) NOT NULL,
    ToCurrencyCode VARCHAR(3) NOT NULL,
    ExchangeRate DECIMAL(18, 6) NOT NULL,
    LastUpdated DATETIME NOT NULL DEFAULT GETDATE(),
    PRIMARY KEY (FromCurrencyCode, ToCurrencyCode),
    FOREIGN KEY (FromCurrencyCode) REFERENCES Currency(Code),
    FOREIGN KEY (ToCurrencyCode) REFERENCES Currency(Code)
);
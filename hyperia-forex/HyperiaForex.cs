using Xunit.Sdk;
using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static bool ValidateCurrency(CurrencyAmount x, CurrencyAmount y) => x.currency == y.currency;

    // implement equality operators
    public static bool operator ==(CurrencyAmount x, CurrencyAmount y) =>
        ValidateCurrency(x, y) ? x.amount == y.amount : throw new ArgumentException();

    public static bool operator !=(CurrencyAmount x, CurrencyAmount y) => !(x == y);

    // implement comparison operators
    public static bool operator >(CurrencyAmount x, CurrencyAmount y) =>
        ValidateCurrency(x, y) ? x.amount > y.amount : throw new ArgumentException();

    public static bool operator <(CurrencyAmount x, CurrencyAmount y) => !(x > y);

    // implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount x, CurrencyAmount y) => ValidateCurrency(x, y)
        ? new CurrencyAmount(x.amount + y.amount, x.currency)
        : throw new ArgumentException();

    public static CurrencyAmount operator -(CurrencyAmount x, CurrencyAmount y) => ValidateCurrency(x, y)
        ? new CurrencyAmount(x.amount - y.amount, x.currency)
        : throw new ArgumentException();

    public static CurrencyAmount operator *(CurrencyAmount x, decimal y) => new(x.amount * y, x.currency);

    public static CurrencyAmount operator /(CurrencyAmount x, decimal y)
    {
        if (y == 0) throw new DivideByZeroException();

        return new CurrencyAmount(x.amount / y, x.currency);
    }

    // implement type conversion operators
    public static explicit operator double(CurrencyAmount x) => (double)x.amount;
    public static implicit operator decimal(CurrencyAmount x) => x.amount;
}
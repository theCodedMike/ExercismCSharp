using Xunit.Sdk;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
    
    // implement equality operators
    public static bool operator ==(CurrencyAmount x, CurrencyAmount y)
    {
        if (x.currency != y.currency)
        {
            throw new ArgumentException();
        }

        return x.amount == y.amount;
    }
    public static bool operator !=(CurrencyAmount x, CurrencyAmount y)
    {
        return !(x == y);
    }

    // implement comparison operators
    public static bool operator >(CurrencyAmount x, CurrencyAmount y)
    {
        if (x.currency != y.currency)
        {
            throw new ArgumentException();
        }

        return x.amount > y.amount;
    }
    public static bool operator <(CurrencyAmount x, CurrencyAmount y)
    {
        return !(x > y);
    }

    // implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount x, CurrencyAmount y)
    {
        if (x.currency != y.currency)
        {
            throw new ArgumentException();
        }

        return new CurrencyAmount(x.amount + y.amount, x.currency);
    }
    
    public static CurrencyAmount operator -(CurrencyAmount x, CurrencyAmount y)
    {
        if (x.currency != y.currency)
        {
            throw new ArgumentException();
        }

        return new CurrencyAmount(x.amount - y.amount, x.currency);
    }
    
    public static CurrencyAmount operator *(CurrencyAmount x, decimal y)
    {
        return new CurrencyAmount(x.amount * y, x.currency);
    }
    
    public static CurrencyAmount operator /(CurrencyAmount x, decimal y)
    {
        return new CurrencyAmount(x.amount / y, x.currency);
    }

    // implement type conversion operators
    public static explicit operator double(CurrencyAmount x)
    {
        return (double)x.amount;
    }
    public static implicit operator decimal(CurrencyAmount x)
    {
        return x.amount;
    }
}

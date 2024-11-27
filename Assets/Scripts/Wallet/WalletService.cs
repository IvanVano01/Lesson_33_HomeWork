using System;
using System.Collections.Generic;
using System.Linq;

public class WalletService
{
    private Dictionary<CurrencyTypes, ReactiveVariable<int>> _currencies = new Dictionary<CurrencyTypes, ReactiveVariable<int>>();    

    public List<CurrencyTypes> AvailableCurrencies => _currencies.Keys.ToList();

    public bool HasEnough(CurrencyTypes type, int amount) => _currencies[type].Value >= amount;

    public int AmountCurrency(CurrencyTypes type) => _currencies[type].Value;

    public void Spend(CurrencyTypes type, int amount)
    {
        if (HasEnough(type, amount)==false)
            throw new ArgumentOutOfRangeException(nameof(type));

        _currencies[type].Value -= amount;
    }

    public void Add(CurrencyTypes type, int amount)
    {
        if (amount < 0)
            throw new ArgumentException(type.ToString());

        _currencies[type].Value += amount;
    }   

    public void AddNewCurrency(CurrencyTypes type, ReactiveVariable<int> reactiveVariable)
    {

        if (_currencies.ContainsKey(type))
        {
            throw new ArgumentOutOfRangeException(" Tакая валюта уже есть в кошельке! ", nameof(type));
        }

        _currencies.Add(type, reactiveVariable);
    }
    
}

using System;

public static class MoneyService
{
    private const int MaxChangeValue = 1500;
    private const int MinChangeValue = 0;

    public static event Action<int, string> ChangedBalance;

    public static bool IncreaseBalance(int value, string key)
    {
        RangeInt gold = (RangeInt)SaveGameService.GetByKey(key);
        if(gold == null) gold = new RangeInt(MinChangeValue, MaxChangeValue);
        if (gold.IncreaseValue(value))
        {
            ChangedBalance?.Invoke(gold.Value, key);
            SaveGameService.Save(key, gold);
            return true;
        }
        return false;
    }
    public static bool DecreaseBalance(int value, string key)
    {
        RangeInt gold = (RangeInt)SaveGameService.GetByKey(key);
        if (gold == null) gold = new RangeInt(MinChangeValue, MaxChangeValue);
        if (gold.DecreaseValue(value))
        {
            ChangedBalance?.Invoke(gold.Value, key);
            SaveGameService.Save(key, gold);
            return true;
        }
        return false;
    }

    public static bool CheckValueInBalance(int value, string key)
    {
        RangeInt gold = (RangeInt)SaveGameService.GetByKey(key);
        if (gold == null) gold = new RangeInt(MinChangeValue, MaxChangeValue);
        if (value <= gold.Value) return true;
        return false;
    }    
    public static int GetBalance(string key)
    {
        RangeInt gold = (RangeInt)SaveGameService.GetByKey(key);
        if (gold == null) gold = new RangeInt(MinChangeValue, MaxChangeValue);
        return gold.Value;
    }
}

[Serializable]
public class RangeInt
{
    public int Value{ get; private set; } = 50;
    public int MaxChange {  get; private set; }
    public int MinChange { get; private set; }

    public RangeInt(int minChange, int maxChange)
    {
        if(maxChange > 0  && minChange >= 0)
        {
            MaxChange = maxChange;
            if (minChange < maxChange)
            {
                MinChange = minChange;
            }
            else
            {
                MinChange = 0;
            }
        }
    }

    public bool IncreaseValue(int value)
    {
        if (value < MinChange || value > MaxChange) return false;
        Value += value;
        return true;
    }

    public bool DecreaseValue(int value)
    {
        if (Value < value || value < MinChange || value > MaxChange) return false;
        Value -= value;
        return true;
    }
}

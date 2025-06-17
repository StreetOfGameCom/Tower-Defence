using System;

public static class LevelMoneyService
{
    private const int MaxChangeValue = 1000;
    private const int MinChangeValue = 0;

    public static event Action<int> ChangedBalance;
    private static RangeInt _gold = new RangeInt(MinChangeValue, MaxChangeValue);

    public static bool IncreaseBalance(int value)
    {
        if (_gold.IncreaseValue(value))
        {
            ChangedBalance?.Invoke(_gold.Value);
            return true;
        }
        return false;
    }
    public static bool DecreaseBalance(int value)
    {
        if (_gold.DecreaseValue(value))
        {
            ChangedBalance?.Invoke(_gold.Value);
            return true;
        }
        return false;
    }

    public static bool CheckValueInBalance(int value)
    {
        if (value <= _gold.Value) return true;
        return false;
    }
    public static int GetBalance()
    {
        return _gold.Value;
    }
}

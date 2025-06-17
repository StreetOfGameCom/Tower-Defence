using TMPro;
using UnityEngine;

public class WalletText : MonoBehaviour
{
    [SerializeField] private VizualizeValue _walletText;
    [SerializeField] private string _key;
    [SerializeField] private int _balance;

    private void Start()
    {
        ChangeText(MoneyService.GetBalance(_key), _key);
    }

    private void OnEnable()
    {
        MoneyService.ChangedBalance += ChangeText;
    }

    private void OnDisable()
    {
        MoneyService.ChangedBalance -= ChangeText;
    }

    private void ChangeText(int value, string key)
    {
        if(key != _key) return;
        _balance = value;
        _walletText.Vizualize(_balance);
    }
}

using TMPro;
using UnityEngine;

public class LanguageSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdownLanguages;
    [SerializeField] private LanguageSetter _setLanguage;
    private int languageID = 0;

    private void Start()
    {
        if(PlayerPrefs.HasKey(KeyManager.GetLanguageKey())) languageID = PlayerPrefs.GetInt(KeyManager.GetLanguageKey());
        _dropdownLanguages.value = languageID;
    }

    public void SaveLanguage()
    {
        languageID = _dropdownLanguages.value;
        PlayerPrefs.SetInt(KeyManager.GetLanguageKey(), languageID);
        PlayerPrefs.Save();
        _setLanguage.ChangeLocale(languageID);
    }

}

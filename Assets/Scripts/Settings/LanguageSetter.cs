using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine;

public class LanguageSetter : MonoBehaviour
{
    private bool _changing = false;
    private int _languageID = 0;

    void Awake()
    {
        if (PlayerPrefs.HasKey(KeyManager.GetLanguageKey()))
        {
            _languageID = PlayerPrefs.GetInt(KeyManager.GetLanguageKey());
        }
        ChangeLocale(_languageID);
    }

    public void ChangeLocale(int localeID)
    {
        if (_changing) return;
        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale(int languageID)
    {
        _changing = true;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageID];
        yield return LocalizationSettings.InitializationOperation;
        _changing = false;
    }
}

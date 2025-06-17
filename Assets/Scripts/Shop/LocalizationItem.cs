using UnityEngine.Localization.Settings;

public static class LocalizationItem
{
    private const string _nameKey = "_name";
    private const string _descriptionKey = "_description";

    public static string GetItemName(string key)
    {

        string nameTag = key + _nameKey;
        return GetLocalizationText(nameTag);
    }

    public static string GetItemDescription(string key)
    {

        string nameTag = key + _descriptionKey;
        return GetLocalizationText(nameTag);
    }

    private static string GetLocalizationText(string tag)
    {
        var text = LocalizationSettings.StringDatabase.GetTableEntry(KeyManager.GetLocalizationTableItemName(), tag).Entry;
        if (text != null)
        {
            return text.LocalizedValue;
        }
        else
        {
            return "Empty";
        }

    }

}

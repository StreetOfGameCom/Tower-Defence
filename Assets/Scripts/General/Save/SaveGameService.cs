using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveGameService
{
    public static string SavePath => Application.persistentDataPath + "/GameSaved.gd";

    public static void Save(string key, object value)
    {
        SaveData saveData = GetSave();
        saveData.AddValue(key, value);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(SavePath);
        bf.Serialize(file, saveData);
        file.Close();
    }

    public static object GetByKey(string key)
    {
        if (!File.Exists(SavePath)) return null;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(SavePath, FileMode.Open);
        SaveData saveData = (SaveData)bf.Deserialize(file);
        file.Close();
        return saveData.GetByKey(key);
    }

    private static SaveData GetSave()
    {
        if (!File.Exists(SavePath)) return new SaveData();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(SavePath, FileMode.Open);
        SaveData saveData = (SaveData)bf.Deserialize(file);
        file.Close();
        return saveData;
    }

}

[System.Serializable]
public struct SaveData
{
    private List<SaveInfo> _datas;

    public Dictionary<string, object> GetDictionary()
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        if (_datas == null) return dictionary;
        for(int i = 0; i < _datas.Count; i++)
        {
            dictionary.Add(_datas[i].Key, _datas[i].Value);
        }
        return dictionary;
    }
    public object GetByKey(string key)
    {
        if (_datas == null) return null;
        for (int i = 0; i < _datas.Count; i++)
        {
            if(key == _datas[i].Key) return _datas[i].Value;
        }
        return null;
    }
    public void AddValue(string key, object value)
    {
        if(_datas == null) _datas = new List<SaveInfo>();
        if(GetByKey(key) == null)
        {
            _datas.Add(new SaveInfo(key, value));
        }
        else
        {
            for (int i = 0; i < _datas.Count; i++)
            {
                if (key == _datas[i].Key) _datas[i] = new SaveInfo(key, value);
            }
        }
    }

}
[System.Serializable]
public struct SaveInfo
{
    public string Key;
    public object Value;

    public SaveInfo(string key, object value)
    {
        Key = key;  
        Value = value;
    }
}

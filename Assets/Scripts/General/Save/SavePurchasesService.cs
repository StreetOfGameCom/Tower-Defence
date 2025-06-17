using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavePurchasesService
{
    private const string saveFile = "/SavedPurchases.gd";
    private static List<PurchasesData> savedPurchases = new List<PurchasesData>();

    public static void SaveBuy(string key_name)
    {
        SavePurchase(key_name, true);
    }

    public static bool GetStatusPurchase(string key_name)
    {
        if (File.Exists(Application.persistentDataPath + saveFile))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveFile, FileMode.Open);
            savedPurchases = (List<PurchasesData>)bf.Deserialize(file);
            file.Close();
            foreach (PurchasesData data in savedPurchases)
            {
                if (data._key_name == key_name)
                {
                    return data._isBuy;
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    public static List<PurchasesData> GetAllPurchases()
    {
        if (File.Exists(Application.persistentDataPath + saveFile))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveFile, FileMode.Open);
            savedPurchases = (List<PurchasesData>)bf.Deserialize(file);
            file.Close();
            return savedPurchases;
        }
        else
        {
            return null;
        }
    }

    public static PurchasesData GetPurchaseFromKey(string key)
    {
        if (File.Exists(Application.persistentDataPath + saveFile))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveFile, FileMode.Open);
            savedPurchases = (List<PurchasesData>)bf.Deserialize(file);
            file.Close();
            foreach (PurchasesData purchase in savedPurchases)
            {
                if (purchase._key_name == key)
                {
                    return purchase;
                }
            }
            return null;
        }
        else
        {
            return null;
        }
    }


    private static void SavePurchase(string key_name, bool isBuy)
    {
        PurchasesData purchasesData = new PurchasesData(key_name, isBuy);
        savedPurchases.Add(purchasesData);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + saveFile);
        bf.Serialize(file, savedPurchases);
        file.Close();
    }
}
[Serializable]
public class PurchasesData
{
    public string _key_name;
    public bool _isBuy;

    public PurchasesData(string key_name, bool isBuy)
    {
        _key_name = key_name;
        _isBuy = isBuy;
    }
}
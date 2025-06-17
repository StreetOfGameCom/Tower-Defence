using UnityEngine;

public class SkinsShop : ShopManager
{
    [SerializeField] private TowerData[] _playerDatas;

    private void Start()
    {
        FillingSlots(_playerDatas);
    }

    public override bool Buy(IItemData item)
    {
        if (MoneyService.DecreaseBalance(item.Price, KeyManager.GetGoldKey()))
        {
            Debug.Log(1);
            SavePurchasesService.SaveBuy(item.SystemName);
            return true;
        }
        return false;
    }


    public void Choose(IItemData item)
    {
        SaveGameService.Save(KeyManager.GetSkinNameKey(), item.SystemName);
    }

}

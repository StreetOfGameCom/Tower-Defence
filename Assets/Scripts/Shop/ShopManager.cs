using UnityEngine;

public interface IShopManager
{
    public void FillingSlots(IItemData[] items);
    bool Buy(IItemData items);
}

public abstract class ShopManager : MonoBehaviour, IShopManager
{
    [SerializeField] protected ItemContentShop contentItemShop;
    [SerializeField] protected GameObject _slotPrefab;
    [SerializeField] protected Transform _contentSpawnParent;

    public void FillingSlots(IItemData[] items)
    {
        if (items == null || items.Length == 0) return;
        Debug.Log("!");
        foreach (var item in items)
        {
            var slot = Instantiate(_slotPrefab, _contentSpawnParent);
            slot.GetComponent<ShopSlot>().Init(item, contentItemShop);
        }
    }

    public virtual bool Buy(IItemData item)
    {
        if (MoneyService.DecreaseBalance(item.Price, KeyManager.GetLevelMoneyKey()))
        {
            return true;
        }
        return false;
    }
}

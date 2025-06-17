using UnityEngine;

public class TowerShopManager : ShopManager
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Openspot _nowOpenspot;

    public void EnablingShop(Openspot openspot)
    {
        _shopPanel.SetActive(true);
        _nowOpenspot = openspot;
    }

    public override bool Buy(IItemData item)
    {
        if (base.Buy(item))
        {
            _nowOpenspot.CreateTower((TowerData)item);
            _shopPanel.SetActive(false);
            _nowOpenspot = null;
            return true;
        }
        return false;

    } 
}

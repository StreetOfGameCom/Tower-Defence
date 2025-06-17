using UnityEngine;
using UnityEngine.UI;

public class SkinsContentShop : ItemContentShop
{
    [SerializeField] protected GameObject _pricePanel;
    [SerializeField] protected SkinsShop _skinsShopManager;

    public override void Init(IItemData _item)
    {
        _nullChoosePanel.SetActive(false);
        this._item = _item;
        _descriptionText.text = LocalizationItem.GetItemDescription(_item.SystemName);
        _nameText.text = LocalizationItem.GetItemName(_item.SystemName);
        _priceText.text = _item.Price.ToString();
        _iconImage.sprite = _item.Icon;
        PurchasesData save = SavePurchasesService.GetPurchaseFromKey(_item.SystemName);
        if (save != null)
        {
            if (save._isBuy) ActiveBuyedPanel();
            else ActiveBuyPanel();
        }
        else ActiveBuyPanel();
    }

    private void ActiveBuyedPanel()
    {
        _buyButton.interactable = false;
        _pricePanel.SetActive(false);
        _isBuyIcon.SetActive(true);
        _contentPanel.SetActive(true);
    }

    private void ActiveBuyPanel()
    {
        _buyButton.gameObject.SetActive(true);
        _pricePanel.SetActive(true);
        _isBuyIcon.SetActive(false);
        _buyButton.interactable = MoneyService.CheckValueInBalance(_item.Price, KeyManager.GetGoldKey());
        _contentPanel.SetActive(true);
    }

    public override void BuyButton()
    {
        if (_item != null)
        {
            if(_shopManager.Buy(_item))
                ActiveBuyedPanel();
        }
    }

}

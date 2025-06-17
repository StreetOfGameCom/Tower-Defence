using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContentShop : MonoBehaviour
{
    [SerializeField] protected TMP_Text _nameText;
    [SerializeField] protected TMP_Text _descriptionText;
    [SerializeField] protected TMP_Text _priceText;
    [SerializeField] protected Image _iconImage;
    [SerializeField] protected Button _buyButton;
    [SerializeField] protected GameObject _contentPanel;
    [SerializeField] protected GameObject _nullChoosePanel;
    [SerializeField] protected GameObject _isBuyIcon;
    [SerializeField] protected ShopManager _shopManager;

    protected IItemData _item;

    private void Start()
    {
        _contentPanel.SetActive(false);
        _nullChoosePanel.SetActive(true);
    }


    public virtual void Init(IItemData _item)
    {
        _nullChoosePanel.SetActive(false);
        this._item = _item;
        _isBuyIcon.SetActive(false);
        _descriptionText.text = _item.Description;
        _nameText.text = _item.Name;
        _priceText.text = _item.Price.ToString();
        _iconImage.sprite = _item.Icon;
        _buyButton.interactable = MoneyService.CheckValueInBalance(_item.Price, KeyManager.GetLevelMoneyKey());
        _contentPanel.SetActive(true);
    }

    public virtual void BuyButton()
    {
        if (_item != null)
        {
            _shopManager.Buy(_item);
        }
    }
}

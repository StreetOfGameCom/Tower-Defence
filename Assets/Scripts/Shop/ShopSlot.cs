using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _iconImage;
    [SerializeField, SerializeReference] private IItemData _item;
    [SerializeField] private ItemContentShop _contentPanel;

    public void Init(IItemData item, ItemContentShop content)
    {
        _item = item;
        _contentPanel = content;
        _nameText.text = item.Name;
        _priceText.text = item.Price.ToString();
        _iconImage.sprite = item.Icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _contentPanel.Init(_item);
    }    

}

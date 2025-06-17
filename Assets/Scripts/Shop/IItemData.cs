using UnityEngine;

public interface IItemData
{
    string Name {  get; }
    string Description { get;}
    int Price{ get;}
    Sprite Icon { get;}
    string SystemName { get;}
}

using UnityEngine;

[CreateAssetMenu(menuName = ("GameData/Player/PlayerData"))]
public class PlayerData : ScriptableObject, IObjectViewData
{
    [SerializeField] private Sprite _view;
    [SerializeField] private float _size;
    [SerializeField] private RuntimeAnimatorController _animatorController;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    public Sprite View => _view;
    public float Size => _size;
    public RuntimeAnimatorController AnimatorController => _animatorController;
    public float Health { get => _health; }
    public float Damage { get => _damage; }
}

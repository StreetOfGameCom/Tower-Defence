using UnityEngine;

[CreateAssetMenu(menuName ="GameData/Enemies/EnemyData")]
public class EnemyData : ScriptableObject, IObjectViewData
{
    public Sprite View { get => _view; }
    public float Size { get => _size; }
    public RuntimeAnimatorController AnimatorController { get => _animatorController; }
    public float Health { get => _health; }
    public float Speed { get => _speed; }
    public int Award { get => _award; }

    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private RuntimeAnimatorController _animatorController;
    [SerializeField] private Sprite _view;
    [SerializeField] private float _size;
    [SerializeField] private int _award;
}

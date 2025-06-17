using System.Drawing;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObjectViewManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private AnimatorController _animatorController;

    private void Start()
    {
        if (_spriteRenderer != null) return;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetView(IObjectViewData viewData)
    {
        _spriteRenderer.sprite = viewData.View;
        if (viewData.AnimatorController != null && _animatorController != null)
        {
            _animatorController = (AnimatorController)viewData.AnimatorController;
        }
        if (_collider != null)
        {
            _collider.radius = viewData.Size;
        }
    }
}
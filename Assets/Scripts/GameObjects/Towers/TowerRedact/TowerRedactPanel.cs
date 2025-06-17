using UnityEngine;
using UnityEngine.UI;

public class TowerRedactPanel : MonoBehaviour
{
    [SerializeField] private Button _upgrateBytton;
    [SerializeField] private GameObject _toolsPanel;
    private Openspot _nowOpenspot;

    public void OpenToolsPanel(Openspot nowOpenspot, bool canUpgrate)
    {
        _nowOpenspot = nowOpenspot;
        _upgrateBytton.interactable = canUpgrate;
        transform.position = _nowOpenspot.gameObject.transform.position;
        _toolsPanel.SetActive(true);
    }

    public void UpgrateButton()
    {
        if (_nowOpenspot == null) return;
        _nowOpenspot.UpgrateTower();
        _nowOpenspot = null;
        _toolsPanel.SetActive(false);
    }

    public void DestroyButton()
    {
        if (_nowOpenspot == null) return;
        _nowOpenspot.DestroyTower();
        _nowOpenspot = null;
        _toolsPanel.SetActive(false);
    }

}

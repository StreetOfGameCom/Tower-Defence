using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SectionElementUI : LoadSceneButton
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Slider _progressSlider;
    private ISectionData _sectionData;

    public void Init(ISectionData data, float progress)
    {
        _iconImage.sprite = data.SectionIcon;
        _nameText.text = data.SectionName;
        _progressSlider.value = progress;
        _sectionData = data;
    }

    public void StartLevel()
    {
        LoadScene(_sectionData.SectionSystemName);
    }

}

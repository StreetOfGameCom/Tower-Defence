using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IChapterController
{
    ChapterData ChapterData { get; }
    List<SectionElementUI> Levels { get; }
    void Init(ChapterData chapterData, ChapterSaveInfo chapterSave);
}

public class ChapterController : MonoBehaviour, IChapterController
{
    [SerializeField] SectionElementUI _chapterElement;
    [SerializeField] private GameObject _levelUIPrefab;
    [SerializeField] private RectTransform _levelsParent;
    [SerializeField] private RectTransform _chapterRectTransform;

    [SerializeField] private ChapterData _chapterData;
    [SerializeField] private List<SectionElementUI> _levels;

    public ChapterData ChapterData { get => _chapterData; }
    public List<SectionElementUI> Levels { get => _levels; }
    public void Init(ChapterData chapterData, ChapterSaveInfo chapterSave)
    {
        _chapterData = chapterData;
        _chapterElement.Init(chapterData, 1);
        _levels = new List<SectionElementUI>
        {
            _chapterElement
        };
        StartCoroutine(CreatChapter(chapterSave));
    }

    private IEnumerator CreatChapter(ChapterSaveInfo chapterSave)
    {
        for(int i = 0; i < _chapterData.Levels.Length; i++)
        {
            SectionElementUI section = Instantiate(_levelUIPrefab, _levelsParent).GetComponent<SectionElementUI>();
            for (int j = 0; j < chapterSave.Levels.Count; j++)
            {
                if (chapterSave.Levels[j].SystemName == _chapterData.Levels[i].SectionSystemName)
                {
                    section.Init(_chapterData.Levels[i], chapterSave.Levels[j].IsComplited?1f:0f);
                }
            }
            _levels.Add(section);
        }
        yield return new WaitForSeconds(0.1f);
        _chapterRectTransform.sizeDelta = new Vector2(_levelsParent.rect.size.x, _chapterRectTransform.rect.height);
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ILevelsController
{
    ChapterData[] Chapters { get; }
    void Init();
}

public class LevelsContoller : MonoBehaviour, ILevelsController
{
    [SerializeField] private ChapterData[] _chapters;
    [SerializeField] private GameObject _chapterPrefab;
    [SerializeField] private Transform _chaptersParant;

    public ChapterData[] Chapters { get => _chapters; }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        var save = SaveGameService.GetByKey(KeyManager.GetLevelsKey());
        List<ChapterSaveInfo> chaptersSave;
        if (save != null)
        {
            chaptersSave = (List<ChapterSaveInfo>)save;
        }
        else
        {
            chaptersSave = new List<ChapterSaveInfo>();
            for (int i = 0; i < _chapters.Length; i++)
            {
                chaptersSave.Add(new ChapterSaveInfo(_chapters[i].SectionSystemName, _chapters[i].Levels.ToList()));
            }
        }
        
        for (int i = 0; i < _chapters.Length; i++)
        {
            ChapterController chapter = Instantiate(_chapterPrefab, _chaptersParant).GetComponent<ChapterController>();
            for (int j = 0; j < chaptersSave.Count; j++)
            {
                if (chaptersSave[j].SystemName == _chapters[i].SectionSystemName)
                {
                    if (chaptersSave[j].IsLocked == false) break;
                    chapter.Init(_chapters[i], chaptersSave[j]);
                }
            }
        }
    }
}

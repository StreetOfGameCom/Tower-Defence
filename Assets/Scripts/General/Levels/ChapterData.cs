using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Levels/ChapterData")]
public class ChapterData : ScriptableObject, ISectionData
{
    [SerializeField] private string _chapterName;
    [SerializeField] private Sprite _image;
    [SerializeField] private string _chapterSystemName;
    [SerializeField] private int _chapterAward;
    [SerializeField] private LevelData[] _levels;

    public string SectionName { get => _chapterName; }
    public Sprite SectionIcon { get => _image; }
    public string SectionSystemName { get => _chapterSystemName; }
    public int SectionAward { get => _chapterAward; }
    public LevelData[] Levels { get => _levels; }
}

public struct ChapterSaveInfo
{
    public string SystemName;
    public bool IsLocked;
    public List<LevelSaveInfo> Levels;
    public ChapterSaveInfo(string systemName, List<LevelData> levelsData, bool isLocked = true)
    {
        SystemName = systemName;
        IsLocked = isLocked;
        Levels = new List<LevelSaveInfo>();
        for (int i = 0; i < levelsData.Count; i++)
        {
            Levels.Add(new LevelSaveInfo(levelsData[i].SectionSystemName));
        }
    }
}

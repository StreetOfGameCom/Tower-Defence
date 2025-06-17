using UnityEngine;

public interface ISectionData 
{
    public string SectionName { get; }
    public Sprite SectionIcon { get; }
    public string SectionSystemName { get; }
    public int SectionAward { get; }
}


[CreateAssetMenu(menuName = "GameData/Levels/LevelData")]
public class LevelData : ScriptableObject, ISectionData
{
    [SerializeField] private string _levelName;
    [SerializeField] private Sprite _levelIcon;
    [SerializeField] private string _levelScene;
    [SerializeField] private string _levelSystemName;
    [SerializeField] private int _levelAward;
    [SerializeField] private int _levelStartBalance;
    [SerializeField] private PlayerData _base;
    [SerializeField] private WaveData[] _waves;

    public string SectionName { get => _levelName; }
    public Sprite SectionIcon { get => _levelIcon; }
    public string LevelScene { get => _levelScene; }
    public string SectionSystemName { get => _levelSystemName; }
    public int SectionAward { get => _levelAward; }
    public int LevelStartBalance { get => _levelStartBalance; }
    public PlayerData Base { get => _base; }
    public WaveData[] Waves { get => _waves; }
}

public struct LevelSaveInfo
{
    public string SystemName;
    public bool IsComplited;

    public LevelSaveInfo(string systemName, bool isComplited = true)
    {
        IsComplited = isComplited;
        SystemName = systemName;
    }

    public void Complite(bool isComplited)
    {
        IsComplited = isComplited;
    }
}

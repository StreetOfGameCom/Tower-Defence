using System.Collections.Generic;
using UnityEngine;

public interface ILevelCompliter
{
    public void LevelComplite();
}

public class LevelCompliter : MonoBehaviour, ILevelCompliter
{
    private LevelData _levelData;
    private ChapterData _chapterData;
    private bool isCanComplite = false;
    public LevelCompliter(LevelData levelData, ChapterData chapterData)
    {
        _levelData = levelData;
        _chapterData = chapterData;
        isCanComplite = true;
    }
    public void LevelComplite()
    {
        if (!isCanComplite) return;
        List<ChapterSaveInfo> chaptersSave = (List<ChapterSaveInfo>)SaveGameService.GetByKey(KeyManager.GetLevelsKey());
        foreach(ChapterSaveInfo chapterData in chaptersSave)
        {
            if(chapterData.SystemName == _chapterData.SectionSystemName)
            {
                for(int i = 0; i < chapterData.Levels.Count; i++)
                {
                    if (chapterData.Levels[i].SystemName == _levelData.SectionSystemName)
                    {
                        chapterData.Levels[i].Complite(true);
                        SaveGameService.Save(KeyManager.GetLevelsKey(), chapterData);
                        MoneyService.IncreaseBalance(_levelData.SectionAward, KeyManager.GetGoldKey());
                        return;
                    }
                }
            }
        }
    }
}

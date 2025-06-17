using System.Collections;
using UnityEngine;

public class PauseButton : ButtonSourse
{
    [SerializeField] private LevelUIController _uiController;
    

    public void Pause() => StartCoroutine(StopingGame());

    private IEnumerator StopingGame()
    {
        ClickSource();
        yield return new WaitForSeconds(_audioClip.length);
        _uiController.PauseGame();

    }
}

using System.Collections;
using UnityEngine;

public class PlayButton : ButtonSourse
{
    [SerializeField] private LevelUIController _uiController;

    public void Play() => StartCoroutine(PlaingGame());

    private IEnumerator PlaingGame()
    {
        ClickSource();
        Time.timeScale = 1;
        yield return new WaitForSeconds(_audioClip.length);
        _uiController.PlayGame();

    }
}

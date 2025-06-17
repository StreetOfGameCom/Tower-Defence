using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : ButtonSourse
{
    public void LoadScene(string sceneName)
    {
        ClickSource();
        if (SceneManager.GetSceneByName(sceneName) == null) throw new Exception($"Error! Scene {sceneName} is not found!"); 
        SceneManager.LoadScene(sceneName);
    }
}

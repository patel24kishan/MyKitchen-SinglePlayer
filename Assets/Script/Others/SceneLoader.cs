using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene{
        MainMenuScene,
        LoadingScene,
        GameScene,
    }

    private static Scene nextScene;// targetScene

    public static void Load(Scene nextScene) //
    {
        SceneLoader.nextScene = nextScene;
        SceneManager.LoadScene(SceneLoader.Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(nextScene.ToString());

    }
    
 
}

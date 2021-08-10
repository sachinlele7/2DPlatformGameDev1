
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public string[] Levels;
    //public string Level1;
    public static LevelManager Instance { get { return instance; } }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);
        // int nextSceneIndex = currentScene.buildIndex + 1;
        // Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        // SetLevelStatus(nextScene.name, LevelStatus.Unlocked);

        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int NextSceneIndex = currentSceneIndex + 1;
        if (NextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[NextSceneIndex], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}

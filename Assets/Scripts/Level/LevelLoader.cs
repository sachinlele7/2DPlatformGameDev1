using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
        FindObjectOfType<AudioManager>().Play("Button");
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                break;

            case LevelStatus.Unlocked:
                //SoundManager.Instance.Play(Sounds.ButtonClick);
                FindObjectOfType<AudioManager>().Play("Button");
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                //SoundManager.Instance.Play(Sounds.ButtonClick);
                FindObjectOfType<AudioManager>().Play("Button");
                SceneManager.LoadScene(LevelName);
                break;


        }
        
    }
}

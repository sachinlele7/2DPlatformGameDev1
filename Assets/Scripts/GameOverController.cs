using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button Lobby;
    public ParticleSystem particleSystem;
    

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);

        {
            PlayGameOVerEffect();
        }
 
    }

    private void PlayGameOVerEffect()
    {
        particleSystem.Play();
    }

    public void PlayerDied()
    {
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}

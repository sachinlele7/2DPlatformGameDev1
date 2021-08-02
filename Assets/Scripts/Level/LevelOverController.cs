using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Player")) 
        if (collision.gameObject.GetComponent<PlayerController>() !=null)
        {
            Debug.Log("Level Complete");
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
    
}

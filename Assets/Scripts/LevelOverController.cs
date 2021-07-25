using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Player")) 
        if (collision.gameObject.GetComponent<PlayerController>() !=null)
        {
            Debug.Log("Level Complete");
        }
    }
    void Update()
    {
        
    }
}

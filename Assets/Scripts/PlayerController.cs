using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;

    public int maxhealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxhealth;
    }


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }


    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Reloading Scene 0");
    }
    public void PickupKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        Debug.Log("Player Killed by enemy");
        ReloadLevel();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);

        PlayMovementAnimation(horizontal, vertical);

    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
        if (horizontal > 0)
        {
            animator.SetBool("isrunning", true);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("isrunning", true);
        }
        else
        {
            animator.SetBool("isrunning", false);
        }

        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }
    private void PlayMovementAnimation(float horizontal, float vertical)
    {
       
        if (horizontal > 0) 
        {
            animator.SetBool("isrunning", true);
        }

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (horizontal > 0)
        { scale.x = Mathf.Abs(scale.x); }
        transform.localScale = scale;

        
        animator.SetBool("Jump", vertical > 0);


        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }

        else
        {
            animator.SetBool("Crouch", false);
        }

    }

}












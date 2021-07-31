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
    public int maxHealth = 100;
    public int currentHealth;
    private int damage;
    public HealthBar healthBar;
    public GameOverController gameovercontroller;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void DamagePlayer()
    {
        TakeDamage(20);
        currentHealth = 0;

        {
            Die();
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
       
    }

    void Die()
    {
        animator.SetBool("Death", true);
        //Destroy(gameObject);
        //SceneManager.LoadScene(0);
        gameovercontroller.PlayerDied();
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }


    
    public void PickupKey()
    {
        
        scoreController.IncreaseScore(10);
    }

    public void OnGrounded()
    {
        animator.SetBool("Jump", false);
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












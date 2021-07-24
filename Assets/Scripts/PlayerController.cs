using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;


    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharacter(horizontal);

        PlayMovementAnimation(horizontal);

    }

    private void MoveCharacter(float horizontal)
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
    }

    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("horizontal", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (horizontal > 0)
        { scale.x = Mathf.Abs(scale.x); }
        transform.localScale = scale;

        float vertical = Input.GetAxisRaw("Jump");


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












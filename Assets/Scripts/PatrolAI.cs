using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float walkSpeed;
    [HideInInspector]
    public bool mustPatrol;
    private bool MustTurn;
    public Rigidbody2D rb;
    public Transform GroundDetect;
    public LayerMask groundLayer;
    public LayerMask ground1Layer;
    public Collider2D bodyCollider;

    private void Start()
    {
        mustPatrol = true;
    }

    private void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            MustTurn = !Physics2D.OverlapCircle(GroundDetect.position, 0.1f, groundLayer);
        }
    }
    private void Patrol()
    {
        if(MustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        walkSpeed *= -1;
        mustPatrol = true;
    }


}

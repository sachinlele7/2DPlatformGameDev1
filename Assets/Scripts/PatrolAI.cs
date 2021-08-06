using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    [SerializeField]
    Transform groundDetect;

    [SerializeField]
    float baseCastDist;

    string facingDirection;

    Vector3 baseScale;

    Rigidbody2D rb2d;

    float moveSpeed = 3;


   void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        float vX = moveSpeed;
        
        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }
        else if (facingDirection == RIGHT)
        {
            vX = moveSpeed;
        }
            rb2d.velocity = new Vector2(vX, rb2d.velocity.y);

        if(IsHittingWall() || IsNearEdge())
        {
            if(facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else if (facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }

        }
    }

    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;

        if (newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else
        if (newDirection == LEFT)
        {
            newScale.x = baseScale.x;
        }

            transform.localScale = newScale;

        facingDirection = newDirection;
    }

    bool IsHittingWall()
    {
        bool val = false;

        float castDist = baseCastDist;

        if (facingDirection == LEFT)
        {
            castDist = -baseCastDist;
        }
        else if (facingDirection == RIGHT)
        {
            castDist = baseCastDist;
        }

            Vector3 targetPos = groundDetect.position;
        targetPos.x += castDist;

        if (Physics2D.Linecast(groundDetect.position, targetPos, 1 << LayerMask.NameToLayer("ground")))
        {
            val = true;
        }
        else
        {
            val = false;
        }
        return val;
    }

    bool IsNearEdge()
    {
        bool val = true;

        float castDist = baseCastDist;

        Vector3 targetPos = groundDetect.position;
        targetPos.y -= castDist;

        if (Physics2D.Linecast(groundDetect.position, targetPos, 1 << LayerMask.NameToLayer("ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }



}

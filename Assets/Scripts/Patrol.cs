using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float rayGist;
    private bool MovingRight;
    public Transform groundDetect;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundcheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayGist);

        if(groundcheck.collider == false)
        {
            if (MovingRight)
            {

                transform.eulerAngles = new Vector3(0, -180, 0);
                MovingRight = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovingRight = true;
            }

            
        }
    }
}

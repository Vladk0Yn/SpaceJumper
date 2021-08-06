using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMover : MonoBehaviour
{
    private float speed = 2f;

    private bool move  = true;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > 6)
        {
            move = false;
        }
        else if (transform.position.y < -6)
        {
            move = true;
        }

        if (move)
        {
            speed += 0.3f * Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime); 
        }
    }
}

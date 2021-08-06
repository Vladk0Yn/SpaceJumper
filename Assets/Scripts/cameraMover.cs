using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour
{
    public GameObject player;
    public Transform target;

    public float smooth = 1.2f;

    public Vector3 offset = new Vector3(2, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,target.position + offset, Time.deltaTime);
    }
}

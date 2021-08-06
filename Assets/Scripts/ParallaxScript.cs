using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour {
    private float startPos, length;
    public GameObject camera;
    public float paralaxEffect;

    void Start() {
        Application.targetFrameRate = 300;
        startPos = transform.position.x;
        length   = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        float temp = camera.transform.position.x * (1 - paralaxEffect);
        float dist = camera.transform.position.x * paralaxEffect;
        
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        
        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}

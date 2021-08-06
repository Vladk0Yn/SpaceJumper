using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Destroy());
    }
    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(40.0f);
        Destroy(gameObject);
    }
}
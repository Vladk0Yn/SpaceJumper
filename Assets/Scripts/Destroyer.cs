using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
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
        yield return new WaitForSeconds(25.0f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class platformSpawner : MonoBehaviour
{
    public GameObject platforma;
    public float distance = 17;
    private float pos;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
        pos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }

   void Spawner()
    {
        if (math.abs(transform.position.x - pos) >= distance)
        {
            Instantiate(platforma, new Vector2(transform.position.x + 30, -3), Quaternion.identity);
            platforma.transform.localScale = new Vector3(Random.Range(0.4f, 2.5f), 1, 1);
            pos = transform.position.x;
            if (distance < 25)
                distance += 0.2f;
        }
    }
}

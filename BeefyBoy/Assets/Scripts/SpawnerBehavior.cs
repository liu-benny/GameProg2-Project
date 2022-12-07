using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public GameObject[] myObjects;
    float next_spawn_time;

    void Start()
    {
        next_spawn_time = Time.time + 4.0f;

    }

    
    void Update()
    {
        int randomIndex = Random.Range(0, myObjects.Length);

        if(Time.time > next_spawn_time) {
            Instantiate(myObjects[randomIndex], transform.position, Quaternion.identity);
            next_spawn_time += 4.0f;
        }
    }
}

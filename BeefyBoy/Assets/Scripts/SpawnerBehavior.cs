using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{

    public GameObject[] myObjects;
    public GameObject cubePrefab;
    float next_spawn_time;


    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = Time.time+4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        int randomIndex = Random.Range(0, myObjects.Length);

        // myObjects[randomIndex].transform.localScale = new Vector3(5f, 5f, 5f);
        // Instantiate(myObjects[randomIndex], transform.position, Quaternion.identity);
        if(Time.time > next_spawn_time) {
        Instantiate(myObjects[randomIndex], transform.position, Quaternion.identity);
 
         //increment next_spawn_time
         next_spawn_time += 4.0f;
        }
    }
}

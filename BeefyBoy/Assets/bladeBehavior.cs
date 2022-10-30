using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeBehavior : MonoBehaviour
{
    public GameObject blade1;
    public GameObject blade2;
    public GameObject blade3;
    public GameObject blade4;
    public GameObject blade5;
    public GameObject blade6;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        blade1 = GameObject.Find("blade1");
        blade2 = GameObject.Find("blade2");
        blade3 = GameObject.Find("blade3");
        blade4 = GameObject.Find("blade4");
        blade5 = GameObject.Find("blade5");
        blade6 = GameObject.Find("blade6");
    }

    // Update is called once per frame
    void Update()
    {
        // cube.transform.Rotate(0f, 0f, 1f * Time.deltaTime, Space.Self);
        blade1.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        blade2.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        blade3.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        blade4.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        blade5.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        blade6.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
    }
}

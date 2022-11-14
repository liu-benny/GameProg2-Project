using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyObject : MonoBehaviour
{
    public Transform[] floaters;
    public float underwaterDrag = 3f;
    public float underwaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight = 0f;

    Rigidbody rigidbody;
    int floatersUnderwater;
    bool underwater;

    
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        FixedUpdate();
    }

    void FixedUpdate()
    {
        floatersUnderwater = 0;
        for(int i = 0; i < floaters.Length; i++)
        {
            float diff = floaters[i].position.y - waterHeight;
            if (diff < 0)
            {
                rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(diff), floaters[i].position, ForceMode.Force);
                floatersUnderwater += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwitchState(true);
                }
            }
        }
        if (underwater && floatersUnderwater==0)
        {
            underwater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            rigidbody.drag = underwaterDrag;
            rigidbody.angularDrag = underwaterAngularDrag;
        }
        else
        {
            rigidbody.drag = airDrag;
            rigidbody.angularDrag = airAngularDrag;
        }
    }

}

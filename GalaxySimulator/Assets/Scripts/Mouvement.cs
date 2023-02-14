using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    [SerializeField] Vector3 initialspeed;
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.velocity = initialspeed;
    }

    private void OnTriggerStay(Collider other)
    {
        VectorField field = other.GetComponent<VectorField>();
        if (field)
        {
            rbody.velocity += field.GetVectorFromPos(transform.position);
            Debug.Log(rbody.velocity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

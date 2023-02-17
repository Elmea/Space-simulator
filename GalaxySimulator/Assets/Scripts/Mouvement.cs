using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    [SerializeField] Vector3 initialspeed;
    private Rigidbody rbody;
    private Planet planet;
    static float ForceDevider = 10000;
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.velocity = initialspeed / ForceDevider;
        planet = GetComponent<Planet>();
    }

    private void OnTriggerStay(Collider other)
    {
        VectorField field = other.GetComponent<VectorField>();
        if (field)
        {
            rbody.AddForce(field.GetVectorFromPos(transform.position) / ForceDevider, ForceMode.Acceleration);
            Debug.Log(rbody.velocity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

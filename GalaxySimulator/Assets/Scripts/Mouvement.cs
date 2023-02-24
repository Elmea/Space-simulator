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
    [SerializeField] int timeMultiplier = 0;

    // Start is called before the first frame update
    void Start()
    { 
        
        rbody = GetComponent<Rigidbody>();
        if(rbody != null)
            rbody.velocity = initialspeed / 1000;
        planet = GetComponent<Planet>();
    }

    private void OnTriggerStay(Collider other)
    {
        VectorField field = other.GetComponent<VectorField>();
        if (field)
            rbody.AddForce(field.GetVectorFromPos(transform.position) / ForceDevider, ForceMode.Acceleration);
    }
    
    public void SetParameter(Vector3 parInitialSpeed)
    {
        initialspeed = parInitialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

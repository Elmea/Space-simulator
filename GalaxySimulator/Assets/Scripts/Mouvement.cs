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
    }

    private void OnTriggerStay(Collider other)
    {
        ChampVectoriel field = other.GetComponent<ChampVectoriel>();
        if (field)
        {
            rbody.velocity += field.GetVectorFromPos(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = initialspeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Planet : MonoBehaviour
{
    [SerializeField] bool rotation;

    [SerializeField] public float mass;
    [SerializeField] float inclinaisonAngle;
    [SerializeField] float speedrRot;
    
    private float rot;

    void Start()
    {
        rot = 0;
        if (mass < 0)
            mass = 0;
    }

    void Update()
    {
        if (rotation)
            updateRot();
    }

    void updateRot()
    {
        if (rot >= 360)
            rot = 0;
        rot += speedrRot * Time.deltaTime;
        transform.rotation = Quaternion.Euler(inclinaisonAngle, rot, 0);
        Debug.Log(transform.rotation.y);
    }
}

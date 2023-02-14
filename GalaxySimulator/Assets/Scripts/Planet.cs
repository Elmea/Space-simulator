using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Planet : MonoBehaviour
{
    [SerializeField] private double mass;

    void Start()
    {
           
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x+0.01f, transform.position.y, transform.position.z);
        Debug.Log(transform.position.x);
    }
}

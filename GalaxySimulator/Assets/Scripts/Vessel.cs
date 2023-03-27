using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    [SerializeField] private float thrustValue;
    [SerializeField] private float vesselMass;
    [SerializeField] private float rotationSpeed;

    private Vector3 orientation;
    private bool orientationUpdated;
    private float accelerationPurcentage;
    private float accelerationValue;

    private ParticleSystem particles;
    
    private Mouvement movementComp;

    [SerializeField] KeyCode incrementGaz;
    [SerializeField] KeyCode decrementGaz;

    [SerializeField] KeyCode minusYaw;
    [SerializeField] KeyCode plusYaw;
    [SerializeField] KeyCode minusPitch;
    [SerializeField] KeyCode plusPitch;
    [SerializeField] KeyCode minusRoll;
    [SerializeField] KeyCode plusRoll;
    
    private void Start()
    {
        accelerationValue = thrustValue / vesselMass;
        movementComp = GetComponent<Mouvement>();
        orientation = transform.rotation.eulerAngles;
        particles = GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        if (TimeManipulation.timeMultiplier == 1)
        {
            if (accelerationPurcentage > 0.0f)
            {
                float newAcc = accelerationValue * accelerationPurcentage;

                movementComp.AddAcceleration(transform.forward * newAcc);
                
            }
        }
    }

    void Update()
    {
        if (TimeManipulation.timeMultiplier == 1)
        {
            if (Input.GetKey(incrementGaz))
            {
                accelerationPurcentage += 0.5f * Time.deltaTime;
                if (accelerationPurcentage > 1.0f)
                    accelerationPurcentage = 1.0f;
                
            }
            if (Input.GetKey(decrementGaz))
            {
                accelerationPurcentage -= 0.5f * Time.deltaTime;
                if (accelerationPurcentage <= 0.0f)
                {
                    accelerationPurcentage = 0.0f;
                }
            }
            
            if (Input.GetKey(minusYaw))
            {
                orientation.y -= rotationSpeed;
                orientationUpdated = true;
            }
            if (Input.GetKey(plusYaw))
            {
                orientation.y += rotationSpeed;
                orientationUpdated = true;
            }
            
            if (Input.GetKey(minusPitch))
            {
                orientation.x -= rotationSpeed;
                orientationUpdated = true;
            }
            if (Input.GetKey(plusPitch))
            {
                orientation.x += rotationSpeed;
                orientationUpdated = true;
            }
            
            if (Input.GetKey(minusRoll))
            {
                orientation.z -= rotationSpeed;
                orientationUpdated = true;
            }
            if (Input.GetKey(plusRoll))
            {
                orientation.z += rotationSpeed;
                orientationUpdated = true;
            }
        }
        
        if (orientationUpdated)
        {
            transform.rotation = Quaternion.Euler(orientation);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Mouvement : MonoBehaviour
{
    [SerializeField] Vector3 initialspeed;
    private Vector3 velocity = new Vector3( 0.0f, 0.0f, 0.0f );
    private Vector3 acceleration = new Vector3( 0.0f, 0.0f, 0.0f );
    private Vector3 newAcceleration = new Vector3( 0.0f, 0.0f, 0.0f );
    private static float dt = 36000.0f;
    private List<VectorField> fields;
    private TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        velocity = GetMsSpeedFromKms(initialspeed);
        acceleration = new Vector3(0.0f, 0.0f, 0.0f);
        fields = new List<VectorField>();
        trail = GetComponent<TrailRenderer>();
    } 

    private Vector3 GetMsSpeedFromKms(Vector3 speedKms)
    {
        return speedKms * 1000.0f;
    }
    
    private Vector3 GetKmsSpeedFromMs(Vector3 speedMs)
    {
        return speedMs / 1000.0f;
    }
    
    private void OnTriggerStay(Collider other)
    {
        VectorField field = other.GetComponent<VectorField>();

        if (field)
        {
            fields.Add(field);
        }
    }
    
    public void SetParameter(Vector3 parInitialSpeed)
    {
        initialspeed = parInitialSpeed;
    }

    private void FixedUpdate()
    {
        for (int iteration = 0; iteration < TimeManipulation.timeMultiplier; iteration++)
        {
            Vector3 newPosition = (transform.position * Planet.DistanceScale + velocity * dt + acceleration * (dt * dt * 0.5f));
            transform.position = newPosition / Planet.DistanceScale;

            if (trail != null)
            {
                trail.AddPosition(transform.position);
            }

            for (int i = 0; i < fields.Count; i++)
            {
                newAcceleration += fields[i].GetVectorFromPos(transform.position * Planet.DistanceScale);
            }

            Vector3 newVelocity = velocity + (acceleration + newAcceleration) * (0.5f * dt);
            velocity = newVelocity;

            acceleration = newAcceleration;

            newAcceleration = new Vector3(0, 0, 0);

        }
        fields.Clear();
    }
}

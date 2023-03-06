using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Mouvement : MonoBehaviour
{
    [SerializeField] Vector3 initialspeed;
    private Vector3 velocity = new Vector3( 0.0f, 0.0f, 0.0f );
    private Vector3 acceleration = new Vector3( 0.0f, 0.0f, 0.0f );
    private Vector3 newAcceleration = new Vector3( 0.0f, 0.0f, 0.0f );
    private static float dt = 36000.0f;

    // Start is called before the first frame update
    void Start()
    {
        velocity = GetMsSpeedFromKms(initialspeed);
        acceleration = new Vector3(0.0f, 0.0f, 0.0f);
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
            newAcceleration += field.GetVectorFromPos(transform.position * Planet.DistanceScale);
        }
    }
    
    public void SetParameter(Vector3 parInitialSpeed)
    {
        initialspeed = parInitialSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = (transform.position * Planet.DistanceScale + velocity * dt + acceleration * (dt * dt * 0.5f));
        transform.position = newPosition / Planet.DistanceScale;
    }

    void Update()
    {
        Vector3 newVelocity = velocity + (acceleration + newAcceleration) * (0.5f * dt);
        velocity = newVelocity;
        
        acceleration = newAcceleration;

        newAcceleration = new Vector3(0, 0 , 0);
    }
}

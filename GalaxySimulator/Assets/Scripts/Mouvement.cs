using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Mouvement : MonoBehaviour
{
    [SerializeField] Vector3 initialspeed;
    private Vector3 velocity = new Vector3( 0.0f, 0.0f, 0.0f );
    private Vector3 acceleration = new Vector3( 0.0f, 0.0f, 0.0f );
    private Vector3 newAcceleration = new Vector3( 0.0f, 0.0f, 0.0f );
    private static float dt = 10000.0f;
    bool firstFrame = true;

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
        Vector3 newPosition = (transform.position * Planet.DistanceScale + velocity * dt + acceleration * (dt * dt * 0.5f));
        if (field)
        {
            newAcceleration += field.GetVectorFromPos(newPosition);
        }
    }
    
    public void SetParameter(Vector3 parInitialSpeed)
    {
        initialspeed = parInitialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = (transform.position * Planet.DistanceScale + velocity * dt + acceleration * (dt * dt * 0.5f));
        Vector3 newVelocity = velocity + (acceleration + newAcceleration) * (0.5f * dt);

        transform.position = newPosition / Planet.DistanceScale;
        velocity = newVelocity;
        acceleration = newAcceleration;
        newAcceleration = new Vector3(0, 0 , 0);
    }
}

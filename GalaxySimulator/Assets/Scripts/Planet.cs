using System;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] bool rotation;
    [SerializeField] public float mass;
    [SerializeField] float inclinaisonAngle;
    [SerializeField] float rotSpeed;
    
    public static float DistanceScale = (float)1.0e+9;

    public float ua = 1;
    
    private float rot;
    private TrailRenderer trail;
    private float trailBaseTime;

    void Start()
    {
        rot = 0;
        trail = GetComponent<TrailRenderer>();
        if (trail != null)
        {
            trailBaseTime = trail.time;
            trail.startWidth = transform.lossyScale.x / 4;
            trail.endWidth = 0;
        }
    }

    void Update()
    {       
        if (rotation)
            updateRot();

        if (EventManager.IsTimeChanged() && trail != null)
        {
            if (TimeManipulation.timeMultiplier > 0)
            {
                trail.Clear();
                trail.emitting = true;
                if (TimeManipulation.timeMultiplier > 10)
                    trail.time = 0.5f;
                else
                    trail.time = trailBaseTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Planet other = collision.gameObject.GetComponent<Planet>();
        if (other)
        {
            if (other.mass < mass)  
            {
                mass += other.mass;
                GetComponentInParent<Galaxy>().planets.Remove(other.gameObject);
                GetComponentInParent<EventManager>().explosionEvent.Add(new EventExplosion(collision.GetContact(0).point, other.transform.lossyScale));
                Destroy(other.gameObject);
            }
            else
            {
                other.mass += mass;
                GetComponentInParent<Galaxy>().planets.Remove(gameObject);
                GetComponentInParent<EventManager>().explosionEvent.Add(new EventExplosion(collision.GetContact(0).point, transform.lossyScale));
                Destroy(gameObject);
            }
        }
        else
        {
            Vessel vessel = collision.gameObject.GetComponent<Vessel>();
            if (vessel)
            {
                GetComponentInParent<Galaxy>().planets.Remove(vessel.gameObject);
                GetComponentInParent<EventManager>().explosionEvent.Add(new EventExplosion(collision.GetContact(0).point, vessel.transform.lossyScale));
                Destroy(vessel.gameObject);
            }
        }
    }

    void updateRot()
    {
        if (rot >= 360)
            rot = 0;
        rot += rotSpeed * Time.deltaTime * TimeManipulation.timeMultiplier;
        transform.rotation = Quaternion.Euler(inclinaisonAngle, rot, 0);
    }

    public void SetParameters(Vector3 position , float mass, float inclinaisonAngle, float rotSpeed)
    {
        this.mass = mass;
        this.inclinaisonAngle = inclinaisonAngle;
        this.rotSpeed = rotSpeed;
        this.ua = ua;
        transform.position = position;
    }
}

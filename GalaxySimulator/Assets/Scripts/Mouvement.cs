using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Mouvement : MonoBehaviour
{
    [SerializeField] Vector3 initialspeed;
    [SerializeField] float calcOrbitLineEach = 0.0f;

    public GameObject IsMoonOf;
    public static Vector3 SunPos;

    private static int maxOrbitPoints = 25000;
    
    public Vector3 velocity = new Vector3( 0.0f, 0.0f, 0.0f );
    public Vector3 acceleration = new Vector3( 0.0f, 0.0f, 0.0f );
    private Vector3 newAcceleration = new Vector3( 0.0f, 0.0f, 0.0f );
    private Vector3 newPosition = new Vector3( 0.0f, 0.0f, 0.0f );
    private static float dt = 3600.0f;
    private List<VectorField> fields = new List<VectorField>();
    private TrailRenderer trail;
    private LineRenderer lineRenderer;
    private bool firstFrame = true;
    private float orbitLneCalcTimer = 0.0f;
    private VectorField centerOfOrbitField; // Only used for orbit line calc
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = GetMsSpeedFromKms(initialspeed);
        acceleration = new Vector3(0.0f, 0.0f, 0.0f);
        trail = GetComponent<TrailRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            lineRenderer.startWidth = transform.lossyScale.x / 4;
            lineRenderer.endWidth = 0;
        }

        if (IsMoonOf)
            centerOfOrbitField = IsMoonOf.GetComponent<VectorField>();

    }

    private Vector3 GetMsSpeedFromKms(Vector3 speedKms)
    {
        return speedKms * 1000.0f;
    }
    
    private Vector3 GetKmsSpeedFromMs(Vector3 speedMs)
    {
        return speedMs / 1000.0f;
    }

    public Vector3 GetSpeed()
    {
        return GetKmsSpeedFromMs(velocity);
    }
    
    public Vector3 GetAcceleration()
    {
        return acceleration;
    }

    private void OnTriggerStay(Collider other)
    {
        VectorField field = other.GetComponent<VectorField>();

        if (field && other.gameObject != gameObject)
        {
            if (!fields.Contains(field))
                fields.Add(field);
        }
    }
    
    public void SetParameter(Vector3 parInitialSpeed)
    {
        initialspeed = parInitialSpeed;
    }

    private void FixedUpdate()
    {
        fields.Clear();
    }

    private void Update()
    {
        if (lineRenderer)
        {
            if (lineRenderer.enabled = true && fields.Count > 0)
            {
                if (orbitLneCalcTimer <= 0.0f)
                {
                    ResetOrbitLine();
                    CalcOrbitLine();
                    orbitLneCalcTimer = calcOrbitLineEach;
                }
                else
                {
                    orbitLneCalcTimer -= Time.deltaTime;
                }
            }
        }
    }

    public void AddAcceleration(Vector3 newOne)
    {
        newAcceleration += newOne;
    }
    
    public void UpdatePosition()
    {
        float timeStep = dt * Time.fixedDeltaTime;
        
        newPosition = (transform.position * Planet.DistanceScale + velocity * timeStep +
                       acceleration * (timeStep * timeStep * 0.5f));

        for (int i = 0; i < fields.Count; i++)
        {
            newAcceleration += fields[i].GetVectorFromPos(newPosition);
        }

        Vector3 newVelocity = velocity + (acceleration + newAcceleration) * (0.5f * timeStep);
        velocity = newVelocity;

        acceleration = newAcceleration;

        newAcceleration = new Vector3(0, 0, 0);
        transform.position = newPosition / Planet.DistanceScale;

        if (trail)
        {
            trail.AddPosition(transform.position);
        }
    }

    private void CalcOrbitLine()
    {
        if (!lineRenderer)
            return;
        
        Vector3 nextVelocity = new Vector3(velocity.x, velocity.y, velocity.z);
        Vector3 nextAcceleration = new Vector3(acceleration.x, acceleration.y, acceleration.z);
        Vector3 nextPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        Vector3 nextNewAcceleration = new Vector3( 0.0f, 0.0f, 0.0f );
        Vector3 nextNewPosition = new Vector3( 0.0f, 0.0f, 0.0f );

        List<Vector3> points = new List<Vector3>();
        float timeStep = dt * 5 ;
        int pointAdded = 0;

        if (IsMoonOf)
        {
            nextVelocity -= IsMoonOf.GetComponent<Mouvement>().velocity;
            nextAcceleration = centerOfOrbitField.GetVectorFromPos(nextNewPosition);
        }

        float orbitPeriod;
        Planet planet = GetComponent<Planet>();
        if (planet)
            orbitPeriod = ((Mathf.PI * transform.position.magnitude * nextVelocity.magnitude) / 3600) * planet.ua;
        else
            orbitPeriod = ((Mathf.PI * transform.position.magnitude * nextVelocity.magnitude) / 3600) * 0.25f;
        
        int pointsToDraw = orbitPeriod > maxOrbitPoints ? maxOrbitPoints : (int)orbitPeriod;
        
        for (int iteration = 0; iteration < pointsToDraw; iteration++)
        {
            if ((nextPosition - SunPos).magnitude <= 20.0f)
                break;
            
            nextNewPosition = (nextPosition * Planet.DistanceScale + nextVelocity * timeStep +
                               nextAcceleration * (timeStep * timeStep * 0.5f));

            if (IsMoonOf)
            {
                nextNewAcceleration = centerOfOrbitField.GetVectorFromPos(nextNewPosition);
            }
            else
            {
                for (int i = 0; i < fields.Count; i++)
                {
                    nextNewAcceleration += fields[i].GetVectorFromPos(nextNewPosition);
                }
            }

            Vector3 newVelocity = nextVelocity + (nextAcceleration + nextNewAcceleration) * (0.5f * timeStep);
            nextVelocity = newVelocity;

            nextAcceleration = nextNewAcceleration;

            nextNewAcceleration = new Vector3(0, 0, 0);
            nextPosition = nextNewPosition / Planet.DistanceScale;
            
            points.Add(nextPosition);
            pointAdded++;
        }

        lineRenderer.positionCount = pointAdded;
        lineRenderer.SetPositions(points.ToArray());
    }

    private void ResetOrbitLine()
    {
        lineRenderer.positionCount = 0;
    }
}

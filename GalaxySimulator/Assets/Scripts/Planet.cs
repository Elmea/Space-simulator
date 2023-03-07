using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] bool rotation;
    [SerializeField] public float mass;
    [SerializeField] float inclinaisonAngle;
    [SerializeField] float rotSpeed;
    
    public static float DistanceScale = (float)1.0e+9;
    
    private float rot;
    private TrailRenderer trail;
    private float trailBaseTime;

    void Start()
    {
        rot = 0;
        trail = GetComponent<TrailRenderer>();
        if (trail != null)
            trailBaseTime = trail.time;
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
        transform.position = position;

    }
}

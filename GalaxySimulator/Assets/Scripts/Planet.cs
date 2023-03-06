using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] bool rotation;
    [SerializeField] public float mass;
    [SerializeField] float inclinaisonAngle;
    [SerializeField] float rotSpeed;
    
    public static float DistanceScale = (float)1.0e+9;
    
    private float rot;

    void Start()
    {
        rot = 0;
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
        rot += rotSpeed * Time.deltaTime;
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

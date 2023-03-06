using UnityEngine;

public class VectorField : MonoBehaviour
{
    private Planet planet;
    [SerializeField] private GameObject Vector;
    [SerializeField] float coteCubeVectorField;
    [SerializeField] bool showField;
    [Range(0.0f, 50.0f)]
    public int VectorDensity;

    private static float G = (float)6.6743e-11;
    
    private void Start()
    {
        showField = true;
        planet = GetComponent<Planet>();
        //rayonPlanet = GetComponent<>
        ShowVectorField();
    }

    private void Update()
    {
        
    }

    private Vector3 CalcPosInVectorField(Vector3 position)
    {
        return position - (transform.position * Planet.DistanceScale);
    }
    
    private Vector3 GetVector(Vector3 positionInField)
    {
        float distance = positionInField.magnitude;
        float acceleration = G * (planet.mass) / (distance * distance);

        Vector3 normalizedVec = positionInField.normalized;
        
        return new Vector3( - (normalizedVec.x * acceleration), - (normalizedVec.y  * acceleration), - (normalizedVec.z * acceleration)) ;
    }
    
    public Vector3 GetVectorFromPos(Vector3 position)
    {
        Vector3 posInField = CalcPosInVectorField(position); 
        
        return GetVector(posInField);
    }

    private void ShowVectorField()
    {
        if (showField)
        {
            float tranche = coteCubeVectorField / (VectorDensity);
            Vector3 startCube = new(coteCubeVectorField / 2 + transform.position.x, coteCubeVectorField / 2 + transform.position.y, coteCubeVectorField / 2 + transform.position.z);
            //Debug.Log(startCube);
            
            for (int i = 0; i < VectorDensity + 1; i++)
            {
                for(int j = 0; j < VectorDensity + 1; j++)
                {
                    for(int k = 0; k < VectorDensity + 1; k++)  
                    {
                        GameObject newPrefab = Instantiate(Vector);
                        newPrefab.transform.position = new Vector3(-startCube.x + i*tranche, -startCube.y + j*tranche, -startCube.z + k*tranche);
                        Vector3 dir = GetVectorFromPos(newPrefab.transform.position);
                        newPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -dir);
                        float vectorIntensity = dir.magnitude/10000000;
                        if (vectorIntensity >= 5)
                            vectorIntensity = 0.01f;
                        Debug.Log(vectorIntensity);
                        newPrefab.transform.localScale = new Vector3(vectorIntensity, vectorIntensity, vectorIntensity);
                    }
                }
            }
        }
    }
}
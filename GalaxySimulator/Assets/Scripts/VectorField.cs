using System;
using UnityEngine;

public class VectorField : MonoBehaviour
{
    private Planet planet;
    [SerializeField] private GameObject Vector;
    [SerializeField] float coteCubeVectorField;
    [SerializeField] bool showField;
    [Range(0.0f, 50.0f)]
    public int VectorDensity;

    private static float G = 6.67428f * Mathf.Pow(10, -11);
    
    private static float DistanceScale = Mathf.Pow(10, 6);
    
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
        return position - transform.position;
    }
    
    private Vector3 GetVector(Vector3 positionInField)
    {
        // Field formula : () 
        float distance = positionInField.magnitude;
        float force = G * (planet.mass) / (distance * distance * DistanceScale * DistanceScale);
        
        return new Vector3( - (positionInField.x * force), - (positionInField.y  * force), - (positionInField.z * force));
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
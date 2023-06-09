using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
public class VectorField : MonoBehaviour
{
    private Planet planet;
    [SerializeField] private GameObject Vector;
    [SerializeField] float coteCubeVectorField;
    [SerializeField] public bool showField;
    public bool VectorFieldExist = false;
    [SerializeField] float arrowSize = 1;
    public List<GameObject> vectorField = new List<GameObject>();

    [Range(0.0f, 50.0f)]
    public int VectorDensity;

    private static float G = (float)6.6743e-11;
    
    private void Start()
    {
        planet = GetComponent<Planet>();
        if(showField)
        {
            CreateVectorField();
        }
        ShowVectorField(showField);
        
    }

    private Vector3 CalcPosInVectorField(Vector3 position)
    {

        Vector3 test = (position - (transform.position * Planet.DistanceScale));
        return test;
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

    public void CreateVectorField()
    {
        VectorFieldExist = true;
        float tranche = coteCubeVectorField / (VectorDensity);
        Vector3 startCube = new(coteCubeVectorField / 2 + transform.position.x, coteCubeVectorField / 2 + transform.position.y, coteCubeVectorField / 2 + transform.position.z);

        for (int i = 0; i < VectorDensity + 1; i++)
        {
            for (int j = 0; j < VectorDensity + 1; j++)
            {
                for (int k = 0; k < VectorDensity + 1; k++)
                {
                    GameObject newPrefab = Instantiate(Vector);
                    newPrefab.transform.parent = this.gameObject.transform;

                    newPrefab.transform.localPosition = new Vector3(-startCube.x + i * tranche, -startCube.y + j * tranche, -startCube.z + k * tranche) + transform.position;
                    Vector3 dir = GetVectorFromPos(newPrefab.transform.position * Planet.DistanceScale);
                    
                    
                    newPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -dir);

                    float vectorIntensity = dir.magnitude / (1.0e+14f) * arrowSize;
                    if(newPrefab.transform.localPosition.sqrMagnitude < 10)
                    {
                        newPrefab.transform.localScale = new Vector3(0, 0, 0);
                    }
                    else
                    { 
                        Debug.Log(newPrefab.transform.localPosition.sqrMagnitude);
                        newPrefab.transform.localScale = new Vector3(vectorIntensity / transform.lossyScale.x, vectorIntensity / transform.lossyScale.y, vectorIntensity / transform.lossyScale.z);
                    }
                    vectorField.Add(newPrefab);
                }
            }
        }
    }

    public void ShowVectorField(bool test)
    {
        foreach (GameObject vector in vectorField)
        {
            vector.SetActive(test);
        }
        showField = test;
    }
        
}
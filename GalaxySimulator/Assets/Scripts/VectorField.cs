using System;
using UnityEngine;

public class VectorField : MonoBehaviour
{
    private Planet planet;

    private static float G = 6.67428f * Mathf.Pow(10, -11);
    
    private void Start()
    {
        planet = GetComponent<Planet>();
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
}
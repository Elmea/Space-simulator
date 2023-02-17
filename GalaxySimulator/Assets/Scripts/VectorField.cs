using System;
using UnityEngine;

public class VectorField : MonoBehaviour
{
    private Planet planet;

    private static float G = 6.67428f * Mathf.Pow(10, -11);
    
    private static float DistanceScale = Mathf.Pow(10, 6);
    
    private void Start()
    {
        planet = GetComponent<Planet>();
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
}
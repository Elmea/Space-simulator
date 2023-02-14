using System;
using UnityEngine;

public class VectorField : MonoBehaviour
{
    private Planet planet;

    private Vector3 CalcPosInVectorField(Vector3 position)
    {
        return position - transform.position;
    }
    
    private Vector3 GetVector(Vector3 positionInField)
    {
        // Field formula : ( - x log10(||P||), - y log10(||P||), - z log10(||P||)) 
        float distance = positionInField.magnitude;

        return new Vector3( - positionInField.x * MathF.Log10(distance), - positionInField.y * MathF.Log10(distance), - positionInField.z * MathF.Log10(distance));
    }
    
    public Vector3 GetVectorFromPos(Vector3 position)
    {
        Vector3 posInField = CalcPosInVectorField(position);
        
        return GetVector(posInField);
    }
}
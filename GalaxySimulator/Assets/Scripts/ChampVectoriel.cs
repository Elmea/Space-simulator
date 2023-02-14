using System;
using UnityEngine;

public class ChampVectoriel : MonoBehaviour
{
    private Planet planet;

    private Vector3 CalcPosInVectorField(Vector3 position)
    {
        return position - transform.position;
    }
    
    private Vector3 GetVector(Vector3 position)
    {
        // Field formula : (-x , -y , -z)
        return new Vector3(-MathF.Log10(position.x), -MathF.Log10(position.y), -MathF.Log10(position.z));
        
    }
    
    public Vector3 GetVectorFromPos(Vector3 position)
    {
        Vector3 posInField = CalcPosInVectorField(position);
        
        return GetVector(posInField);
    }
}

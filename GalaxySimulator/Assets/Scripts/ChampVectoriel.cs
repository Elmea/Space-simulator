using System.Collections;
using System.Collections.Generic;
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
        return new Vector3(-position.x, -position.y, -position.z);
    }
    
    public Vector3 GetVectorFromPos(Vector3 position)
    {
        Vector3 posInField = CalcPosInVectorField(position);
        
        return GetVector(posInField);
    }
}

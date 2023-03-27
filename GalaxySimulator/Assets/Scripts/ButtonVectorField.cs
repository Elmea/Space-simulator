using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVectorField : MonoBehaviour
{
    [SerializeField] CameraMvt Camera;
    bool showField;

    public void OnClick()
    { 
        showField = Camera.target.GetComponent<VectorField>().showField;
        if (showField)
        {
            
            Camera.target.GetComponent<VectorField>().ShowVectorField(false);
        }
        else
        {
            if (!Camera.target.GetComponent<VectorField>().VectorFieldExist)
            {
                Camera.target.GetComponent<VectorField>().CreateVectorField();
                Debug.Log("fgfdgfdg");
            }
            Camera.target.GetComponent<VectorField>().ShowVectorField(true);
        }
        Debug.Log(showField);
    }
}

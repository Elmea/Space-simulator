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
            Camera.target.GetComponent<VectorField>().ShowVectorField(true);
        }
        Debug.Log(showField);
    }
}

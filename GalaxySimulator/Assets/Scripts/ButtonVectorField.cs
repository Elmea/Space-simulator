using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVectorField : MonoBehaviour
{
    [SerializeField] CameraMvt Camera;
    bool showField;

    public void OnClick()
    { 
        if (Camera.target.layer == 3)
        {
            return;
        }

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
                }
                Camera.target.GetComponent<VectorField>().ShowVectorField(true);
            }
    }
}

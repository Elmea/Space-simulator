using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetCameraTarget : MonoBehaviour
{
    public GameObject linkedObject;
    Camera cam;

    public void SetTarget()
    {
        //Debug.Log(linkedObject.name);
        cam.GetComponent<CameraMvt>().target = linkedObject;
        cam.GetComponent<CameraMvt>().posZFromTarget = linkedObject.transform.lossyScale * 1.5f;
    }

    public void SetText(string str)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = str;
        cam = FindObjectOfType<Camera>();

    }
}

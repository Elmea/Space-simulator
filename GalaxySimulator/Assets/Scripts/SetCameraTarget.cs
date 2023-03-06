using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetCameraTarget : MonoBehaviour
{
    [HideInInspector] public GameObject linkedObject;
    Camera cam;

    public void SetTarget()
    {
        cam.GetComponent<CameraMvt>().target = linkedObject;
    }

    public void SetText(string str)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = str;
        cam = FindObjectOfType<Camera>();

    }
}

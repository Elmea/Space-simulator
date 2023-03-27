using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpWindow : MonoBehaviour
{
    [SerializeField] private GameObject helpWindow;

    public void OnClick()
    {
        helpWindow.SetActive(!helpWindow.activeSelf);
    }
}

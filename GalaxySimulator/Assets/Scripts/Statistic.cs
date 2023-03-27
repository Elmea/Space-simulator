using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statistic : MonoBehaviour
{
    // Start is called before the first frame update
    private CameraMvt cameraMvt;
    [SerializeField] GameObject camera; 
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI speed;
    [SerializeField] TextMeshProUGUI mass;
    [SerializeField] TextMeshProUGUI acceleration;
    void Start()
    {
        cameraMvt = camera.GetComponent<CameraMvt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

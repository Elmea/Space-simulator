using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statistic : MonoBehaviour
{
    private CameraMvt cameraMvt;
    [SerializeField] GameObject camera; 
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI speed;
    [SerializeField] TextMeshProUGUI mass;
    [SerializeField] TextMeshProUGUI acceleration;
    VectorField vectorField;
    Mouvement mouvement;
    void Start()
    {
        cameraMvt = camera.GetComponent<CameraMvt>();
    }
    
    private void Update()
    {
        if(cameraMvt.target)
        {
            vectorField = cameraMvt.target.GetComponent<VectorField>();
            mouvement = cameraMvt.target.GetComponent<Mouvement>();
            name.SetText(vectorField.planet.name.ToString());
            speed.SetText(mouvement.GetSpeed().magnitude.ToString() + " Km/s");
            acceleration.SetText(mouvement.GetAcceleration().magnitude.ToString());
            mass.SetText(vectorField.planet.mass.ToString());
        }
    }
}   

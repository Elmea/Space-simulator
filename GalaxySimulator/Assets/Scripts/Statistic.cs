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
    Planet planet;
    Mouvement mouvement;
    void Start()
    {
        cameraMvt = camera.GetComponent<CameraMvt>();
    }
    
    private void Update()
    {
        if(cameraMvt.target)
        {
            planet = cameraMvt.target.GetComponent<Planet>();
            mouvement = cameraMvt.target.GetComponent<Mouvement>();

            if (!mouvement || !planet)
                return;

            name.SetText(planet.name.ToString());
            speed.SetText(mouvement.GetSpeed().magnitude.ToString() + " Km/s");
            acceleration.SetText(mouvement.GetAcceleration().magnitude.ToString());
            mass.SetText(planet.mass.ToString() + " Kg");
        }
    }
}   

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statistic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI speed;
    [SerializeField] TextMeshProUGUI mass;

    [SerializeField] CameraMvt cam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.target != null)
        {
            name.text = cam.target.name;
            speed.text = cam.target.GetComponent<Mouvement>().GetSpeed().ToString() + " km/s";
            mass.text = cam.target.GetComponent<Planet>().mass.ToString() + " kg";
        }

    }
}

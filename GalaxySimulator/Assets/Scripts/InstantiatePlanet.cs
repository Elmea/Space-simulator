using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstantiatePlanet : MonoBehaviour
{

    [SerializeField] private GameObject planetPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClick()
    {
        Vector3 pos;
        pos.x = float.Parse(transform.Find("Position").Find("PosX Input").GetComponent<TMP_InputField>().text);
        pos.y = float.Parse(transform.Find("Position").Find("PosY Input").GetComponent<TMP_InputField>().text);
        pos.z = float.Parse(transform.Find("Position").Find("PosZ Input").GetComponent<TMP_InputField>().text);

        Vector3 initialSpeed;
        initialSpeed.x = float.Parse(transform.Find("Initial Speed").Find("SpeedX Input").GetComponent<TMP_InputField>().text);
        initialSpeed.y = float.Parse(transform.Find("Initial Speed").Find("SpeedY Input").GetComponent<TMP_InputField>().text);
        initialSpeed.z = float.Parse(transform.Find("Initial Speed").Find("SpeedZ Input").GetComponent<TMP_InputField>().text);

        float mass = float.Parse(transform.Find("Mass").Find("Mass Input").GetComponent<TMP_InputField>().text);

        float inclinaisonAngle = 0;
        float rotSpeed = 0;
        planetPrefab.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        planetPrefab.GetComponent<Mouvement>().SetParameter(initialSpeed);
        Instantiate(planetPrefab);
    }

}


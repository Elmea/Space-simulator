using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    [SerializeField] private GameObject sunPrefab;
    [SerializeField] private GameObject mercuryPrefab;
    [SerializeField] private GameObject venusPrefab;
    [SerializeField] private GameObject earthPrefab;
    [SerializeField] private GameObject moonPrefab;   
    [SerializeField] private GameObject marsPrefab;
    [SerializeField] private GameObject junoPrefab;

    [SerializeField] private GameObject objectSelectorButton;
    [SerializeField] private GameObject galaxy;
    [SerializeField] private GameObject container;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject ExplosionPrefab;

    public List<GameObject> planets = new List<GameObject>();

    private List<GameObject> explosions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 initialSpeed = new Vector3(0, 0, 0);
        float mass = 1.98847f * Mathf.Pow(10, 30);
        float inclinaisonAngle = 0;
        float rotSpeed = 0;

        //Sun
        GameObject sun = Instantiate(sunPrefab);
        sun.name = "Sun";
        sun.transform.SetParent(galaxy.transform);
        sun.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        sun.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(sun);
        
        GameObject newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = sun;
        newButton.GetComponent<SetCameraTarget>().SetText(sun.name);

        //Mercury
        pos = new Vector3(0, 0, 69.8f);
        initialSpeed = new Vector3(38.86f, 0, 0);
        mass = 3.285f * Mathf.Pow(10, 23);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject mercury = Instantiate(mercuryPrefab);
        mercury.name = "Mercury";
        mercury.transform.SetParent(galaxy.transform);
        mercury.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        mercury.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(mercury);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = mercury;
        newButton.GetComponent<SetCameraTarget>().SetText(mercury.name);

        //Venus
        pos = new Vector3(0, 0, 108.943f);
        initialSpeed = new Vector3(34.7895f, 0, 0);
        mass = 4.8675f * Mathf.Pow(10, 24);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject venus = Instantiate(venusPrefab);
        venus.name = "Venus";
        venus.transform.SetParent(galaxy.transform);
        venus.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        venus.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(venus);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = venus;
        newButton.GetComponent<SetCameraTarget>().SetText(venus.name);

        //Moon
        
        pos = new Vector3(0, 0.0843870671f, 152.479859f);
        initialSpeed = new Vector3(30.261f, 0, 0);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject moon = Instantiate(moonPrefab);
        moon.name = "Moon";
        moon.transform.SetParent(galaxy.transform);
        moon.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        moon.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(moon);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = moon;
        newButton.GetComponent<SetCameraTarget>().SetText(moon.name);
        
        //Earth
        pos = new Vector3(0, 0, 152.097f);
        initialSpeed = new Vector3(29.291f, 0, 0);
        mass = 5.9736f * Mathf.Pow(10, 24);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject earth = Instantiate(earthPrefab);
        earth.name = "Earth";
        earth.transform.SetParent(galaxy.transform);
        earth.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        earth.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(earth);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = earth;
        newButton.GetComponent<SetCameraTarget>().SetText(earth.name);

        //Mars
        pos = new Vector3(0, 0, 249.23f);
        initialSpeed = new Vector3(21.975f, 0, 0);
        mass = 6.4185f * Mathf.Pow(10, 23);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject mars = Instantiate(marsPrefab);
        mars.name = "Mars";
        mars.transform.SetParent(galaxy.transform);
        mars.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        mars.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(mars);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = mars;
        newButton.GetComponent<SetCameraTarget>().SetText(mars.name);

        //Juno
        pos = new Vector3(0, 0, 816f);
        initialSpeed = new Vector3(12.448f, 0, 0);
        mass = 6.4185f * Mathf.Pow(10, 23);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject juno = Instantiate(junoPrefab);
        juno.name = "Juno";
        juno.transform.SetParent(galaxy.transform);
        juno.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        juno.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(juno);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = juno;
        newButton.GetComponent<SetCameraTarget>().SetText(juno.name);

    }

    private void FixedUpdate()
    {
        for (int iteration = 0; iteration < TimeManipulation.timeMultiplier; iteration++)
        {
            foreach (GameObject planet in planets)
            {
                planet.GetComponent<Mouvement>().UpdatePosition();
            }
        }

        Mouvement.SunPos = planets[0].transform.position;
    }

    private void Update()
    {
        foreach (GameObject planet in planets)
        {
            LineRenderer line = planet.GetComponent<LineRenderer>();
            if (line)
            {
                line.startWidth = (planet.transform.position - camera.transform.position).magnitude / 1000.0f;
                line.endWidth = line.startWidth;
            }
        }

        foreach (EventExplosion explosion in GetComponent<EventManager>().explosionEvent)
        {
            GameObject newOne = Instantiate(ExplosionPrefab);
            newOne.transform.position = explosion.position;
            newOne.transform.localScale = explosion.scale;
        }   
    }
}

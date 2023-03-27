using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    [SerializeField] KeyCode InstanciateVessel;
    [SerializeField] private GameObject vesselPrefab;

    [SerializeField] private GameObject sunPrefab;
    [SerializeField] private GameObject mercuryPrefab;
    [SerializeField] private GameObject venusPrefab;
    [SerializeField] private GameObject earthPrefab;
    [SerializeField] private GameObject moonPrefab;   
    [SerializeField] private GameObject marsPrefab;
    [SerializeField] private GameObject junoPrefab;
    [SerializeField] private GameObject saturnPrefab;
    [SerializeField] private GameObject uranusPrefab;
    [SerializeField] private GameObject neptunePrefab;



    [SerializeField] private GameObject objectSelectorButton;
    [SerializeField] private GameObject galaxy;
    [SerializeField] private GameObject container;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject ExplosionPrefab;

    public List<GameObject> planets = new List<GameObject>();

    private EventManager eventManager;

    private GameObject earthObj;
    
    // Start is called before the first frame update
    void Start()
    {
        eventManager = GetComponent<EventManager>();
        
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
        earthObj = earth;
        planets.Add(earth);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = earth;
        newButton.GetComponent<SetCameraTarget>().SetText(earth.name);
        
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
        moon.GetComponent<Mouvement>().IsMoonOf = earth;
        planets.Add(moon);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = moon;
        newButton.GetComponent<SetCameraTarget>().SetText(moon.name);
        
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

        //Saturn
        pos = new Vector3(0, 0, 1503f);
        initialSpeed = new Vector3(9.141f, 0, 0);
        mass = 5.6846f * Mathf.Pow(10, 26);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject saturn = Instantiate(saturnPrefab);
        saturn.name = "Saturn";
        saturn.transform.SetParent(galaxy.transform);
        saturn.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        saturn.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(saturn);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = saturn;
        newButton.GetComponent<SetCameraTarget>().SetText(saturn.name);

        //Uranus
        pos = new Vector3(0, 0, 3006f);
        initialSpeed = new Vector3(6.4864f, 0, 0);
        mass = 8.681f * Mathf.Pow(10, 25);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject uranus = Instantiate(uranusPrefab);
        uranus.name = "Uranus";
        uranus.transform.SetParent(galaxy.transform);
        uranus.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        uranus.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(uranus);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = uranus;
        newButton.GetComponent<SetCameraTarget>().SetText(uranus.name);

        //Neptune
        pos = new Vector3(0, 0, 4537f);
        initialSpeed = new Vector3(5.3861f, 0, 0);
        mass = 1.0243f * Mathf.Pow(10, 26);
        inclinaisonAngle = 0;
        rotSpeed = 0;

        GameObject neptune = Instantiate(neptunePrefab);
        neptune.name = "Neptune";
        neptune.transform.SetParent(galaxy.transform);
        neptune.GetComponent<Planet>().SetParameters(pos, mass, inclinaisonAngle, rotSpeed);
        neptune.GetComponent<Mouvement>().SetParameter(initialSpeed);
        planets.Add(neptune);

        newButton = Instantiate(objectSelectorButton);
        newButton.transform.SetParent(container.transform);
        newButton.GetComponent<SetCameraTarget>().linkedObject = neptune;
        newButton.GetComponent<SetCameraTarget>().SetText(neptune.name);


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
        if (Input.GetKeyDown(InstanciateVessel))
        {
            Vector3 initialSpeed = new Vector3(31.0f, 0, 0);

            GameObject newVessel = Instantiate(vesselPrefab);
            newVessel.transform.position = new Vector3(earthObj.transform.position.x, earthObj.transform.position.y, earthObj.transform.position.z + 0.15f);
            newVessel.name = "Vessel";
            newVessel.transform.SetParent(galaxy.transform);
            newVessel.GetComponent<Mouvement>().IsMoonOf = earthObj;
            newVessel.GetComponent<Mouvement>().SetParameter(initialSpeed);
            planets.Add(newVessel);

            GameObject newButton = Instantiate(objectSelectorButton);
            newButton.transform.SetParent(container.transform);
            newButton.GetComponent<SetCameraTarget>().linkedObject = newVessel;
            newButton.GetComponent<SetCameraTarget>().SetText(newVessel.name);
            
            eventManager.newVesselEvents.Add(new NewVesselEvent(newVessel));
        }
        
        foreach (GameObject planet in planets)
        {
            LineRenderer line = planet.GetComponent<LineRenderer>();
            if (line)
            {
                line.startWidth = (planet.transform.position - camera.transform.position).magnitude / 1000.0f;
                line.endWidth = line.startWidth;
            }
        }

        foreach (EventExplosion explosion in eventManager.explosionEvent)
        {
            GameObject newOne = Instantiate(ExplosionPrefab);
            newOne.transform.position = explosion.position;
            newOne.transform.localScale = explosion.scale;
        }   
    }
}

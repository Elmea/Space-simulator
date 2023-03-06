using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVectorField : MonoBehaviour
{
    [SerializeField] private GameObject Vector;
    [SerializeField] float coteCubeVectorField;
    [SerializeField] bool showField;
    [Range(0.0f, 50.0f)]
    public int VectorDensity;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(coteCubeVectorField, coteCubeVectorField, coteCubeVectorField);
    }

    // Update is called once per frame
    void Update()
    {
        ShowVectorField();
    }

    private void OnTriggerStay(Collider other)
    {
        //Vector3 test = other.GetComponent<VectorField>().transform.position;
        Debug.Log(other.GetComponent<Planet>().name);
    }

    private void ShowVectorField()
    {
        if (showField)
        {
            float tranche = coteCubeVectorField / (VectorDensity);
            Vector3 startCube = new(coteCubeVectorField / 2 + transform.position.x, coteCubeVectorField / 2 + transform.position.y, coteCubeVectorField / 2 + transform.position.z);
            //Debug.Log(startCube);

            for (int i = 0; i < VectorDensity + 1; i++)
            {
                for (int j = 0; j < VectorDensity + 1; j++)
                {
                    for (int k = 0; k < VectorDensity + 1; k++)
                    {
                        GameObject newPrefab = Instantiate(Vector);
                        newPrefab.transform.position = new Vector3(-startCube.x + i * tranche, -startCube.y + j * tranche, -startCube.z + k * tranche);
                        Vector3 dir = Vector3.zero/*GetVectorFromPos(newPrefab.transform.position)*/;
                        newPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, -dir);
                        float vectorIntensity = dir.magnitude / 10000000;
                        if (vectorIntensity >= 5)
                            vectorIntensity = 0.01f;
                        Debug.Log(vectorIntensity);
                        newPrefab.transform.localScale = new Vector3(vectorIntensity, vectorIntensity, vectorIntensity);
                    }
                }
            }
        }
    }
}

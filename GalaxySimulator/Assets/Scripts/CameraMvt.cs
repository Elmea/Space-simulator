using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMvt : MonoBehaviour
{
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode forward;
    [SerializeField] KeyCode back;

    [SerializeField] float speed;

    private void Update()
    {
        Vector3 newPos = transform.position;
        if(Input.GetKey(left))
            newPos.x -= speed;
        if (Input.GetKey(right))
            newPos.x += speed;

        if (Input.GetKey(down))
            newPos.y -= speed;
        if (Input.GetKey(up))
            newPos.y += speed;

        if (Input.GetKey(back))
            newPos.z -= speed;
        if (Input.GetKey(forward))
            newPos.z += speed;

        transform.position = newPos;
    }

}

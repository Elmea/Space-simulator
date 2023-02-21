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

    [SerializeField] KeyCode hideCursor;

    [SerializeField] float speed=50;
    [SerializeField] float mouseSensitivity = 2f;

    bool cursor = true;

    GameObject target;
    float distanceToTarget = 50;
    

    private void Update()
    {
        Vector3 newPos = transform.position;
        if(Input.GetKey(left))
            newPos -= transform.right * speed;
        if (Input.GetKey(right))
            newPos += transform.right * speed;

        if (Input.GetKey(down))
            newPos -= transform.up * speed;
        if (Input.GetKey(up))
            newPos += transform.up * speed;

        if (Input.GetKey(back))
            newPos -= transform.forward * speed;
        if (Input.GetKey(forward))
            newPos += transform.forward * speed;

        transform.position = newPos;

        if (Input.GetKey(hideCursor))
            cursor = false;
        else
            cursor = true;
        if (target != null)
            FollowTarget();

        if (!cursor)
            CameraRotation();
        else
            Cursor.visible = true;
    }

    private void FollowTarget()
    {

    }

    private void CameraRotation()
    {
        Cursor.visible = false;

        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);

    }
}

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

    [SerializeField] float speed = 50;
    [SerializeField] float mouseSensitivity = 2f;

    bool cursor = true;

    [HideInInspector] public GameObject target;
    Vector3 posFromTarget;    
    Vector3 posXFromTarget = new Vector3(0,0,0);
    Vector3 posYFromTarget = new Vector3(0,0,0);
    Vector3 posZFromTarget = new Vector3(0,0,10);

    private void FixedUpdate()
    {
        if(!cursor)
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

            CameraRotation();
        }
        else
        {
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(hideCursor))
            cursor = !cursor;

        if (target != null)
            FollowTarget();

    }

    private void FollowTarget()
    {
        transform.LookAt(target.transform);

        //Debug.Log(transform.forward);

        posFromTarget = posXFromTarget + posYFromTarget +posZFromTarget;

        if (Input.GetKey(left))
            posXFromTarget -= transform.right * speed;
        if (Input.GetKey(right))
            posXFromTarget += transform.right * speed;
    
        if (Input.GetKey(down))
            posYFromTarget -= transform.up * speed;
        if (Input.GetKey(up))
            posYFromTarget += transform.up * speed;

        if (Input.GetKey(back))
            posZFromTarget -= transform.forward * speed;
        if (Input.GetKey(forward))
            posZFromTarget += transform.forward * speed;

        transform.position = posFromTarget + target.transform.position;
    }

    private void CameraRotation()
    {
        Cursor.visible = false;

        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);

    }
}

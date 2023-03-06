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
    float posXFromTarget=0;
    float posYFromTarget=0;
    float posZFromTarget=10;

    private void Update()
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

        posFromTarget = new Vector3(posXFromTarget,posYFromTarget,posZFromTarget);

        if (Input.GetKey(left))
            posXFromTarget -= transform.right.x * speed;
        if (Input.GetKey(right))
            posXFromTarget += transform.right.x * speed;
    
        if (Input.GetKey(down))
            posYFromTarget -= transform.up.y * speed;
        if (Input.GetKey(up))
            posYFromTarget += transform.up.y * speed;

        if (Input.GetKey(back))
            posZFromTarget -= transform.forward.z * speed;
        if (Input.GetKey(forward))
            posZFromTarget += transform.forward.z * speed;

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

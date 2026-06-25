using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        moveCam = false;
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        moveCam = true;
    }

    private void Awake()
    {
        Instance = this;
    }

    public float sensX;
    public float sensY;
    public Transform orientation;
    private bool moveCam = true;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (moveCam == true)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;

            // Stops guy from looking up or down more than 90 degrees
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            //This part does the actual rotating
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    } 
}

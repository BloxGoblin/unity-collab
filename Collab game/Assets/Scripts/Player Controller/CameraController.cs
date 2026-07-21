using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public GameObject crosshair1;
    public GameObject crosshair2;
    public GameObject crosshair3;


    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        moveCam = false;

        crosshair1.SetActive(false);
        crosshair2.SetActive(false);
        crosshair3.SetActive(false);
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        moveCam = true;

        crosshair1.SetActive(true);
    }

    private void Awake()
    {
        Instance = this;
    }

    public float sensX;
    public float sensY;
    public Transform orientation;
    public Transform plrObj;
    private bool moveCam;

    float xRotation;
    float yRotation;

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
            plrObj.rotation = Quaternion.Euler(0,yRotation,0);
        }
    } 
}

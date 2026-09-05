using UnityEngine;

public class PickUpSetup : MonoBehaviour
{
    public static PickUpSetup Instance;

    public GameObject crosshair1, crosshair2, crosshair3; //1-Normal 2-Pick up 3-Drag
    public Transform _objectParent; // "Drops" empty gameobject
    public Transform _cameraTransform;

    private void Awake()
    {
        Instance = this;
    }

    public void SetupObject(GameObject Object)
    {
        if (Object.GetComponent<PickUp>())
        {
            Object.GetComponent<PickUp>().crosshair1 = crosshair1;
            Object.GetComponent<PickUp>().crosshair2 = crosshair2;
            Object.GetComponent<PickUp>().crosshair3 = crosshair3;
            Object.GetComponent<PickUp>()._objectParent = _objectParent;
            Object.GetComponent<PickUp>().cameraTrans = _cameraTransform;
        }
    }
}

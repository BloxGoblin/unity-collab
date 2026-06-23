using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject crosshair1, crosshair2, crosshair3; //1-Normal 2-Pick up 3-Drag
    public Transform _objectParent;
    public Transform objTransform, cameraTrans; 
    public bool interactable, pickedup;
    public Rigidbody objRigidbody;

    public KeyCode _actionKey = KeyCode.E;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!crosshair2.activeSelf)
            {
                crosshair1.SetActive(false);
                crosshair3.SetActive(true);
                interactable = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(pickedup == false)
            {
                crosshair1.SetActive(true);
                crosshair3.SetActive(false);
                interactable = false;
            }
            if (pickedup == true)
            {
                objTransform.parent = _objectParent;
                //objRigidbody.useGravity = true;
                crosshair1.SetActive(true);
                crosshair3.SetActive(false);
                interactable = false;
                pickedup = false;
            }
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(_actionKey))
            {
                objTransform.parent = cameraTrans;
                //objRigidbody.useGravity = true;
                pickedup = true;
            }

            //When you stop holding down the button the thing gets dropped
            
            if(pickedup == true)
            {
                if (Input.GetKeyUp(_actionKey))
                {
                    // Guy drops thingy hes holding
                    objTransform.parent = _objectParent;
                    //objRigidbody.useGravity = true;
                    pickedup = false;
                }
            }
        }
    }
}

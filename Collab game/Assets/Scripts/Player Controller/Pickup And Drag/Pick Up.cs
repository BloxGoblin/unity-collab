using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject crosshair1, crosshair2, crosshair3; //1-Normal 2-Pick up 3-Drag
    public Transform _objectParent;
    public Transform objTransform, cameraTrans;
    public bool interactable, pickedup;
    public Rigidbody objRigidbody;
    public float throwAmount;

    [Header("Keybinds")]
    public KeyCode _actionKey = KeyCode.E;
    public KeyCode _storeKey = KeyCode.Mouse0; //Left click

    [Header("If Object can be stored")]
    public Item Item; // If the item can be stored

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!crosshair3.activeSelf)
            {
                crosshair1.SetActive(false);
                crosshair2.SetActive(true);
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
                crosshair2.SetActive(false);
                interactable = false;
            }
            if (pickedup == true)
            {
                objTransform.parent = _objectParent;
                objRigidbody.useGravity = true;
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
                pickedup = false;
            }
        }
    }

    void Store()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    void Update()
    {
        if (interactable == true)
        {
            //if (Input.GetKeyDown(_actionKey)) Exactly first frame guy presses key (Evil)
            if (Input.GetKey(_actionKey)) // Any frame as long as key is down (Good)
            {
                if (pickedup == false)
                {
                    objTransform.parent = cameraTrans;
                    objRigidbody.useGravity = false;
                    objRigidbody.linearVelocity = Vector3.zero;
                    pickedup = true;
                }
            }

            //When you stop holding down the button the thing gets thrown
            
            if(pickedup == true)
            {
                if (Input.GetKeyUp(_actionKey))
                {
                    // Guy throws thingy hes holding
                    objTransform.parent = _objectParent;
                    objRigidbody.useGravity = true;
                    objRigidbody.linearVelocity = cameraTrans.forward * throwAmount * Time.deltaTime;
                    pickedup = false;
                }
                else if (Input.GetKeyDown(_storeKey) && Item)
                {
                    int inInv = InventoryManager.Instance.Items.Count; //Hiw much in inventory

                    if(inInv < 35) // 35 is max inventory space but we can probably change in the future
                    {
                        if (!crosshair3.activeSelf)
                        {
                            crosshair1.SetActive(true);
                            crosshair2.SetActive(false);
                            interactable = false;
                        }
                        pickedup = false;
                        Store();
                    }
                    else
                    {
                        print("Clear up your inventory blud");
                    }
                }
                else
                {
                    objRigidbody.linearVelocity = Vector3.zero;
                }
            }
        }
    }
}

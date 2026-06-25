using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class InvButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Transform plrObject;
    public Transform dropsParent;

    private bool inButton = false;

    [Header("Keybinds")]
    public KeyCode dropKey = KeyCode.Mouse1; //Right click is default drop button

    [Header("Pick Up Settings")]
    public GameObject crosshair1; //1-Normal 2-Pick up 3-Drag
    public GameObject crosshair2;
    public GameObject crosshair3;
    public Transform _objectParent;
    public Transform _cameraTrans;

    public void OnPointerEnter(PointerEventData eventData)
    {
        inButton = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inButton = false;
    }

    void Update()
    {
        if (inButton == true)
        {
            //drop
            if (Input.GetKeyDown(dropKey))
            {
                GameObject obj = item.Object;

                Vector3 pos = plrObject.position + (plrObject.forward*2.5f);

                GameObject newObj = Instantiate(obj, pos, plrObject.rotation, dropsParent);

                if (newObj.GetComponent<PickUp>())
                {
                    newObj.GetComponent<PickUp>().crosshair1 = crosshair1;
                    newObj.GetComponent<PickUp>().crosshair2 = crosshair2;
                    newObj.GetComponent<PickUp>().crosshair3 = crosshair3;
                    newObj.GetComponent<PickUp>()._objectParent = _objectParent;
                    newObj.GetComponent<PickUp>().cameraTrans = _cameraTrans;
                }

                Destroy(gameObject);
                InventoryManager.Instance.Remove(item);
            }
        }
    }
}

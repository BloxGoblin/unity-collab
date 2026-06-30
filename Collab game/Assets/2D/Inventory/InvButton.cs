using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using TMPro;
using JetBrains.Annotations;
using System;

public class InvButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Transform plrObject;
    public GameObject infoUI;
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
        infoUI.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inButton = false;
        infoUI.SetActive(false);
    }

    void Update()
    {
        if (inButton == true)
        {
            if (infoUI.activeSelf == true)
            {
                Vector2 uiPos = new Vector2(Input.mousePosition.x + 10, Input.mousePosition.y - 10);
                infoUI.transform.position = uiPos;
                infoUI.transform.Find("Item Name").GetComponent<TMP_Text>().text = item.itemName;

                if (item.itemDesc.Length > 0)
                {
                    infoUI.transform.Find("Item Description").GetComponent<TMP_Text>().text = item.itemDesc;

                    float textHeight = infoUI.transform.Find("Item Description").GetComponent<TMP_Text>().renderedHeight;

                    RectTransform rect = infoUI.GetComponent<RectTransform>();

                    float uiSize = (textHeight*1.4f) + 10;

                    rect.sizeDelta = new Vector2(rect.sizeDelta.x, uiSize);
                }
                else
                {
                    infoUI.transform.Find("Item Description").GetComponent<TMP_Text>().text = "Empty Description";
                }
            }

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

                infoUI.SetActive(false);
                Destroy(gameObject);
                InventoryManager.Instance.Remove(item);
            }
        }
    }
}

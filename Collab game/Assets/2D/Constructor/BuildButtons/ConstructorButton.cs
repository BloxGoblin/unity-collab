using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using TMPro;
using JetBrains.Annotations;
using System;

public class ConstructorButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Constructible constructible;
    public Transform plrObject;
    public GameObject infoUI; //Same hover ui as inventory buttons

    private bool inButton = false;

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
                infoUI.transform.Find("Object Name").GetComponent<TMP_Text>().text = constructible.objectName;

                if (constructible.objectDesc.Length > 0)
                {
                    infoUI.transform.Find("Object Description").GetComponent<TMP_Text>().text = constructible.objectDesc;
                }
                else
                {
                    infoUI.transform.Find("Object Description").GetComponent<TMP_Text>().text = "Empty Description";
                }
            }

            if (Input.GetKeyDown(Keybinds.Instance.Select))
            {
                print("Ok");
                Build.Instance.SelectBuild(constructible);
            }
        }
    }
}

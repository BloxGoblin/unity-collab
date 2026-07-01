using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class SmeltOre : MonoBehaviour
{
    public GameObject _furnace;
    public BoxCollider _collider;
    public Transform dropsParent;

    public float heat;

    public List<GameObject> inFurnace = new List<GameObject>();

    [Header("Pick Up Settings")]
    public GameObject crosshair1; //1-Normal 2-Pick up 3-Drag
    public GameObject crosshair2;
    public GameObject crosshair3;
    public Transform _objectParent;
    public Transform _cameraTrans;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CanSmelt>())
        {
            if (!inFurnace.Contains(other.gameObject))
            {
               float meltingPoint = other.GetComponent<CanSmelt>().meltingPoint;
                if (heat >= meltingPoint)
                {
                    inFurnace.Add(other.gameObject);
                    other.GetComponent<CanSmelt>().smeltTime = meltingPoint/200; //Probably like a few seconds
                } 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (inFurnace.Contains(other.gameObject))
        {
            other.GetComponent<CanSmelt>().smeltTime = other.GetComponent<CanSmelt>().meltingPoint/200;
            inFurnace.Remove(other.gameObject);
        }
    }

    void Update()
    {
        if (inFurnace.Count > 0)
        {
            for (int i = inFurnace.Count - 1; i >= 0; i--)
            {
                GameObject content = inFurnace[i];
                if (content == null)
                {
                    inFurnace.RemoveAt(i);
                    continue;
                }
                float meltingPoint = content.GetComponent<CanSmelt>().meltingPoint;
                float smeltDuration = content.GetComponent<CanSmelt>().smeltTime;

                if (smeltDuration > 0)
                {
                    content.GetComponent<CanSmelt>().smeltTime -= Time.deltaTime * ((heat-meltingPoint) + 1); // If furnace thingy has bigger heat number deltatime gets markiplied by more so it cooks faster
                }
                else
                {
                    //smelt
                    GameObject result = content.GetComponent<CanSmelt>().smeltedItem.Object;
                    Vector3 spawnPos = content.transform.position; // Adjust this later

                    Instantiate(result, spawnPos, gameObject.transform.rotation, dropsParent);

                    if (result.name == "IronIngot")
                    {
                        AchievmentHandler.Instance.award(2); //Achievment for making iron ingot
                    }

                    if (result.GetComponent<PickUp>())
                    {
                        result.GetComponent<PickUp>().crosshair1 = crosshair1;
                        result.GetComponent<PickUp>().crosshair2 = crosshair2;
                        result.GetComponent<PickUp>().crosshair3 = crosshair3;
                        result.GetComponent<PickUp>()._objectParent = _objectParent;
                        result.GetComponent<PickUp>().cameraTrans = _cameraTrans;
                    }

                    Destroy(content);
                    inFurnace.RemoveAt(i);
                }
            }
        }
    }
}

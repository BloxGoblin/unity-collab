using Unity.VisualScripting;
using UnityEngine;

public class BasketballHoop : MonoBehaviour
{
    public GameObject _hoop;
    public BoxCollider _collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickUp>())
        {
            Destroy(other);
            print("Noob");
        }
    }
}

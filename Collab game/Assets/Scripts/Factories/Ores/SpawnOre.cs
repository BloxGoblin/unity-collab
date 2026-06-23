using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnOre : MonoBehaviour
{
    [Header("SetUp")]

    public GameObject _oreType;
    public Transform _spawnPoint;
    public Transform _oresParent;

    [Header("Customize")]

    public float _cooldown;
    public bool _canPickUpOres;

    [Header("ConfigurePickUp")]

    public GameObject crosshair1; //1-Normal 2-Pick up 3-Drag
    public GameObject crosshair2;
    public GameObject crosshair3;
    public Transform _objectParent;
    public Transform cameraTrans;

    private float _timeSinceLast;

    private void Update()
    {
        _timeSinceLast += Time.deltaTime;
        if (_timeSinceLast > _cooldown)
        {
            _timeSinceLast = 0;
            GameObject _ore = Instantiate(_oreType, _spawnPoint.position, _spawnPoint.rotation, _objectParent);

            if(_canPickUpOres == true)
            {
                // There is probably a much better way to do this
                _ore.GetComponent<PickUp>().crosshair1 = crosshair1;
                _ore.GetComponent<PickUp>().crosshair2 = crosshair2;
                _ore.GetComponent<PickUp>().crosshair3 = crosshair3;
                _ore.GetComponent<PickUp>()._objectParent = _objectParent;
                _ore.GetComponent<PickUp>().cameraTrans = cameraTrans;
            }
        }
    }
}

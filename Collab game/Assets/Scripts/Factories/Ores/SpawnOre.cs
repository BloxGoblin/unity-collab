using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnOre : MonoBehaviour
{
    [Header("SetUp")]

    public GameObject _oreType;
    public Transform _spawnPoint;
    public Transform _oresParent;
    public Transform player;

    [Header("Rate")]

    public float _cooldown;

    private float _timeSinceLast;

    private void Awake()
    {
        SetupOreSpawner.Instance.SetupSpawner(gameObject);
    }

    private void Update()
    {
        if (player.GetComponent<Player>().playing == false)
        {
            return;
        }
        
        _timeSinceLast += Time.deltaTime;
        if (_timeSinceLast > _cooldown)
        {
            _timeSinceLast = 0;
            GameObject _ore = Instantiate(_oreType, _spawnPoint.position, _spawnPoint.rotation, _oresParent);
        }
    }
}

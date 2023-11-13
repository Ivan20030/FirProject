using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public struct SeedSpawn
{
    public GameObject _cone;
    public float _spawnTime;
}

public class SeedSpawnComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _seed;
    [SerializeField]
    private int _seedCount;
    [SerializeField]
    private Transform _seedSpawnPoint;
    [SerializeField]
    private GameObject _spawnEffect;
    [SerializeField]
    private string _coneTag;
    [SerializeField]
    private float _deltaSpawnTime = 3.0f;

    private Queue<SeedSpawn> _seedSpawns = new Queue<SeedSpawn>();

    private void Update()
    {
        if (_seedSpawns.Count <= 0) return;
        
        if (Time.time > _seedSpawns.Peek()._spawnTime)
        {
            var seedSpawn = _seedSpawns.Dequeue();
            Destroy(seedSpawn._cone);
            Instantiate(_spawnEffect, _seedSpawnPoint.position, Quaternion.identity);
            for (int i = 0; i < _seedCount; i++)
            {
                Instantiate(_seed, _seedSpawnPoint.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent(out XRGrabInteractable grabComponent)) return;
        if (collider.tag == _coneTag && !grabComponent.isSelected)
        {
            var seedSpawn = new SeedSpawn { _cone = collider.gameObject, _spawnTime = Time.time + _deltaSpawnTime };
            _seedSpawns.Enqueue(seedSpawn);
        }
    }
}

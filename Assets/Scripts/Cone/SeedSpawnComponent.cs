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
    [SerializeField]
    private SceneText sceneText;
    private float _firstTime;

    private Queue<SeedSpawn> _seedSpawns = new Queue<SeedSpawn>();
    private bool textVisiable = false;

    //firstFlag1 для того, чтобы значение текста менялось только один раз
    private bool firstFlag1 = true;

    //firstFlag2 для того, чтобы значение текста менялось только один раз
    private bool firstFlag2 = true;

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

            if (firstFlag2)
            {
                sceneText.SetTreeState(TreeState.water);
                sceneText.setFirstFlag(true);
                firstFlag2 = false;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent(out XRGrabInteractable grabComponent)) return;
        if (collider.tag == _coneTag && !grabComponent.isSelected)
        {
            if (firstFlag1)
            {
                sceneText.SetTreeState(TreeState.seed);
                sceneText.setFirstFlag(true);
                firstFlag1 = false;
            }

            var seedSpawn = new SeedSpawn { _cone = collider.gameObject, _spawnTime = Time.time + _deltaSpawnTime };
            _seedSpawns.Enqueue(seedSpawn);
        }
    }
}

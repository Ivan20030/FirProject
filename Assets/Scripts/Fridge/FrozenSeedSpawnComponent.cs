using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class FrozenSeedSpawnComponent : MonoBehaviour
{
    [Header("Spawn settings")]
    [SerializeField]
    private Transform _seedSpawnPoint;
    [SerializeField]
    private Transform _containerSpawnPoint;
    [SerializeField]
    private float _spawnTime;
    private float _time;
    [Space]
    [SerializeField]
    private GameObject _seedModel;
    [SerializeField]
    private FridgeDoorComponent _door;
    [SerializeField]
    private GameObject _spawnEffect;
    [SerializeField]
    private SceneText _taskDescription;

    private Container _container = null;

    private bool _isCompletedStep = false;
    private bool _isSpawnSeeds = false;

    private void FixedUpdate()
    {
        if (_door.DoorState == FridgeDoorState.Closed && _container)
        {
            if (!_isSpawnSeeds)
            {
                _time = Time.time + _spawnTime;
                _isSpawnSeeds = true;
            }
            else if (_time < Time.time)
            {
                _container.transform.position = _containerSpawnPoint.position;
                _container.transform.rotation = Quaternion.identity;
                int seedsCount = _container.SeedsCount;
                _container.Clear();

                for (int i = 0; i < seedsCount; i++)
                {
                    GameObject spawnedFrozenSeed = Instantiate(_seedModel, _seedSpawnPoint.position, Quaternion.identity);
                    spawnedFrozenSeed.tag = "Frozen Seed";
                }

                Instantiate(_spawnEffect, _containerSpawnPoint.position, Quaternion.identity);

                if (!_isCompletedStep)
                {
                    _taskDescription.SetTreeState(TreeState.potty);
                    _taskDescription.setFirstFlag(true);
                    _isCompletedStep = false;
                }
                _isSpawnSeeds = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isGrabeable = other.TryGetComponent(out XRGrabInteractable grabComponent);
        bool isContainer = other.TryGetComponent(out Container container);

        if (isGrabeable && isContainer)
        {
            _container = container;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool isGrabeable = other.TryGetComponent(out XRGrabInteractable grabComponent);
        bool isContainer = other.TryGetComponent(out Container container);

        if (isGrabeable && isContainer) 
        {
            _container = null;
        }
    }
}

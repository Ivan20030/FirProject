using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FrozenSeedSpawnComponent : MonoBehaviour
{
    [Header("Spawn settings")]
    [SerializeField]
    private Transform _seedSpawnPoint;
    [SerializeField]
    private Transform _containerSpawnPoint;
    [SerializeField]
    private float _spawnTime;
    [Space]
    [SerializeField]
    private GameObject _seedModel;
    [SerializeField]
    private FridgeDoorComponent _door;
    [SerializeField]
    private GameObject _spawnEffect;

    private Container _container = null;

    private void FixedUpdate()
    {
        if (_door.DoorState == FridgeDoorState.Closed && _container)
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

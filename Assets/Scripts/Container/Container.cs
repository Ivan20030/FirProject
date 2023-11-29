using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Container : MonoBehaviour
{
    [SerializeField]
    private SceneText sceneText;
    [SerializeField]
    private Transform[] _seedsPoints;
    public int SeedsCount { get; private set; } = 0;

    private bool firstFlag1 = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out XRGrabInteractable grabComponent))
        {
            if (other.tag != "Seed" || grabComponent.isSelected) return;
            if (SeedsCount < _seedsPoints.Length)
            {
                //_seedsPoints[SeedsCount].GetComponent<MeshRenderer>().material = other.GetComponent<MeshRenderer>().material;
                GameObject seed = other.gameObject;
                seed.transform.parent = _seedsPoints[SeedsCount];
                seed.transform.localPosition = Vector3.zero;
                seed.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                seed.GetComponent<Rigidbody>().isKinematic = true;
            }
            SeedsCount++;
        }

        if (firstFlag1 && SeedsCount >= _seedsPoints.Length)
        {
            sceneText.SetTreeState(TreeState.fridge);
            sceneText.setFirstFlag(true);
            firstFlag1 = false;
        }
    }

    public void Clear()
    {
        SeedsCount = 0;
        foreach (Transform seed in _seedsPoints)
        {
            Material[] materials = seed.GetComponent<MeshRenderer>().materials;
            Array.Clear(materials, 0, materials.Length);
        }
    }
}
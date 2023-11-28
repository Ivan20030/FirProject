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
    private int _seedsCount = 0;

    private bool firstFlag1 = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out XRGrabInteractable grabComponent))
        {
            if (other.tag != "Seed" || grabComponent.isSelected) return;

            if (_seedsCount < _seedsPoints.Length)
            {
                _seedsPoints[_seedsCount].GetComponent<MeshRenderer>().material = other.GetComponent<MeshRenderer>().material;
            }
            _seedsCount++;
            if (_seedsCount >= _seedsPoints.Length && firstFlag1)
            {
                sceneText.SetTreeState(TreeState.fridge);
                sceneText.setFirstFlag(true);
                firstFlag1 = false;
            }
            Destroy(other.gameObject);
        }
    }
}
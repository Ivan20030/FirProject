using System;
using UnityEngine;
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
                _seedsPoints[SeedsCount].GetComponent<MeshRenderer>().enabled = true;
                Destroy(other.gameObject);
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
            seed.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
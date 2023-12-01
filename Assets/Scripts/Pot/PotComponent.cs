using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PotComponent : MonoBehaviour
{
    [SerializeField]
    private CalendarManager _calendarManager;
    [SerializeField]
    private GameObject _fir;

    private void Update()
    {
        if (gameObject.tag == "Pot with Seed" && _calendarManager.MonthNumber == 3)
        {
            _fir.SetActive(true);
            gameObject.tag = "Tree in Pot";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isGrabeable = other.TryGetComponent(out XRGrabInteractable grabComponent);
        if (isGrabeable && other.tag == "Frozen Seed")
        {
            Destroy(other.gameObject);
            gameObject.tag = "Pot with Seed";
        }
    }
}

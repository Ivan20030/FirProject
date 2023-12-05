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

    [SerializeField]
    private FirSpawn _firSpawn;

    [SerializeField]
    private SceneText _sceneText;

    private bool Flag1 = true;
    private bool Flag2 = true;

    private void Update()
    {
        if (Flag2 && gameObject.tag == "Pot with Seed" && _calendarManager.MonthNumber == 3)
        {
            _fir.SetActive(true);
            gameObject.tag = "Tree in Pot";

            if (Flag2)
            {
                _sceneText.SetTreeState(TreeState.calendar);
                _sceneText.setFirstFlag(true);
                Flag2 = false;
            }

            _firSpawn.SpawnArrow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isGrabeable = other.TryGetComponent(out XRGrabInteractable grabComponent);
        if (isGrabeable && other.tag == "Frozen Seed")
        {
            Destroy(other.gameObject);
            gameObject.tag = "Pot with Seed";

            if (Flag1)
            {
                _sceneText.SetTreeState(TreeState.soil);
                _sceneText.setFirstFlag(true);
                Flag1 = false;
            }
        }
    }
}

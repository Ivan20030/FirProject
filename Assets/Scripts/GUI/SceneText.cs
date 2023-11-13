using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class SceneText : MonoBehaviour
{
    public GameObject HeadText;

    bool TriggerPressed;
    bool TriggerPressing;

    public InputActionReference A;
    private void Update()
    {
        TriggerPressed = (A.action.ReadValue<float>() > 0.5f) && !TriggerPressing ? true : false;
        TriggerPressing = (A.action.ReadValue<float>() > 0.5f) ? true : false;

        if (TriggerPressed)
        {
            if (Input.GetKeyDown(KeyCode.W) || A)
            {
                if (HeadText.activeInHierarchy)
                {
                    HeadText.SetActive(false);
                }
                else
                {
                    HeadText.SetActive(true);
                }
            }
        }
    }
}

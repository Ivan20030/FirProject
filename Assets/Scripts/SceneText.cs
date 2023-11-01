using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class SceneText : MonoBehaviour
{
    public GameObject HeadText;

    public InputActionReference A;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && A)
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

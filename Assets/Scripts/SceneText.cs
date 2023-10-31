using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class SceneText : MonoBehaviour
{
    public GameObject HeadText;
    private void Update()
    {
        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.secondary2DAxis, out Vector2 axisValue)){// || Input.GetKeyDown(KeyCode.W)){
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneText : MonoBehaviour
{
    public GameObject HeadText;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && HeadText.activeInHierarchy)
        {
            HeadText.SetActive(false);
        }
        else if(OVRInput.GetDown(OVRInput.Button.One) && !HeadText.activeInHierarchy)
        {
            HeadText.SetActive(true);
        }
    }
}

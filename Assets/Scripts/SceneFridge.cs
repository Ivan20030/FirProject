using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneFridge : MonoBehaviour
{
    bool IsOpened = false;
    public void OnClick(SelectEnterEventArgs context)
    {
        if (!IsOpened)
        {
            transform.rotation = Quaternion.Euler(0,150,0);
            IsOpened = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 297, 0);
            IsOpened = false;
        }
    }
}

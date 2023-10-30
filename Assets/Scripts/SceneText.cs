using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneText : MonoBehaviour
{
    public GameObject HeadText;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
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

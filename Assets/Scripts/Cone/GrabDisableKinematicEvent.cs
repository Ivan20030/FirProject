using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class GrabDisableKinematicEvent : MonoBehaviour
{
    public void DisableKinematic(ActivateEventArgs activateEventArgs)
    {
        print(activateEventArgs.interactableObject.ToString());
    }
}

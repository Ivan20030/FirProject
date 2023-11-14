using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

enum FridgeDoorState 
{
    None = 0,
    WantOpen,
    WantClose,
    Opened,
    Closed
}

public class FridgeDoorComponent : MonoBehaviour
{
    private FridgeDoorState _doorState = FridgeDoorState.Closed;

    void Update()
    {
        switch (_doorState)
        {
            case FridgeDoorState.WantOpen:
                if (transform.localRotation.y <= Quaternion.Euler(0.0f, 0.0f, 0.0f).y)
                {
                    _doorState = FridgeDoorState.Opened;
                    break;
                }
                transform.Rotate(0, -180 * Time.deltaTime, 0);
                break;
            case FridgeDoorState.WantClose:
                if (transform.localRotation.y >= Quaternion.Euler(0.0f, 142.0f, 0.0f).y)
                {
                    _doorState = FridgeDoorState.Closed;
                    break;
                }
                transform.Rotate(0, 180 * Time.deltaTime, 0);
                break;
        }
    }

    public void OpenDoor(SelectExitEventArgs context)
    {
        switch (_doorState)
        {
            case FridgeDoorState.Opened:
                _doorState = FridgeDoorState.WantClose;
                break;
            case FridgeDoorState.Closed:
                _doorState = FridgeDoorState.WantOpen;
                break;
        }
    }
}

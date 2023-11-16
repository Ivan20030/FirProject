using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

enum FridgeDoorState 
{
    WantOpen = 0,
    WantClose,
    Opened,
    Closed
}

public class FridgeDoorComponent : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Text1;

    private FridgeDoorState _doorState = FridgeDoorState.Closed;
    private Quaternion _startDoorRotation = Quaternion.identity;
    private Quaternion _destinationDoorRotation = Quaternion.identity;
    private XRGrabInteractable _interactable;
    private float _timeCount = 0.0f;

    private void Start() => _interactable = GetComponent<XRGrabInteractable>();

    void Update()
    {
        if (_doorState == FridgeDoorState.Opened || _doorState == FridgeDoorState.Closed) return;

        transform.localRotation = Quaternion.Lerp(_startDoorRotation, _destinationDoorRotation, _timeCount);
        _timeCount += Time.deltaTime;
        if (_timeCount >= 1.0f)
        {
            if (_doorState == FridgeDoorState.WantOpen) _doorState = FridgeDoorState.Opened;
            else if (_doorState == FridgeDoorState.WantClose) _doorState = FridgeDoorState.Closed;
            _interactable.enabled = true;
            return;
        }
    }

    public void OpenDoor(SelectExitEventArgs context)
    {
        switch (_doorState)
        {
            case FridgeDoorState.Opened:
                _doorState = FridgeDoorState.WantClose;
                _destinationDoorRotation = Quaternion.Euler(0.0f, 142.0f, 0.0f);
                break;
            case FridgeDoorState.Closed:
                _doorState = FridgeDoorState.WantOpen;
                _destinationDoorRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;
            default:
                return;
        }
        _timeCount = 0;
        _startDoorRotation = transform.localRotation;
        _interactable.enabled = false;
    }
}

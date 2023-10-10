using UnityEngine;
using UnityEngine.XR;

public class HandInteraction : MonoBehaviour
{
    [SerializeField] private bool _isLeftHand;
    private VRInputDeviceManager _inputDeviceManager;
    private GrabeableItem _grabedItem;

    private void Awake() => _inputDeviceManager = GetComponentInParent<VRInputDeviceManager>();

    private void Update()
    {
        var inputDevice = _isLeftHand ? _inputDeviceManager.LeftController : _inputDeviceManager.RightController;
        TryGrabeItem(ref inputDevice);
        TryReleaseItem(ref inputDevice);
    }

    private void TryGrabeItem(ref InputDevice inputDevice)
    {
        inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool isWantGrabe);
        if (!isWantGrabe) return;

        Collider[] nearestColliders = Physics.OverlapSphere(transform.position, 0.08f);
        foreach (var collider in nearestColliders)
        {
            if (!collider.TryGetComponent(out GrabeableItem item)) continue;
            HandInteraction hand = item.GetComponentInParent<HandInteraction>();
            if (hand != null)
            {
                hand.ReleaseItem();
            }
            GrabeItem(item);
        }
    }

    private void TryReleaseItem(ref InputDevice inputDevice)
    {
        inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool isWantGrabe);
        if (isWantGrabe) return;
        ReleaseItem();
    }

    public void GrabeItem(GrabeableItem item)
    {
        if (_grabedItem != null) return;

        item.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = transform.position;
        item.transform.SetParent(transform);
        _grabedItem = item;
    }

    public void ReleaseItem()
    {
        if (_grabedItem == null) return;

        _grabedItem.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        _grabedItem.transform.SetParent(null);
        _grabedItem = null;
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneFridge : MonoBehaviour
{
    bool IsOpened = false;
    public TMP_Text Text1;
    public void OnClick(SelectEnterEventArgs context)
    {
        if (!IsOpened)
        {
            transform.rotation = Quaternion.Euler(0,150,0);
            Text1.SetText("Нажмите, чтобы закрыть");
            IsOpened = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 297, 0);
            Text1.SetText("Нажмите, чтобы открыть");
            IsOpened = false;
        }
    }
}

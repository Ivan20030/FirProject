using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{
    [SerializeField]
    private Text _textMonth;
    public int MonthNumber { get; private set; }

    private AudioSource _audioSource;

    private void Start()
    {
        MonthNumber = Random.Range(1, 13);
        _textMonth.text = MonthNumberConvertToString(MonthNumber);
        _audioSource = GetComponent<AudioSource>();
    }

    public void NextMonth()
    {
        MonthNumber++;
        if (MonthNumber > 12) MonthNumber = 1;
        _textMonth.text = MonthNumberConvertToString(MonthNumber);
        _audioSource.Play();
    }

    public void PreviousMonth()
    {
        MonthNumber--;
        if (MonthNumber < 1) MonthNumber = 12;
        _textMonth.text = MonthNumberConvertToString(MonthNumber);
        _audioSource.Play();
    }

    private string MonthNumberConvertToString(int month)
        => month switch
        {
            1 => "������",
            2 => "�������",
            3 => "����",
            4 => "������",
            5 => "���",
            6 => "����",
            7 => "����",
            8 => "������",
            9 => "��������",
            10 => "�������",
            11 => "������",
            12 => "�������",
            _ => "ERROR_MONTH"
        };
}

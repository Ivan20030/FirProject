using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{
    [SerializeField]
    private Text _textMonth;
    public int MonthNumber { get; private set; }

    private void Start()
    {
        MonthNumber = Random.Range(1, 13);
        _textMonth.text = MonthNumberConvertToString(MonthNumber);
    }

    public void NextMonth()
    {
        MonthNumber++;
        if (MonthNumber > 12) MonthNumber = 1;
        _textMonth.text = MonthNumberConvertToString(MonthNumber);
    }

    public void PreviousMonth()
    {
        MonthNumber--;
        if (MonthNumber < 1) MonthNumber = 12;
        _textMonth.text = MonthNumberConvertToString(MonthNumber);
    }

    private string MonthNumberConvertToString(int month)
        => month switch
        {
            1 => "Январь",
            2 => "Февраль",
            3 => "Март",
            4 => "Апрель",
            5 => "Май",
            6 => "Июнь",
            7 => "Июль",
            8 => "Август",
            9 => "Сентябрь",
            10 => "Октябрь",
            11 => "Ноябрь",
            12 => "Декабрь",
            _ => "ERROR_MONTH"
        };
}

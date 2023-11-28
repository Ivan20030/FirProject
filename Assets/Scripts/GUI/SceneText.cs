﻿using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public enum TreeState
{
    start,
    seed,
    water,
    fridge,
    potty,
    soil,
    end
}

public class SceneText : MonoBehaviour
{
    public GameObject HeadText;
    public TMP_Text taskTexts;

    bool TriggerPressed;
    bool TriggerPressing;

    public InputActionReference A;
    private string[] textMass;

    private TreeState sceneTextActivate;
    private bool firstFlag = false;

    public void setFirstFlag(bool flag)
    {
        firstFlag = flag;
    }

    public TreeState GetTreeState()
    {
        return sceneTextActivate;
    }

    public void SetTreeState(TreeState textActivate)
    {
        sceneTextActivate = textActivate;
    }

    public string[] getTextMass()
    {
        return textMass;
    }

    private void Update()
    {
        TriggerPressed = (A.action.ReadValue<float>() > 0.5f) && !TriggerPressing ? true : false;
        TriggerPressing = (A.action.ReadValue<float>() > 0.5f) ? true : false;

        if (TriggerPressed)
        {
            if (Input.GetKeyDown(KeyCode.W) || A)
            {
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
        switch (sceneTextActivate)
        {
            case TreeState.seed:
                if (firstFlag)
                {
                    taskTexts.SetText(getTextMass()[0]);
                    HeadText.SetActive(true);
                    firstFlag = false;
                }
                break;
            case TreeState.water:
                if (firstFlag)
                {
                    taskTexts.SetText(getTextMass()[1]);
                    HeadText.SetActive(true);
                    firstFlag = false;
                }
                break;
            case TreeState.fridge:
                if (firstFlag)
                {
                    taskTexts.SetText(getTextMass()[2]);
                    HeadText.SetActive(true);
                    firstFlag = false;
                }
                break;
            case TreeState.potty:
                if (firstFlag)
                {
                    taskTexts.SetText(getTextMass()[3]);
                    HeadText.SetActive(true);
                    firstFlag = false;
                }
                break;
        }
    }
    private void Start()
    {
        textMass = new string[6];

        textMass[0] = " Отлично! Мы положили шишку в светлое и сухое место. Через несколько часов\n" +
            "можно будет из нее извлечь семена.";
        textMass[1] = " Замечательно! Семена извлечены.\n" +
            "Для воссоздания природных условий, предлагаю положить их в контейнер с водой.";
        textMass[2] = "А для ускорения прорастания положим контейнер с семенами в холодильник";
        textMass[3] = "Семена обработаны так, как надо,\n" +
            "однако сначала мы высадим их в горшочек и дождемся Марта (Проверь календарь).";
        textMass[4] = "Ура! У нас появились первые побеги, можно пересаживать в открытое место.";
        textMass[5] = "Вы прошли полный цикл роста ели.\n" +
            "Хотели бы посадить ель снова?";
    }

}
using OpenAI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerAnswerEvent : UnityEvent<bool> { }

public class ButtonValidation : MonoBehaviour
{
    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private List<Button> buttons;

    [SerializeField]
    private ImageColorUI buttonImageColor;

    public PlayerAnswerEvent PlayerAnswerEvent = new();

    void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnClickValidateButton(button));
        }
    }

    private bool IsCorrectAnswer(string buttonText)
    {
        if (this.quiz.Questions.ElementAt(0).Answer.IndexOf(buttonText,
            StringComparison.OrdinalIgnoreCase) == -1)
        {
            return false;
        }

        return true;
    }

    private void OnClickValidateButton(Button button)
    {
        string clickedButtonText = button.GetComponentInChildren<TextMeshProUGUI>().text;
        Image clickedButtonImage = button.GetComponentInChildren<UnityEngine.UI.Image>();

        if (IsCorrectAnswer(clickedButtonText))
        {
            this.buttonImageColor.SetValidColor(clickedButtonImage);

            OnPlayerAnswer(true);
        }
        else
        {
            this.buttonImageColor.SetInvalidColor(clickedButtonImage);
            ValidateNonClickedButtons();

            OnPlayerAnswer(false);
        }
    }

    public void ValidateNonClickedButtons()
    {
        foreach (var button in buttons)
        {
            string buttonText = button.GetComponentInChildren<TextMeshProUGUI>().text;
            Image buttonImage = button.GetComponentInChildren<UnityEngine.UI.Image>();

            if (IsCorrectAnswer(buttonText))
            {
                this.buttonImageColor.SetValidColor(buttonImage);
                break;
            }
        }
    }

    private void OnPlayerAnswer(bool isValid)
    {
        this.PlayerAnswerEvent?.Invoke(isValid);
    }
}

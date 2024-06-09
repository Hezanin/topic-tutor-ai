using PlayFab.ClientModels;
using PlayFab;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountRecoverySystem : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField email;

    [SerializeField]
    private Canvases canvases;

    [SerializeField]
    private Button loginButton;

    [SerializeField]
    private ErrorManager errorManager;

    // Start is called before the first frame update
    void Start()
    {
        this.loginButton.onClick.AddListener(LoginButton_OnClick);
    }

    private bool UserInputIsValid()
    {
        if (String.IsNullOrEmpty(email.text))
        {
            this.errorManager.DisplayRegisterError("Input cannot be empty");

            return false;
        }

        return true;
    }

    private void LoginButton_OnClick()
    {
        this.canvases.ErrorHandlingCanvas.Hide();
        this.canvases.AccountRecoveryCanvas.Hide();
        this.canvases.LoginAccountCanvas.Show();
    }

    public void SendAccountRecoveryRequest()
    {
        if (!UserInputIsValid())
        {
            this.canvases.ErrorHandlingCanvas.Show();
            return;
        }

        SendAccountRecoveryEmailRequest accountRecoveryRequest = new()
        {
            Email = this.email.text,
            TitleId = "FA028"
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(accountRecoveryRequest, OnRecoverySuccess, OnRecoveryError);
    }
    private void OnRecoveryError(PlayFabError error)
    {
        this.errorManager.DisplayLoginError(error.ErrorMessage);

        this.canvases.ErrorHandlingCanvas.Show();
    }

    private void OnRecoverySuccess(SendAccountRecoveryEmailResult result)
    {
        LoginButton_OnClick();
    }
}

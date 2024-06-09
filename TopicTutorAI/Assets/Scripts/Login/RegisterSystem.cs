using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class RegisterSystem : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField username;

    [SerializeField]
    private TMP_InputField email;

    [SerializeField]
    private TMP_InputField password;

    [SerializeField]
    private Canvases canvases;

    [SerializeField]
    private ErrorManager errorManager;

    [SerializeField]
    private Button loginButton;

    private void Start()
    {
        loginButton.onClick.AddListener(loginButton_OnClick);
    }

    private void loginButton_OnClick()
    {
        this.canvases.ErrorHandlingCanvas.Hide();
        this.canvases.RegisterAccountCanvas.Hide();
        this.canvases.LoginAccountCanvas.Show();
    }

    private bool UserInputIsValid()
    {
        if (String.IsNullOrEmpty(password.text) && (String.IsNullOrEmpty(username.text) ||
            String.IsNullOrEmpty(email.text)))
        {
            this.errorManager.DisplayRegisterError("Input cannot be empty");

            return false;
        }

        if (password.text.Length < 6)
        {
            this.errorManager.DisplayRegisterError("Password must be at least 6 characters long");

            return false;
        }      

        return true;
    }

    private void OnError(PlayFabError error)
    {      
        this.errorManager.DisplayRegisterError(error.ErrorMessage);

        this.canvases.ErrorHandlingCanvas.Show();
    }

    private void OnSucces(RegisterPlayFabUserResult result)
    {
        this.canvases.ErrorHandlingCanvas.Hide();

        loginButton_OnClick();
    }

    public void Register()
    {
        if (!UserInputIsValid())
        {
            this.canvases.ErrorHandlingCanvas.Show();
            return;
        }

        RegisterPlayFabUserRequest registerRequest = new()
        {
            DisplayName = this.username.text,
            Email = this.email.text,
            Password = this.password.text,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnSucces, OnError);
    }
}

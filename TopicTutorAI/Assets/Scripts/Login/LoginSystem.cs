
using TMPro;
using UnityEngine;
using PlayFab;
using UnityEngine.UI;
using System;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class LoginSystem : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField email;

    [SerializeField]
    private TMP_InputField password;

    [SerializeField]
    private Button registerButton;

    [SerializeField]
    private Button forgotPasswordButton;

    [SerializeField]
    private Canvases canvases;

    [SerializeField]
    private ErrorManager errorManager;

    private void Start()
    {
        this.registerButton.onClick.AddListener(RegisterButton_OnClick);
        this.forgotPasswordButton.onClick.AddListener(ForgotPasswordButton_OnClick);
    }

    private bool UserInputIsValid()
    {
        if (String.IsNullOrEmpty(password.text) || String.IsNullOrEmpty(email.text))
        {
            this.errorManager.DisplayRegisterError("Input cannot be empty");

            return false;
        }

        return true;
    }
    private void ForgotPasswordButton_OnClick()
    {
        this.canvases.ErrorHandlingCanvas.Hide();
        this.canvases.LoginAccountCanvas.Hide();
        this.canvases.AccountRecoveryCanvas.Show();
    }
 
    private void RegisterButton_OnClick()
    {
        this.canvases.ErrorHandlingCanvas.Hide();
        this.canvases.LoginAccountCanvas.Hide();
        this.canvases.RegisterAccountCanvas.Show();
    }

    public void Login()
    {
        if (!UserInputIsValid())
        {
            this.canvases.ErrorHandlingCanvas.Show();
            return;
        }

        LoginWithEmailAddressRequest loginRequest = new()
        {
            Email = this.email.text,
            Password = this.password.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(loginRequest, OnLoginSucces, OnLoginError);
    }

    private void OnLoginError(PlayFabError error)
    {
        this.errorManager.DisplayLoginError(error.ErrorMessage);

        this.canvases.ErrorHandlingCanvas.Show();
    }

    private void OnLoginSucces(LoginResult result)
    {
        if (PlayerPlayfabProfile.Instance != null)
        {
            PlayerPlayfabProfile.Instance.GetPlayerProfile();
            PlayerPlayfabProfile.Instance.GetLeaderboard();
            PlayerPlayfabProfile.Instance.GetPlayerLeaderboardScore();
        }
        else
        {
            Debug.LogError("Player information could  not be retrieved");
            return;
        }

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text errorMessage;

    public void DisplayLoginError(string errorMessage = null)
    {
        if (errorMessage == null)
        {
            this.errorMessage.text = "Failed To Login";
        }

        this.errorMessage.text = errorMessage;
    }

    public void DisplayRegisterError(string errorMessage = null)
    {
        if (errorMessage == null)
        {
            this.errorMessage.text = "Failed To Register";
        }

        this.errorMessage.text = errorMessage;
    }
}

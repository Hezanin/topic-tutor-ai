using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseToMenu : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;

    void Start()
    {
        this.closeButton.onClick.AddListener(closeButton_OnClick);
    }

    private void closeButton_OnClick()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}

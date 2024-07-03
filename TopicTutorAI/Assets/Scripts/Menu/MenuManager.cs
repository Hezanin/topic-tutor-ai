using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigationManager : MonoBehaviour
{
    [SerializeField]
    private Button singleplayerModeButton;

    [SerializeField]
    private Button multiplayerModeButton;

    private void Start()
    {
        this.singleplayerModeButton.onClick.AddListener(singleplayerModeButton_OnCLick);
        this.multiplayerModeButton.onClick.AddListener(multiplayerModeButton_OnClick);
    }

    private void singleplayerModeButton_OnCLick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    private void multiplayerModeButton_OnClick() 
    {
        SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
    }
}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseToMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Button closeButton;

    void Start()
    {
        this.closeButton.onClick.AddListener(closeButton_OnClick);
    }

    private void closeButton_OnClick()
    {
        if (PhotonNetwork.IsConnected)
        {
            LeaveRoom();
        }
        else
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }     
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);

        base.OnLeftRoom();
    }
}

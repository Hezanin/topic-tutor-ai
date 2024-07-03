using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    void Start()
    {
        SetUserNickname();

        Debug.Log("Connecting to server");

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }       
    }

    public override void OnConnectedToMaster()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Disconnected {cause.ToString()}");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby!");   
    }

    private void SetUserNickname()
    {
        if (PlayerPlayfabProfile.Instance == null)
        {
            Debug.LogError("PlayerProfile is null and cannot retrieve nickname");
        }
        else
        {
            PhotonNetwork.NickName = PlayerPlayfabProfile.Instance.Profile.DisplayName;
        }
    }
}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text roomName;

    [SerializeField]
    private RoomsCanvases roomsCanvases;

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        RoomOptions roomOptions = new();
        roomOptions.MaxPlayers = 4;

        PhotonNetwork.JoinOrCreateRoom(this.roomName.text, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"Created Room {this.roomName.text} Successfully", this);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Created Room Successfully {message.ToString()}", this);
    }
}

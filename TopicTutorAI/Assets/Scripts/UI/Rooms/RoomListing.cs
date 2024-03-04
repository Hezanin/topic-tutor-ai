using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public RoomInfo RoomInfo {  get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        this.RoomInfo = roomInfo;
        this.text.text = $"{roomInfo.Name} / {roomInfo.MaxPlayers}";
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}

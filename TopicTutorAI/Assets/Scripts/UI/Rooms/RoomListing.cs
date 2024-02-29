using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        this.text.text = $"{roomInfo.Name} / {roomInfo.MaxPlayers}";
    }
}

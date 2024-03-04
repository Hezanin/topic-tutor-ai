using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    [SerializeField]
    private RoomsCanvases roomCanvases;

   public void OnClick_LeaveRoom()
   {
        PhotonNetwork.LeaveRoom(true);
        this.roomCanvases.CurrentRoomCanvas.Hide();
        this.roomCanvases.CreateOrJoinRoomCanvas.Show();
    }
}

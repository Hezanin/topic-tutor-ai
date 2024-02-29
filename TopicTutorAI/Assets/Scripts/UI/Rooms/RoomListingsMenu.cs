using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomListing roomListing;

    [SerializeField]
    private Transform content;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo roomInfo in roomList)
        {
            RoomListing listing = Instantiate(this.roomListing, this.content);

            if (listing != null)
            {
                listing.SetRoomInfo(roomInfo);
            }
        }
    }
}

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

    private List<RoomListing> listings = new List<RoomListing>();

    [SerializeField]
    private RoomsCanvases roomCanvases;

    public override void OnJoinedRoom()
    {
        this.roomCanvases.CurrentRoomCanvas.Show();
        this.content.DestroyChildren();
        this.listings.Clear();
        this.roomCanvases.CreateOrJoinRoomCanvas.Hide();     
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == roomInfo.Name);
                if (index != -1) 
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else
            {
                int index = this.listings.FindIndex(x => x.RoomInfo.Name == roomInfo.Name);

                if (index == -1)
                {
                    RoomListing listing = Instantiate(this.roomListing, this.content);

                    if (listing != null)
                    {
                        listing.SetRoomInfo(roomInfo);
                        this.listings.Add(listing);
                    }
                }
            }           
        }
    }
}

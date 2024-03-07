using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerListing playerListing;

    [SerializeField]
    private Transform content;

    private List<PlayerListing> listings = new List<PlayerListing>();

    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayers();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < this.listings.Count; i++)
        {
            Destroy(this.listings[i].gameObject);
        }

        this.listings.Clear();
    }

    public override void OnLeftRoom()
    {
        this.content.DestroyChildren();
    }

    private void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
        {
            return;
        }

        foreach (KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void AddPlayerListing(Player player)
    {
        int index = this.listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            this.listings[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(this.playerListing, this.content);

            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                this.listings.Add(listing);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public void OnCLick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false; 
            PhotonNetwork.LoadLevel(1);
        }
    }
}

using Newtonsoft.Json.Bson;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerListing playerListing;

    [SerializeField]
    private Transform content;

    private List<PlayerListing> listings = new List<PlayerListing>();

    [SerializeField]
    private TMP_Text readyUpText;

    [SerializeField]
    private RoomsCanvases roomCanvases;

    private bool ready = false;
    private void SetReadyUp(bool state)
    {
        this.ready = state;

        if (ready)
        {
            this.readyUpText.text = "Ready!";
        }
        else
        {
            this.readyUpText.text = "Not Ready!";
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SetReadyUp(false);
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

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        this.roomCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public void OnCLick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < this.listings.Count; i++) 
            {
                if (this.listings[i].Player != PhotonNetwork.LocalPlayer)
                {
                    if (!this.listings[i].Ready)
                    {
                        return;
                    }
                }
            }

            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false; 
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void OnClick_ReadyUp()
    {
        if (!PhotonNetwork.IsMasterClient) 
        {
            SetReadyUp(!this.ready);
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, this.ready);
        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = this.listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            this.listings[index].Ready = ready;
        }
    }
} 

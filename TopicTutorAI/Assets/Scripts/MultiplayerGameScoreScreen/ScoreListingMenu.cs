using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private ScoreListing scoreListing;

    [SerializeField]
    private Transform content;

    private List<ScoreListing> scoreListings = new();

    private void AddPlayerScoreListing(Player player)
    {
        int index = this.scoreListings.FindIndex(x => x.Player == player);

        if (index != -1)
        {
            this.scoreListings[index].Set(player);
        }
        else
        {
            ScoreListing listing = Instantiate(this.scoreListing, this.content);

            if (listing != null)
            {
                listing.Set(player);
                this.scoreListings.Add(listing);
            }
        }
    }

    public void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerScoreListing(playerInfo.Value);
        }

        SetLocalPlayerScoreListingUI();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerScoreListing(newPlayer);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < this.scoreListings.Count; i++)
        {
            Destroy(this.scoreListings[i].gameObject);
        }

        this.scoreListings.Clear();
    }

    private void SetLocalPlayerScoreListingUI()
    {
        int index = this.scoreListings.FindIndex(x => x.Player == PhotonNetwork.LocalPlayer);

        if (index != -1)
        {
            this.scoreListings[index].rawImageBackground.color = ColorUI.activeColor;
        }
    }
}

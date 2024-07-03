using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLeaderboardListing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerName;

    [SerializeField]
    private TMP_Text playerScore;

    [SerializeField]
    private TMP_Text playerPosition;

    public void SetPlayerLeaderboardListing(PlayerLeaderboardEntry playerLeaderboardEntry)
    {
        this.playerName.text = playerLeaderboardEntry.DisplayName;
        this.playerScore.text = playerLeaderboardEntry.StatValue.ToString();
        this.playerPosition.text = playerLeaderboardEntry.Position.ToString();
    }
}

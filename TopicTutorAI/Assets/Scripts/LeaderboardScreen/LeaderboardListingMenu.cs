using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardListingMenu : MonoBehaviour
{
    [SerializeField]
    private Transform content;

    [SerializeField]
    private PlayerLeaderboardListing playerLeaderboardListing;

    private void Start()
    {
        if (PlayerPlayfabProfile.Instance != null)
        {
            PlayerPlayfabProfile.Instance.GetLeaderboard();
            
            GetPlayerLeaderboardListing();
        }
        else
        {
            Debug.LogError("PLAYER INSTANCE IS NULL! (PLAYER PROFILE)");
        }       
    }

    private void GetPlayerLeaderboardListing()
    {

        foreach (PlayerLeaderboardEntry item in PlayerPlayfabProfile.Instance.PlayerLeaderboardListings)
        {
            PlayerLeaderboardListing listing = Instantiate(this.playerLeaderboardListing, this.content);

            if (listing != null)
            {
                listing.SetPlayerLeaderboardListing(item);
            }
        }
    }
}

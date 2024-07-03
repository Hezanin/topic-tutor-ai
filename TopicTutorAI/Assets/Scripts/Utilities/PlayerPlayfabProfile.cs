using Photon.Pun.Demo.Cockpit;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlayfabProfile : MonoBehaviour
{
    public static PlayerPlayfabProfile Instance {  get; private set; }

    public PlayerProfileModel Profile { get; private set; }

    public PlayerLeaderboardEntry PlayerLeaderboardEntry { get; private set; }

    public List<PlayerLeaderboardEntry> PlayerLeaderboardListings { get; private set; }

    private void Start()
    {
        this.PlayerLeaderboardListings = new();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetLeaderboard()
    {
        GetLeaderboardRequest getLeaderboardRequest = new()
        {
            StatisticName = "GlobalScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };

        PlayFabClientAPI.GetLeaderboard(getLeaderboardRequest, OnGetLeaderboardSuccess, OnGetLeaderboardError);
    }

    private void OnGetLeaderboardSuccess(GetLeaderboardResult result)
     {
        this.PlayerLeaderboardListings = new();

        for (int i = 0;  i < result.Leaderboard.Count; i++) 
        {
            this.PlayerLeaderboardListings.Add(result.Leaderboard[i]);
            Debug.Log($"{this.PlayerLeaderboardListings[i].DisplayName}, {this.PlayerLeaderboardListings[i].Position}");
        }
    }

    private void OnGetLeaderboardError(PlayFabError error)
    {
        Debug.LogError("Error retrieving global leaderboard: " + error.GenerateErrorReport());
    }

    public void GetPlayerProfile()
    {
        GetPlayerProfileRequest request = new()
        {
            PlayFabId = PlayFabSettings.staticPlayer.PlayFabId,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowDisplayName = true,
                ShowAvatarUrl = true,
                ShowStatistics = true,
            }
        };

        PlayFabClientAPI.GetPlayerProfile(request, OnGetPlayerProfileSuccess, OnGetPlayerProfileFailure);
    }

    private void OnGetPlayerProfileSuccess(GetPlayerProfileResult result)
    {
        this.Profile = result.PlayerProfile;
        Debug.Log($"THE PLAYER NAME IS: {this.Profile.DisplayName}");
    }

    private void OnGetPlayerProfileFailure(PlayFabError error)
    {
        Debug.LogError(error.ToString());   
    }

    public void GetPlayerLeaderboardScore()
    {
        GetLeaderboardAroundPlayerRequest request = new()
        {
            StatisticName = "GlobalScore",
            MaxResultsCount = 1,
            PlayFabId = PlayFabSettings.staticPlayer.PlayFabId
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetLeaderboardAroundPlayerSuccess, OnGetLeaderboardAroundPlayerFailure);
    }

    private void OnGetLeaderboardAroundPlayerSuccess(GetLeaderboardAroundPlayerResult result)
    {
        if (result.Leaderboard.Count > 0)
        {
            this.PlayerLeaderboardEntry = result.Leaderboard[0];
        }
        else
        {
            Debug.LogError("Player is not in the leaderboard.");
        }
    }

    private void OnGetLeaderboardAroundPlayerFailure(PlayFabError error)
    {
        Debug.LogError("Error retrieving player leaderboard: " + error.GenerateErrorReport());
    }

    public void Logout()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        SceneManager.LoadScene("Login");
    }
}

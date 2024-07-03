using PlayFab;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfileSystem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerName;

    [SerializeField]
    private TMP_Text playerScore;

    [SerializeField]
    private TMP_Text playerId;

    [SerializeField]
    private TMP_Text playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPlayfabProfile.Instance != null)
        {
            PlayerPlayfabProfile.Instance.GetLeaderboard();
            PlayerPlayfabProfile.Instance.GetPlayerLeaderboardScore();
            SetPlayerProfileInformation();
            Debug.Log($"PLAYER info updated to {this.playerName.text}, {this.playerId.text}, {this.playerScore.text}!!! (PLAYER PROFILE)");
        }
        else
        {
            Debug.LogError("PLAYER INSTANCE IS NULL! (PLAYER PROFILE)");
        }
    }

    public void SetPlayerProfileInformation()
    {
        if (PlayerPlayfabProfile.Instance.Profile == null)
        {
            Debug.LogError("Error retrieving profile");
            return;
        }

        this.playerName.text = PlayerPlayfabProfile.Instance.Profile.DisplayName;

        if (PlayerPlayfabProfile.Instance.PlayerLeaderboardEntry == null)
        {
            Debug.LogError("Error retrieving leaderboard");
            return;
        }
        
        this.playerScore.text = PlayerPlayfabProfile.Instance.PlayerLeaderboardEntry.StatValue.ToString();
        this.playerId.text = PlayerPlayfabProfile.Instance.PlayerLeaderboardEntry.PlayFabId;
        this.playerPosition.text = PlayerPlayfabProfile.Instance.PlayerLeaderboardEntry.Position.ToString();
    }

    public void OnLogoutButtonClick()
    {
        PlayerPlayfabProfile.Instance.Logout();
    }
}

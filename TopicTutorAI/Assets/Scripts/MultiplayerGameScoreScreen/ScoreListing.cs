using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text playerName;

    [SerializeField]
    private TMP_Text playerScore;

    [SerializeField]
    private TMP_Text playerPercentage;

    private string totalScore;

    public Player player { get; private set; }

    public void Set(Player player, int totalScore)
    {
        this.player = player;
        this.totalScore = totalScore.ToString();

        SetScoreListingInfo();
    }

    private void SetScoreListingInfo()
    {
        this.playerName.text = this.player.NickName;
        this.playerScore.text = $"{this.player.CustomProperties["Score"]}/{this.totalScore}";
        this.playerPercentage.text = this.player.CustomProperties["ScorePercentage"].ToString();
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);

        if (targetPlayer == this.player)
        {
            
        }
    }
}

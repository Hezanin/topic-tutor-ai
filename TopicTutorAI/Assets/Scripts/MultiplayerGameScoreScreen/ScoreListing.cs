using Assets.Scripts.Utilities;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text playerName;

    [SerializeField]
    private TMP_Text playerScore;

    [SerializeField]
    private TMP_Text playerPercentage;

    private string totalScore;

    [SerializeField]
    public RawImage rawImageBackground;

    public Player Player { get; private set; }

    private void SetScoreListingInfo(Player player)
    {
        this.playerName.text = player.NickName;

        if (PhotonNetwork.CurrentRoom.
            CustomProperties.ContainsKey(RoomCustomPropertyKey.TotalScore))
        {
            this.totalScore = PhotonNetwork.CurrentRoom.
                CustomProperties[RoomCustomPropertyKey.TotalScore].ToString();
        }
             
        if(player.CustomProperties.ContainsKey(PlayerCustomPropertyKey.Score))
        {
            this.playerScore.text = $"{player.CustomProperties[PlayerCustomPropertyKey.Score]}/{this.totalScore}";
        }

        CalculatePercentage();
    }

    private void CalculatePercentage()
    {
        double result = 0;
        double playerScore = double.Parse(this.Player.CustomProperties[PlayerCustomPropertyKey.Score].ToString());
        double totalScore = double.Parse(this.totalScore);

        if (totalScore > 0)
        {
            result = (playerScore / totalScore) * 100;
        }

        this.playerPercentage.text = $"{result}%";
    }

    public void Set(Player player)
    {
        this.Player = player;

        SetScoreListingInfo(player);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);

        if (targetPlayer != null && targetPlayer == this.Player)
        {
            SetScoreListingInfo(targetPlayer);
        }
    }
}

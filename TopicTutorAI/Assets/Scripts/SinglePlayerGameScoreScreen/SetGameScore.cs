using Assets.Scripts.Utilities;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;
using PlayFab;
using Unity.VisualScripting;
using PlayFab.ClientModels;
using System;

public class SetGameScore : MonoBehaviour
{
    [SerializeField]
    public QuizCanvases quizCanvases;

    [SerializeField]
    private CustomizeQuizManager customizeQuizManager;

    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private QuizLoader quizLoader;

    [SerializeField]
    private ButtonValidation buttonValidation;

    [SerializeField]
    private GameScore gameScore;

    [SerializeField]
    private GameScorePopUp setGameScorePopUp;

    [SerializeField]
    private ScoreListingMenu scoreListingMenu;

    private void Start()
    {
        this.customizeQuizManager.QuizGeneratedEvent.AddListener(CustomizeQuizManager_QuizGeneratedEvent);
        this.buttonValidation.PlayerAnswerEvent.AddListener(ButtonValidation_PlayerAnswerEvent);
        this.quizLoader.QuizCompletedEvent.AddListener(QuizLoader_QuizCompletedEvent);
    }

    private void ResetPlayerScore()
    {
        this.gameScore.PlayerPoints = 0;
    }

    private void SetTotalGamePointsScore()
    {
        this.gameScore.TotalPoints = this.quiz.Questions.Count;
    }

    private void CustomizeQuizManager_QuizGeneratedEvent()
    {
        SetTotalGamePointsScore();
        ResetPlayerScore();

        if (PhotonNetwork.IsConnected)
        {
            if (!RoomCustomPropertyManager.AddCustomProperty(
                    RoomCustomPropertyKey.TotalScore, this.gameScore.TotalPoints))
            {
                Debug.LogError("Failed to add room custom property");
            }

            if (!PlayerCustomPropertyManager.AddCustomProperty(
                PlayerCustomPropertyKey.Score, this.gameScore.PlayerPoints))
            {
                Debug.LogError("Failed to add custom player property");
            }
        }    
    }

    private void ButtonValidation_PlayerAnswerEvent(bool playerAnswerIsValid)
    {
        if (playerAnswerIsValid) 
        {
            this.gameScore.PlayerPoints += 1;
        }     
    }

    private void QuizLoader_QuizCompletedEvent()
    {
        this.gameScore.SetPercentage();

        SendLeaderboard();

        if (PhotonNetwork.IsConnected)
        {
            if (!PlayerCustomPropertyManager.AddCustomProperty(
                PlayerCustomPropertyKey.Score, this.gameScore.PlayerPoints))
            {
                Debug.LogError("Failed to add custom player property");
            }           

            this.scoreListingMenu.GetCurrentRoomPlayers();
            this.quizCanvases.MultiplayerGameScoreCanvas.Show();
        }
        else
        {
            this.setGameScorePopUp.SetScoreUI(this.gameScore.PlayerPoints,
                this.gameScore.TotalPoints, this.gameScore.PlayerScorePercentage);

            this.quizCanvases.SingleplayerGameScoreCanvas.Show();
        }       
    }

    private void SendLeaderboard()
    {
        UpdatePlayerStatisticsRequest playerStatistic = new()
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "GlobalScore",
                    Value = this.gameScore.PlayerPoints
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(playerStatistic, OnLeaderboardUpdateSuccess, OnLeaderboardUpdateError);
    }

    private void OnLeaderboardUpdateError(PlayFabError error)
    {
        Debug.Log($"ERROR updating leaderboard! - {error.ErrorMessage}");
        
    }

    private void OnLeaderboardUpdateSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfully updated leaderboar!");
    }
}

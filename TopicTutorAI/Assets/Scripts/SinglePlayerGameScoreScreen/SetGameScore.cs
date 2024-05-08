using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameScore : MonoBehaviour
{
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

    private void Start()
    {
        this.customizeQuizManager.QuizGeneratedEvent.AddListener(CustomizeQuizManager_QuizGeneratedEvent);
        this.buttonValidation.PlayerAnswerEvent.AddListener(ButtonValidation_PlayerAnswerEvent);
        this.quizLoader.QuizCompletedEvent.AddListener(QuizLoader_QuizCompletedEvent);
    }

    private void ResetScore()
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
        ResetScore();
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
        this.setGameScorePopUp.SetScoreUI(this.gameScore.PlayerPoints, 
            this.gameScore.TotalPoints, this.gameScore.PlayerScorePercentage);
    }
}

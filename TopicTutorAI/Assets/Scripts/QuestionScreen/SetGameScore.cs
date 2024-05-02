using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameScore : MonoBehaviour
{
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
        this.buttonValidation.PlayerAnswerEvent.AddListener(ButtonValidation_PlayerAnswerEvent);
        this.quizLoader.QuizCompletedEvent.AddListener(QuizLoader_QuizCompletedEvent);
    }

    public void SetTotalGamePointsScore()
    {
        this.gameScore.TotalPoints = this.quiz.Questions.Count;
    }

    private void ButtonValidation_PlayerAnswerEvent(bool playerAnswerIsValid)
    {
        if (playerAnswerIsValid) 
        {
            this.gameScore.EarnedPoints += 1;
            Debug.Log("earned 1 point");
        }     
    }

    private void QuizLoader_QuizCompletedEvent()
    {
        this.gameScore.SetPercentage();

        Debug.Log($"earned points: {this.gameScore.EarnedPoints}, total points:" +
            $" {this.gameScore.TotalPoints}, percentage: {this.gameScore.Percentage}");

        this.setGameScorePopUp.SetScoreUI(this.gameScore.EarnedPoints, 
            this.gameScore.TotalPoints, this.gameScore.Percentage);
    }

    public void ResetScore()
    {
        this.gameScore.EarnedPoints = 0;
    }
}

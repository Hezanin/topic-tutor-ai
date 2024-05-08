using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private CustomizeQuizManager customizeQuizManager;

    [SerializeField]
    public QuizCanvases quizCanvases;

    [SerializeField]
    private QuizLoader quizLoader;

    [SerializeField]
    private QuizCountUp quizCountUp;

    private void Start()
    {
        this.customizeQuizManager.QuizGeneratedEvent.AddListener(CustomizeQuizManager_QuizGeneratedEvent);
        this.quizLoader.QuestionLoadedEvent.AddListener(QuizLoader_QuestionLoadedEvent);
        this.quizLoader.QuizCompletedEvent.AddListener(QuizLoader_QuizCompletedEvent);
    }

    private void CustomizeQuizManager_QuizGeneratedEvent()
    {
        this.quizCountUp.ResetCount();
        this.quizLoader.LoadQuestion();
        this.quizCanvases.QuizCanvas.Show();
    }

    private void QuizLoader_QuestionLoadedEvent()
    {
        this.quizCountUp.SetCount();
    }

    private void QuizLoader_QuizCompletedEvent()
    {
        this.quiz.Questions.Clear();
        this.quizCanvases.QuizCanvas.Hide();
        this.quizCanvases.CustomizeQuizCanvas.Show();
        this.quizCanvases.SingleplayerGameScoreCanvas.Show();
    }
}

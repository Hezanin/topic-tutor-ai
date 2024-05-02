using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    public QuizCanvases quizCanvases;

    [SerializeField]
    private QuizLoader quizLoader;

    [SerializeField]
    private QuizCountUp quizCountUp;

    private void Start()
    {
        this.quizLoader.QuestionLoadedEvent.AddListener(QuizLoader_QuestionLoadedEvent);
        this.quizLoader.QuizCompletedEvent.AddListener(QuizLoader_QuizCompletedEvent);
    }

    private void QuizLoader_QuestionLoadedEvent()
    {
        this.quizCountUp.SetCount();
    }

    private void QuizLoader_QuizCompletedEvent()
    {
        this.quizCountUp.ResetCount();

        this.quizCanvases.QuizCanvas.Hide();
        this.quizCanvases.CustomizeQuizCanvas.Show();
        this.quizCanvases.SingleplayerGameScoreCanvas.Show();
    }
}

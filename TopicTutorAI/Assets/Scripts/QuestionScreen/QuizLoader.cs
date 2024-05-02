using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class QuizCompletedEvent : UnityEvent { }

[System.Serializable]
public class QuizLoadedEvent : UnityEvent { }

public class QuizLoader : MonoBehaviour
{
    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private TMP_Text questionText;

    [SerializeField]
    private TMP_Text optionA;

    [SerializeField]
    private TMP_Text optionB;

    [SerializeField]
    private TMP_Text optionC;

    [SerializeField]
    private TMP_Text optionD;

    public QuizCompletedEvent QuizCompletedEvent;

    public QuizLoadedEvent QuestionLoadedEvent;

    [SerializeField]
    public QuizCanvases quizCanvases;

    private void OnQuizCompleted()
    {
        this.QuizCompletedEvent?.Invoke();
    }

    private void OnQuestionLoaded()
    {
        this.QuestionLoadedEvent?.Invoke();
    }

    public void LoadQuestion()
    {
        if (this.quiz.Questions.Count == 0)
        {
            OnQuizCompleted();
        }
        else
        {
            OnQuestionLoaded();

            Question question = this.quiz.Questions.ElementAt(0);

            this.questionText.text = question.Text;
            this.optionA.text = question.OptionA;
            this.optionB.text = question.OptionB;
            this.optionC.text = question.OptionC;
            this.optionD.text = question.OptionD;
        }       
    }

    public void DecreaseQuestionCount()
    {
        this.quiz.Questions.RemoveAt(0);
    }
}

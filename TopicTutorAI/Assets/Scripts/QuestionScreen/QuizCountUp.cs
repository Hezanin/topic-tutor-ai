using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionCountUp : MonoBehaviour
{
    private Quiz quiz;

    [SerializeField]
    private TMP_Text questionCountText;

    private int totalQuestionsCount;

    private int currentQuestionCount = 1;

    public void InitializeQuiz(Quiz quiz)
    {
        this.quiz = quiz;
    }

    public void DisplayCount()
    {      
        questionCountText.text = $"{currentQuestionCount} out of {totalQuestionsCount}";

        currentQuestionCount++;      
    }

    public void GetQuestionsCount()
    {
        totalQuestionsCount = quiz.Questions.Count;
    }

    public void ResetCount()
    {
        currentQuestionCount = 1;
    }
}

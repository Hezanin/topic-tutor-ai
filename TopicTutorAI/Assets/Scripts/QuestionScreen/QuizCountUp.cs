using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizCountUp : MonoBehaviour
{
    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private TMP_Text questionCountText;

    private int currentQuestionCount = 0;

    private int totalQuestioncount;

    private bool isTotalQuestionCountSet = false;

    public void SetCount()
    {      
        if (!isTotalQuestionCountSet)
        {
            this.totalQuestioncount = this.quiz.Questions.Count;
            isTotalQuestionCountSet = true;
        }

        this.questionCountText.text = $"{this.currentQuestionCount} out of {this.totalQuestioncount}";

        Debug.Log($" current count: {this.currentQuestionCount}, was incremented by 1");
    }

    public void IncreaseCountByOne()
    {
        this.currentQuestionCount++;
    }

    public void ResetCount()
    {
        this.currentQuestionCount = 0;
        this.isTotalQuestionCountSet = false;
        Debug.Log($"count was reset to {this.currentQuestionCount}");
    }
}

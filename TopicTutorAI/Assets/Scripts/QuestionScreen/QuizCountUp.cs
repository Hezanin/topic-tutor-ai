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

    private int currentQuestionCount = 1;

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
        Debug.Log($" current count: {this.currentQuestionCount}");
    }

    public void IncreaseCountByOne()
    {
        this.currentQuestionCount++;
        Debug.Log($" increased current count ({this.currentQuestionCount}) by 1");
    }

    public void ResetCount()
    {
        this.currentQuestionCount = 1;
        this.isTotalQuestionCountSet = false;
        Debug.Log($"count was reset to {this.currentQuestionCount}");
    }
}

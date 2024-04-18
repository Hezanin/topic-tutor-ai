using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionCountUp : MonoBehaviour
{
    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private TMP_Text questionCountText;

    private int totalQuestionsCount;

    private int currentQuestionCount;

    // Start is called before the first frame update
    void Start()
    {
        currentQuestionCount = 1;
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

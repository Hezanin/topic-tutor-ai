using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LoadQuestion : MonoBehaviour
{
    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private TMP_Text questionText;

    [SerializeField]
    private TMP_Text quizCountStatus;

    [SerializeField]
    private TMP_Text optionA;

    [SerializeField]
    private TMP_Text optionB;

    [SerializeField]
    private TMP_Text optionC;

    [SerializeField]
    private TMP_Text optionD;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        if (quiz.Questions.Count == 0)
        {

        }

        Question question = quiz.Questions.ElementAt(0);

        questionText.text = question.Text;
        optionA.text = question.OptionA;
        optionB.text = question.OptionB;
        optionC.text = question.OptionC;
        optionD.text = question.OptionD;

        quiz.Questions.RemoveAt(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class QuizCompletedEventHandler : UnityEvent { }

[System.Serializable]
public class QuestionLoadedEventHandler : UnityEvent { }

public class QuizManager : MonoBehaviour
{
    public QuizCompletedEventHandler QuizCompletedEvent;

    public QuestionLoadedEventHandler QuestionLoadedEvent;

    [SerializeField]
    public QuizCanvases quizCanvases;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadQuestion()
    {
        OnQuestionLoaded();

        if (quiz.Questions.Count == 0)
        {
            quizCanvases.CustomizeQuizCanvas.Show();
            quizCanvases.QuizCanvas.Hide();

            OnQuizCompleted();
        }
        else
        {
            Question question = quiz.Questions.ElementAt(0);

            questionText.text = question.Text;
            optionA.text = question.OptionA;
            optionB.text = question.OptionB;
            optionC.text = question.OptionC;
            optionD.text = question.OptionD;
        }       
    }

    public void DecreaseQuestionCount()
    {
        quiz.Questions.RemoveAt(0);
    }

    private void OnQuizCompleted()
    {
        QuizCompletedEvent?.Invoke();   
    }

    private void OnQuestionLoaded()
    {
        QuestionLoadedEvent?.Invoke();
    }
}

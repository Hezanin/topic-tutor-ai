using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizCanvases : MonoBehaviour
{
    [SerializeField]
    private CustomizeQuizCanvas customizeQuizCanvas;

    [SerializeField]
    private QuizCanvas quizCanvas;

    public CustomizeQuizCanvas CustomizeQuizCanvas { get { return customizeQuizCanvas; } }
    public QuizCanvas QuizCanvas { get { return quizCanvas; } }
}

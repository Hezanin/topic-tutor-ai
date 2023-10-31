using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class QuizzProperties : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField topic;

    [SerializeField]
    private TMP_Dropdown difficulty;

    [SerializeField]
    private TMP_Dropdown numberOfQuestions;

    public string Prompt { get; private set; }

    public void CreatePrompt()
    {
        if (string.IsNullOrEmpty(topic.text))
        {
            topic.text = "OpenAI";
        }

        this.Prompt = $"Generate only {this.numberOfQuestions.captionText.text} " +
            $"numerated unique questions related to the topic of {this.topic.text} " +
            $"with a {this.difficulty.captionText.text} level of difficulty. " +
            $"Each question should have four answers, rated alphabetically, and include" +
            $" the following prefixes: 'Question 1:', 'Option A:', 'Option B:', 'Option C:', 'Option D:', 'Answer: '";
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}

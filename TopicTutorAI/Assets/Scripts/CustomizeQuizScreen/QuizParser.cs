using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuizParser : MonoBehaviour
{
    [SerializeField]
    private OpenAIChatCompletion openAIChatCompletion;
    private MatchCollection matchCollection;

    public List<Question> Parse()
    {
        InitMatchCollection();

        return ParseOpenAiChatCompletition();
    }

    private void InitMatchCollection()
    {
        string pattern = @"Question (\d+): (.+)[\r\n]+Option A: (.+)[\r\n]+Option B: (.+)[\r\n]+Option C: (.+)[\r\n]+Option D: (.+)[\r\n]+Answer: (.+)";
        Regex regex = new Regex(pattern);
        matchCollection = regex.Matches(openAIChatCompletion.Response);
    }

    private List<Question> ParseOpenAiChatCompletition()
    {
        List<Question> quiz = new();

        foreach (Match match in matchCollection)
        {
            int questionNumber = int.Parse(match.Groups[1].Value);
            string questionText = match.Groups[2].Value;
            string optionA = match.Groups[3].Value;
            string optionB = match.Groups[4].Value;
            string optionC = match.Groups[5].Value;
            string optionD = match.Groups[6].Value;
            string answer = match.Groups[7].Value;

            Question question = new Question
            {
                Number = questionNumber,
                Text = questionText,
                OptionA = optionA,
                OptionB = optionB,
                OptionC = optionC,
                OptionD = optionD,
                Answer = answer
            };

            quiz.Add(question);          
        }

        //foreach (var question in quiz)
        //{
        //    Debug.Log(question.Text);
        //    Debug.Log(question.OptionA);
        //    Debug.Log(question.OptionB);
        //    Debug.Log(question.OptionC);
        //    Debug.Log(question.OptionD);
        //    Debug.Log($"ANSWER: {question.Answer}");
        //}

        return quiz;
    }
}

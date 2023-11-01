using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ModelResponseParser : MonoBehaviour
{
    [SerializeField]
    private Quiz Quiz;

    private MatchCollection matchCollection;

    [SerializeField]
    public void InitMatchCollection(string openAIChatCompletionResponse)
    {
        string pattern = @"Question (\d+): (.+)[\r\n]+Option A: (.+)[\r\n]+Option B: (.+)[\r\n]+Option C: (.+)[\r\n]+Option D: (.+)[\r\n]+Answer: (.+)";
        Regex regex = new Regex(pattern);

        Debug.Log($"{openAIChatCompletionResponse}");
        matchCollection = regex.Matches(openAIChatCompletionResponse);
    }

    public void Parse()
    {
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

            Quiz.Questions.Add(question);
        }

        foreach (Question q in Quiz.Questions)
        {
            Debug.Log($"Question {q.Number}: {q.Text}");
            Debug.Log($"Option A: {q.OptionA}");
            Debug.Log($"Option B: {q.OptionB}");
            Debug.Log($"Option C: {q.OptionC}");
            Debug.Log($"Option D: {q.OptionD}");
            Debug.Log($"Answer: {q.Answer}");
            Debug.Log("NEXT!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

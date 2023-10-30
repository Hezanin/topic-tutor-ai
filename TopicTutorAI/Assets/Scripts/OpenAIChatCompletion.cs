using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using System.Linq;
using Utilities.WebRequestRest;
using UnityEngine.Events;
using TMPro;
using System;
using System.Threading.Tasks;

[System.Serializable]
public class OnOpenAIChatResponseEvent : UnityEvent<string> { }

public class OpenAIChatCompletion : MonoBehaviour
{
    public OnOpenAIChatResponseEvent OnOpenAIChatResponse;
    public TMP_InputField InputMessage;

    private OpenAIClient api;
    private List<Message> messages = new List<Message>();

    public async void PromptGPT3_5Model()
    {
        if (string.IsNullOrEmpty(InputMessage.text))
        {
            Debug.LogError("Input message is null or empty");
            return;
        }

        Message userMessage = new Message(Role.System, InputMessage.text);
        messages.Add(userMessage);

        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);

        OnOpenAIChatResponse?.Invoke(result);
    }

    void Start()
    {
        api = new OpenAIClient(OpenAIAuthentication.Default.LoadFromEnvironment());
    }

    void Update()
    {
        
    }
}

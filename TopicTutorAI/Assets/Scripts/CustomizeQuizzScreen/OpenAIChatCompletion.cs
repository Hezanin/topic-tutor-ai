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
    [SerializeField]
    private Prompt prompt;
    private OpenAIClient api;
    private List<Message> messages = new List<Message>();

    public OnOpenAIChatResponseEvent OnOpenAIChatResponse;
    public string Response { get; private set; }

    public async void PromptGPT3_5Model()
    {
        Message userMessage = new Message(Role.System, prompt.Message);
        this.messages.Add(userMessage);

        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        Response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);

        OnOpenAIChatResponse?.Invoke(Response);
    }

    void Start()
    {
        api = new OpenAIClient(OpenAIAuthentication.Default.LoadFromEnvironment());
    }

    void Update()
    {
        
    }
}

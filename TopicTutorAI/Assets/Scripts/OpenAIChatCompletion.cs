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

public class OpenAIChatCompletion : MonoBehaviour
{
    public OnResponseEvent OnResponse;

    [System.Serializable]
    public class OnResponseEvent : UnityEvent<string> { }

    public TextMeshProUGUI InputMessage;

    private OpenAIClient api;

    private List<Message> messages = new List<Message>();

    public async void PromptGPT3_5Model()
    {
        Message userMessage = new Message(Role.System, InputMessage.text);
        messages.Add(userMessage);

        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);

        OnResponse?.Invoke(result);
    }

    void Start()
    {
        api = new OpenAIClient(OpenAIAuthentication.Default.LoadFromEnvironment());
    }

    void Update()
    {
        
    }
}

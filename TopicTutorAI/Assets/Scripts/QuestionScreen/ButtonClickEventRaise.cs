using OpenAI;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class ButtonClickEventHandler : UnityEvent
{
}

public class ButtonClickEventArgs : EventArgs
{
    public Button Button { get; set; }
}

public class ButtonClickEventRaise : MonoBehaviour
{
    [SerializeField]
    private ButtonClickEventHandler clickEvent;

    public event EventHandler<ButtonClickEventArgs> ClickEventArgs;

    [SerializeField]
    private List<Button> buttonList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in buttonList)
        {
            ButtonClickEventArgs eventArgs = new ButtonClickEventArgs();
            eventArgs.Button = button;

            button.onClick.AddListener(OnButtonClick);
            button.onClick.AddListener(() => OnButtonClickSendButton(eventArgs));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnButtonClick()
    {
        clickEvent?.Invoke();
    }

    private void OnButtonClickSendButton(ButtonClickEventArgs args)
    {
        EventHandler<ButtonClickEventArgs> handler = ClickEventArgs;

        if (handler != null)
        {
            handler(this, args);
        }
    }
}

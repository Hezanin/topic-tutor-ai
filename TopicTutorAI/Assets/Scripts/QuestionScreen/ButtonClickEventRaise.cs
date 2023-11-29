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

public class ButtonClickEventRaise : MonoBehaviour
{
    [SerializeField]
    private ButtonClickEventHandler clickEvent;

    [SerializeField]
    private List<Button> buttonList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in buttonList)
        {
            button.onClick.AddListener(OnButtonClick);
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

}

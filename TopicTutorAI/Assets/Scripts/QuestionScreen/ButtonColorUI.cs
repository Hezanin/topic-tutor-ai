using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorUI : MonoBehaviour
{
    [SerializeField]
    private Color invalidColor;

    [SerializeField]
    private Color validColor;

    [SerializeField]
    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInvalidColor(UnityEngine.UI.Button button)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = invalidColor;
        colorBlock.highlightedColor = invalidColor;
        colorBlock.pressedColor= invalidColor;
        colorBlock.disabledColor = invalidColor;
        colorBlock.selectedColor = invalidColor;

        button.colors = colorBlock;
    }

    public void SetDefaultColor(UnityEngine.UI.Button button)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = defaultColor;
        colorBlock.highlightedColor = defaultColor;
        colorBlock.pressedColor = defaultColor;
        colorBlock.disabledColor= defaultColor;
        colorBlock.selectedColor= defaultColor;

        button.colors = colorBlock;
    }

    public void SetValidColor(UnityEngine.UI.Button button)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = validColor;
        colorBlock.highlightedColor = validColor;
        colorBlock.pressedColor = validColor;
        colorBlock.disabledColor = validColor;
        colorBlock.selectedColor = validColor;

        button.colors = colorBlock;
    }
}

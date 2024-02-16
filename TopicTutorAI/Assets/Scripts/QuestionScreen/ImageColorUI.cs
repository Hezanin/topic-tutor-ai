using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorUI : MonoBehaviour
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

    public void SetInvalidColor(Image image)
    {
        image.color = invalidColor;
    }

    public void SetDefaultColor(Image image)
    {
        image.color = defaultColor;
    }

    public void SetValidColor(Image image)
    {
        image.color = validColor;
    }
}

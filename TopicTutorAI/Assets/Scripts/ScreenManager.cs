using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ToEnable;

    [SerializeField]
    private GameObject ToDisable;
   
    public void UpdateStatus()
    {
        ToDisable.GetComponent<Canvas>().enabled = false;
        ToEnable.GetComponent<Canvas>().enabled = true;
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

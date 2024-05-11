using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvases : MonoBehaviour
{
    [SerializeField]
    private LoginAccountCanvas loginAccountCanvas;

    [SerializeField]
    private RegisterAccountCanvas registerAccountCanvas;

    public LoginAccountCanvas LoginAccount {  get { return loginAccountCanvas; } }
    public RegisterAccountCanvas RegisterAccount { get { return registerAccountCanvas; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}

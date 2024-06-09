using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvases : MonoBehaviour
{
    [SerializeField]
    private LoginAccountCanvas loginAccountCanvas;

    [SerializeField]
    private RegisterAccountCanvas registerAccountCanvas;

    [SerializeField]
    private ErrorHandlingCanvas errorHandlingCanvas;

    [SerializeField]
    AccountRecoveryCanvas accountRecoveryCanvas;

    public LoginAccountCanvas LoginAccountCanvas {  get { return loginAccountCanvas; } }
    public RegisterAccountCanvas RegisterAccountCanvas { get { return registerAccountCanvas; } }
    public ErrorHandlingCanvas ErrorHandlingCanvas { get {  return errorHandlingCanvas; } }
    public AccountRecoveryCanvas AccountRecoveryCanvas { get { return accountRecoveryCanvas;} }

}

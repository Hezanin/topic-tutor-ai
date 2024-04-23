using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizCanvases : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private CustomizeQuizCanvas customizeQuizCanvas;
    [SerializeField]
    private QuizCanvas quizCanvas;
    [SerializeField]
    private MultiplayerLoadingCanvas multiplayerLoadingCanvas;

    public CustomizeQuizCanvas CustomizeQuizCanvas { get { return customizeQuizCanvas; } }
    public QuizCanvas QuizCanvas { get { return quizCanvas; } }
    public MultiplayerLoadingCanvas MultiplayerLoadingCanvas { get { return multiplayerLoadingCanvas; } }

    private void Start()
    {
        if(PhotonNetwork.IsConnected)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                this.MultiplayerLoadingCanvas.Show();
            }
        }
    }
}

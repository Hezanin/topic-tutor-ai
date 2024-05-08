using ExitGames.Client.Photon;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;

[System.Serializable]
public class QuizGeneratedEvent : UnityEvent { }

public class CustomizeQuizManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private QuizCanvases quizCanvases;

    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private QuizParser parser;

    private QuizCustomSerialization quizCustomSerialization;

    public QuizGeneratedEvent QuizGeneratedEvent;

    private void Start()
    {
        this.quizCustomSerialization = new QuizCustomSerialization();

        PhotonPeer.RegisterType(typeof(QuizCustomSerialization), (byte)'M',
            QuizCustomSerialization.SerializeQuestions, QuizCustomSerialization.DeserializeQuestions);
    }

    private void OnQuizGenerated()
    {
        this.QuizGeneratedEvent?.Invoke();
    }

    public void CreateQuiz()
    {
        if(PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                this.quiz.Questions = this.parser.Parse();

                this.quizCustomSerialization.Questions = this.quiz.Questions;

                SendQuizToClients();
            }            
        }
        else
        {
            this.quiz.Questions = this.parser.Parse();
        }

        this.quizCanvases.CustomizeQuizCanvas.Hide();
        OnQuizGenerated();
    }

    private void SendQuizToClients()
    {
        base.photonView.RPC("RPC_ReceiveQuizFromMaster",RpcTarget.AllViaServer,
            QuizCustomSerialization.SerializeQuestions(this.quizCustomSerialization));
    }

    [PunRPC]
    private void RPC_ReceiveQuizFromMaster(byte[] data)
    {        
        if(!PhotonNetwork.IsMasterClient)
        {
            this.quizCustomSerialization = (QuizCustomSerialization)QuizCustomSerialization.DeserializeQuestions(data);
            this.quiz.Questions = this.quizCustomSerialization.Questions;

            this.quizCanvases.CustomizeQuizCanvas.Hide();
            this.quizCanvases.MultiplayerLoadingCanvas.Hide();
            OnQuizGenerated();          
        }       
    }
}

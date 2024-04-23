using ExitGames.Client.Photon;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;

public class CustomizeQuizManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private QuizManager quizManager;

    [SerializeField]
    private QuestionCountUp questionCountUp;

    [SerializeField]
    private Quiz quiz;

    [SerializeField]
    private QuizParser parser;

    [SerializeField]
    private QuizCanvases quizCanvases;

    private QuizCustomSerialization quizCustomSerialization;

    private void Start()
    {
        this.quizCustomSerialization = new QuizCustomSerialization();

        PhotonPeer.RegisterType(typeof(QuizCustomSerialization), (byte)'M',
            QuizCustomSerialization.SerializeQuestions, QuizCustomSerialization.DeserializeQuestions);
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

        UpdateCanvases();
        InitializeQuiz();

        this.questionCountUp.GetQuestionsCount();
        this.quizManager.LoadQuestion();
    }

    private void SendQuizToClients()
    {
        base.photonView.RPC("RPC_ReceiveQuizFromMaster",
            RpcTarget.AllViaServer,
            QuizCustomSerialization.SerializeQuestions(this.quizCustomSerialization));
    }

    [PunRPC]
    private void RPC_ReceiveQuizFromMaster(byte[] data)
    {        
        if(!PhotonNetwork.IsMasterClient)
        {
            this.quizCustomSerialization = (QuizCustomSerialization)QuizCustomSerialization.DeserializeQuestions(data);
            this.quiz.Questions = this.quizCustomSerialization.Questions;

            UpdateCanvases();
            InitializeQuiz();

            this.questionCountUp.GetQuestionsCount();
            this.quizManager.LoadQuestion();
        }       
    }

    private void UpdateCanvases()
    {
        this.quizCanvases.MultiplayerLoadingCanvas.Hide();
        this.quizCanvases.CustomizeQuizCanvas.Hide();
        this.quizCanvases.QuizCanvas.Show();
    }

    private void InitializeQuiz()
    {
        this.questionCountUp.InitializeQuiz(this.quiz);
        this.quizManager.InitializeQuiz(this.quiz);
    }
}

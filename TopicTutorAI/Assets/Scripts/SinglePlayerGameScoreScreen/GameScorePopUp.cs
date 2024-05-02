using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScorePopUp : MonoBehaviour
{
    [SerializeField]
    private TMP_Text score;

    [SerializeField]
    private TMP_Text scoreDetailed; 

    public void SetScoreUI(int earnedPoints, int totalPoints, int percentage)
    {
        this.score.text = $"{percentage}% Score!";
        this.scoreDetailed.text = $"You answered {earnedPoints} out of " +
            $"{totalPoints} questions correctly";
    }
}

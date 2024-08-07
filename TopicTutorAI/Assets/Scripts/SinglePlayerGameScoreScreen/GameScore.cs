using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    private int playerPoints;
    private int totalPoints;

    public int TotalPoints
    {
        get { return totalPoints; }
        set
        {
            if (value >= 0)
            {
                totalPoints = value;
            }
            else
            {
                totalPoints = 0;
            }
        }
    }
    public int PlayerPoints
    {
        get { return playerPoints; }
        set
        {
            if(value >= 0)
            {
                playerPoints = value;
            }
            else
            {
                playerPoints = 0;
            }
        }
    }

    public int PlayerScorePercentage { get; private set; }

    public void SetPercentage()
    {
        double result = ((double)this.playerPoints / (double)this.totalPoints) * 100;
        this.PlayerScorePercentage = (int)result;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    private int earnedPoints;
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

    public int EarnedPoints
    {
        get { return earnedPoints; }
        set
        {
            if(value >= 0)
            {
                earnedPoints = value;
            }
            else
            {
                earnedPoints = 0;
            }
        }
    }

    public int Percentage { get; private set; }

    public void SetPercentage()
    {
        double result = ((double)this.earnedPoints / (double)this.totalPoints) * 100;

        Debug.Log($"resulting percentage: {this.earnedPoints} / {this.totalPoints} = {result}");
        this.Percentage = (int)result;
    }
}

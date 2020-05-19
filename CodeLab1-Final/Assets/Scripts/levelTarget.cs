using System.Collections;
using System.Collections.Generic;

public class levelTarget 
{
    public string targetScore; //var for the target score of the level
    public int scoreToBeat = 1; //var for a score to beat in order to pass the level

   


    //Constructor that takes only a string and an int
    public levelTarget(string targetScore, int n)
    {
        this.targetScore = targetScore;
        scoreToBeat = n;
    }

    
}

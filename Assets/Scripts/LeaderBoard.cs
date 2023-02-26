using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScoreObject
{
    public string name;
    public int score;
}

public class Leaderboard 
{
    public List<ScoreObject> scoresList = new List<ScoreObject>();


    public void addScore(string name, int score)
    {
        ScoreObject obj = new ScoreObject();
        obj.name = name;
        obj.score = score;

        scoresList.Add(obj);
    }
}

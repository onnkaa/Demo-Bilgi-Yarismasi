using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{

    public string questionName;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;

    public int answer;

    public Question(string question, string answer1, string answer2, string answer3, string answer4, int aw)
    {
        questionName = question;
        answerA = answer1;
        answerB = answer2;
        answerC = answer3;
        answerD = answer4;
        answer = aw;
    }
    
}

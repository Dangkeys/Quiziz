using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,8)]
    [SerializeField] string question = "Enter your new question";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string GetQuestion(){return question;}
    public int GetCorrectAnswerIndex(){return correctAnswerIndex;}
    public string GetAnswer(int index){return answers[index];}
}

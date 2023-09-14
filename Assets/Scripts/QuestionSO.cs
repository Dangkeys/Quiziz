using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,8)]
    [SerializeField] string question = "Enter your new question";
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System;
// using Microsoft.Unity.VisualStudio.Editor;
public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;
    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        DisplayQuestion();
    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        } else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }
    void DisplayAnswer(int index)
    {
        if (index == question.GetCorrectAnserIndex())
            questionText.text = "Awwwww >////<";
        else
            questionText.text = "Wrong, you need to say " + question.GetAnswer(question.GetCorrectAnserIndex());
        answerButtons[question.GetCorrectAnserIndex()].GetComponent<Image>().sprite = correctAnswerSprite;
    }
    private void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i);
    }
    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
            answerButtons[i].GetComponent<Button>().interactable = state;
    }
    private void GetNextQuestion()
    {
        SetButtonState(true);
        DisplayQuestion();
        SetDefaultButtonSprites();
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
    }
}

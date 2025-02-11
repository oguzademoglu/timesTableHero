using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Challange : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI correctCountText;
    [SerializeField] public TextMeshProUGUI wrongCountText;
    [SerializeField] public TextMeshProUGUI questionText;
    [SerializeField] public Transform answerButtonContainer;
    [SerializeField] public GameObject buttonPrefab;
    int correctCount = 0;
    int wrongCount = 0;
    [SerializeField] private TimesTableUI timesTableUI;
    private int number;
    private int correctAnswer;
    private bool newQuestionNeeded = true;


    void Awake()
    {
        timesTableUI = FindAnyObjectByType<TimesTableUI>();
    }
    void Start()
    {
        GenerateQuestion();
    }

    void GenerateQuestion()
    {
        foreach (Transform child in answerButtonContainer)
        {
            Destroy(child.gameObject);
        }
        number = timesTableUI.serializeNumber;
        int questionNumber = Random.Range(2, 16);
        correctAnswer = number * questionNumber;
        questionText.text = $"{number} x {questionNumber} = ?";
        GenerateAnswerButtons();
    }

    void GenerateAnswerButtons()
    {
        List<int> options = new List<int> { correctAnswer };
        while (options.Count < 4)
        {
            int wrongAnswer = Random.Range(correctAnswer - 10, correctAnswer + 10);
            if (!options.Contains(wrongAnswer) && wrongAnswer != 0)
            {
                options.Add(wrongAnswer);
            }
        }
        ShuffleList(options);
        foreach (int option in options)
        {
            GameObject newButton = Instantiate(buttonPrefab, answerButtonContainer);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = option.ToString();
            int selectedAnswer = option;
            newButton.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(selectedAnswer));
        }
    }

    void ShuffleList(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }

    void CheckAnswer(int userAnswer)
    {
        if (userAnswer == correctAnswer)
        {
            UpdateScores(1);
        }
        else
        {
            UpdateScores(-1);
        }
        newQuestionNeeded = true;
        GenerateQuestion();
    }

    void UpdateScores(int value)
    {
        if (value > 0)
        {
            correctCount += value;
            correctCountText.text = correctCount.ToString();
        }
        else
        {
            wrongCount += value;
            wrongCountText.text = (-wrongCount).ToString();
        }

    }

    void Update()
    {
        if (timesTableUI.isSelected && newQuestionNeeded)
        {
            newQuestionNeeded = false;
            GenerateQuestion();
        }
    }

}

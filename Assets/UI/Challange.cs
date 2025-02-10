using TMPro;
using UnityEngine;

public class Challange : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI correctCountText;
    [SerializeField] public TextMeshProUGUI wrongCountText;
    [SerializeField] public TextMeshProUGUI questionText;
    int correctCount = 0;
    int wrongCount = 0;
    [SerializeField] private TimesTableUI timesTableUI;
    private int number;
    private int correctAnswer;


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
        number = timesTableUI.serializeNumber;
        Debug.Log(number);
        int questionNumber = Random.Range(2, 12);
        int result = number * questionNumber;
        questionText.text = $"{number} x {questionNumber} = {result}";
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
            wrongCountText.text = wrongCount.ToString();
        }

    }

}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimesTableUI : MonoBehaviour
{
    [SerializeField] public GameObject buttonPrefab;
    [SerializeField] public Transform buttonContainer;
    [SerializeField] public TextMeshProUGUI tableText;
    public int serializeNumber = 1;
    public bool isSelected = false;



    void Start()
    {
        CreateNumberButtons();
        ShowMultiplicationTable(1);
    }

    void CreateNumberButtons()
    {
        for (int i = 1; i < 11; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            int number = i;
            newButton.GetComponent<Button>().onClick.AddListener(() => ShowMultiplicationTable(number));
        }
    }

    void ShowMultiplicationTable(int number)
    {
        string table = $"Tablo: {number}\n";
        for (int i = 1; i < 11; i++)
        {
            table += $"{number} x {i} = {number * i}\n";
        }
        tableText.text = table;
        serializeNumber = number;
    }

    public void StartChallenge()
    {
        isSelected = true;
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    TimesTableUI timesTableUI;
    Challange challange;

    void Awake()
    {
        timesTableUI = FindAnyObjectByType<TimesTableUI>();
        challange = FindAnyObjectByType<Challange>();
    }
    void Start()
    {
        timesTableUI.gameObject.SetActive(true);
        challange.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timesTableUI.isSelected)
        {
            timesTableUI.gameObject.SetActive(false);
            challange.gameObject.SetActive(true);
        }
    }
}

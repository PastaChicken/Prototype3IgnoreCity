using UnityEngine;
using TMPro;

public class TimerScore : MonoBehaviour
{

    float currentTime = 0f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning) {
            currentTime += Time.deltaTime;
            DisplayTime(currentTime);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // To ensure the display shows 0:00 when time runs out

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

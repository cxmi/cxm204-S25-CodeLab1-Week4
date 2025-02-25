using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;

    public int gameTime = 10;

    public int currentTime = 0;

    
    public const string TimerTick = "UpdateTimer";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerDisplay.text = TimerString(gameTime);
        Invoke(TimerTick, 1); // always does this in seconds, no need for time delta time
    }

    public void UpdateTimer()
    {
        currentTime++;
        if (currentTime == gameTime)
        {
            GameManager.instance.UpdateHighScores();
            timerDisplay.text = "Game Over!";
        }
        else
        {
            timerDisplay.text = TimerString(gameTime-currentTime);
            Invoke(TimerTick, 1);
        }
    }

    string TimerString(int timeInt)
    {
        string result = "";
        result = "Time: " + timeInt + " Score: " + GameManager.instance.Score;
        return result;
    }
}

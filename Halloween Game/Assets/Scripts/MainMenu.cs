using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text TopScore;

    DataContainer data;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("GameContainer").GetComponent<DataContainer>();
        float TopScoreTime = PlayerPrefs.GetFloat("TopScore");
        TopScore.text = "Best time: " + CalculateTime(TopScoreTime);
        Time.timeScale = 1;
    }

    public void Play()
    {
        Application.LoadLevel("SelectScreen");
    }

    public void Customize()
    {
        Application.LoadLevel("Customizer");
    }

    public void Exit()
    {
        Application.Quit();
    }

    string CalculateTime(float i)
    {
        float seconds = Mathf.Floor(i);
        float minutes = Mathf.Floor(seconds / 60);
        float hours = Mathf.Floor(minutes / 60);
        minutes -= 60 * hours;
        seconds -= 60 * minutes;
        return hours + "h " + minutes + "m " + seconds + "s";
    }
}
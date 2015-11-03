using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float SecondsSurvived = 0;

    public Text TimeSurvived;
    SpawnManager spawnManager;

    void Update()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        SecondsSurvived += 1 * Time.deltaTime;
        TimeSurvived.text = "Time Survived: " + CalculateTime();
    }

    public string CalculateTime()
    {
        string output = "";
        float seconds = Mathf.Floor(SecondsSurvived);
        float minutes = Mathf.Floor(seconds / 60);
        float hours = Mathf.Floor(minutes / 60);
        minutes -= 60 * hours;
        seconds -= 60 * minutes;
        return hours + "h " + minutes + "m " + seconds + "s";
    }
}

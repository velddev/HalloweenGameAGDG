using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public static List<GameObject> Players = new List<GameObject>();

    Text[] Names = new Text[4];

    public GameObject BasePlayer;
    public GameObject BaseUI;

    public Text WaveText;

    DataContainer data;
    SpawnManager spawnManager;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("GameContainer").GetComponent<DataContainer>();
        Text[] Names = new Text[data.AmountOfPlayers];
        for (int i = 0; i < data.AmountOfPlayers; i++)
        {
            GameObject c = GameObject.Find("Canvas");
            GameObject ui = (GameObject)Instantiate(BaseUI, new Vector3(-727 + 400 * i, -457, 0), Quaternion.identity);
            Names[i] = ui.GetComponent<Text>();
            GameObject uihp = ui.transform.GetChild(0).gameObject;
            GameObject uist = ui.transform.GetChild(1).gameObject;
            ui.transform.SetParent(c.transform, false);
            GameObject g = (GameObject)Instantiate(BasePlayer, Vector3.zero + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)), Quaternion.identity);
            Players.Add(g);
            g.GetComponent<PlayerMovement>().SetUp(uihp.GetComponent<Slider>(), uist.GetComponent<Slider>());
            g.GetComponent<PlayerMovement>().playerNumber = i;
        }
        data.SetNames(Names);
    }

    void Update()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        data.TimeSurvived += 1 * Time.deltaTime;
        WaveText.text = "Wave: " + spawnManager.WaveNumber;
    }

    public string CalculateTime()
    {
        string output = "";
        float seconds = Mathf.Floor(data.TimeSurvived);
        float minutes = Mathf.Floor(seconds / 60);
        float hours = Mathf.Floor(minutes / 60);
        minutes -= 60 * hours;
        seconds -= 60 * minutes;
        return hours + "h " + minutes + "m " + seconds + "s";
    }
}

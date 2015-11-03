using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataContainer : MonoBehaviour {

    public int AmountOfPlayers;
    public int Difficulty;

    public float Score;
    public float KillsMade;
    public float TimeSurvived;

    public DataProfile[] ProfilesLoaded;

	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}

    public void SetNames(Text[] nameText)
    {
        for(int i = 0; i < nameText.Length; i++)
        {
            nameText[i].text = ProfilesLoaded[i].Name;
        }
    }
}

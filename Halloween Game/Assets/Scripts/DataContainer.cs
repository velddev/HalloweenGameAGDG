using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataContainer : MonoBehaviour {

    public int AmountOfPlayers;
    public int Difficulty;

    public float Score;
    public float KillsMade;
    public float TimeSurvived;

    public int[] SelectedProfiles = new int[4];
    public DataProfile[] ProfilesLoaded = new DataProfile[10];

	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	    for(int i = 0 ; i < ProfilesLoaded.Length; i++)
        {
            ProfilesLoaded[i] = new DataProfile("empty");
            ProfilesLoaded[i].LoadProfile(i);
        }
    }
}

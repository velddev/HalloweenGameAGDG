using UnityEngine;
using System.Collections;

public class GoToSceneAfterDelay : MonoBehaviour {

    public string LevelName;
    public float Delay;
    
	void Update () {
        Delay -= 1 * Time.deltaTime;
	    if(Delay<= 0)
        {
            Application.LoadLevel(LevelName);
        }
	}
}

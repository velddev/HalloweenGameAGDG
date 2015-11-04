using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public void Go(string name)
    {
        Application.LoadLevel(name);
    }
}

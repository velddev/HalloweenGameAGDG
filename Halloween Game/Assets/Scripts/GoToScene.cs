using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour {

    public bool Go;

    void Update()
    {
        if (Go)
        {
            Application.LoadLevel("Menu");
        }
    }
}

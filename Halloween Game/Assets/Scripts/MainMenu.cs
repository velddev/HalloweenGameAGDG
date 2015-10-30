using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        Application.LoadLevel("Game");
    }

    public void Customize()
    {
        Application.LoadLevel("Customize");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
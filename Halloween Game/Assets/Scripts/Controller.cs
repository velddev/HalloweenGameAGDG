using UnityEngine;
using System.Collections;

public class Controller
{

    public int Player;

    public Controller(int _player)
    {
        Player = _player;
    }

    public KeyCode A()
    {
        return (KeyCode)(250 * (20 * Player));
    }

    public KeyCode B()
    {
        return (KeyCode)(251 * (20 * Player));
    }

    public KeyCode Y()
    {
        return (KeyCode)(252 * (20 * Player));
    }

    public KeyCode X()
    {
        return (KeyCode)(253 * (20 * Player));
    }
}

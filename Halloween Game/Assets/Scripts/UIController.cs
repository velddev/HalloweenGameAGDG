using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public Image cursor;

    public Button[] buttons;
    int _currentButton = 0;

    int lastAxis;

    public AudioClip changeselectSFX;
    public AudioClip selectSFX;

    public void Update()
    {
        cursor.transform.position = new Vector2(cursor.transform.position.x, buttons[_currentButton].transform.position.y);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (_currentButton == i)
            {
                Debug.Log("get here bitch.");
                buttons[_currentButton].image.color = buttons[_currentButton].colors.highlightedColor;
            }
            else
            {
                buttons[i].image.color = buttons[_currentButton].colors.normalColor;
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GetComponent<AudioSource>().PlayOneShot(selectSFX, 0.3f);
        }
        if (Input.GetAxisRaw("JoyStick0_DpadVertical") != 0)
        {
            if (Input.GetAxisRaw("JoyStick0_DpadVertical") != lastAxis)
            {
                GetComponent<AudioSource>().PlayOneShot(changeselectSFX, 0.3f);
                _currentButton -= (int)Input.GetAxisRaw("JoyStick0_DpadVertical");
                if (_currentButton < 0)
                {
                    _currentButton = buttons.Length - 1;
                }
                if (_currentButton >= buttons.Length)
                {
                    _currentButton = 0;
                }
            }
        }
        lastAxis = (int)Input.GetAxisRaw("JoyStick0_DpadVertical");
    }
}

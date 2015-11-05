using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public Image cursor;

    public int PlayerNumber;

    public GameObject[] buttons;
    int _currentButton = 0;

    Vector2 lastAxis;

    public GameObject[] Actions;

    public AudioClip changeselectSFX;
    public AudioClip selectSFX;

    public void Update()
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].SetActive(false);
        }
        if (buttons[_currentButton].GetComponent<Button>())
        {
            Actions[0].SetActive(true);
        }
        else if (buttons[_currentButton].GetComponent<Slider>())
        {
            Actions[1].SetActive(true);
        }
        cursor.transform.position = new Vector2(cursor.transform.position.x, buttons[_currentButton].transform.position.y);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (_currentButton == i)
            {
                if (buttons[_currentButton].GetComponent<Button>())
                {
                    buttons[_currentButton].GetComponent<Button>().image.color = buttons[_currentButton].GetComponent<Button>().colors.highlightedColor;
                }
            }
            else
            {
                if (buttons[_currentButton].GetComponent<Button>())
                {
                    buttons[_currentButton].GetComponent<Button>().image.color = buttons[_currentButton].GetComponent<Button>().colors.normalColor;
                }
            }
        }
        if (Input.GetKeyDown(new Event().keyCode = (KeyCode)(350 + (20 * PlayerNumber))))
        {
            if (selectSFX)
            {
                GetComponent<AudioSource>().PlayOneShot(selectSFX, 0.3f);
            }
            if (buttons[_currentButton].GetComponent<Button>())
            {
                PointerEventData pointer = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(buttons[_currentButton].gameObject, pointer, ExecuteEvents.pointerClickHandler);
            }
        }
        if (Input.GetAxisRaw("JoyStick" + PlayerNumber + "_DpadVertical") != 0)
        {
            if (Input.GetAxisRaw("JoyStick " + PlayerNumber + "_DpadVertical") != lastAxis.y)
            {
                GetComponent<AudioSource>().PlayOneShot(changeselectSFX, 0.3f);
                _currentButton -= (int)Input.GetAxisRaw("JoyStick" + PlayerNumber + "_DpadVertical");
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
        if (Input.GetAxisRaw("JoyStick" + PlayerNumber + "_DpadHorizontal") != 0)
        {
            if (Input.GetAxisRaw("JoyStick" + PlayerNumber + "_DpadHorizontal") != lastAxis.x)
            {
                GetComponent<AudioSource>().PlayOneShot(changeselectSFX, 0.3f);
                if (buttons[_currentButton].GetComponent<Slider>())
                {
                    buttons[_currentButton].GetComponent<Slider>().value += Input.GetAxisRaw("JoyStick" + PlayerNumber + "_DpadHorizontal");
                }
            }
        }
        lastAxis.x = (int)Input.GetAxisRaw("JoyStick" + PlayerNumber + "_DpadHorizontal");
        lastAxis.y = (int)Input.GetAxisRaw("JoyStick" + PlayerNumber + "_DpadVertical");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Customiser : MonoBehaviour {
    public GameObject Player;
    public SpriteRenderer[] PlayerBody;
    public WeaponBase[] Weapons;
    public Sprite[] Hats;

    public Slider slider_r;
    public Slider slider_b;
    public Slider slider_g;
    public Slider Hatslider;

    public Color currentColor;
    public int currentHatID;
    public int currentWepID;

    void Start()
    {
        if (PlayerPrefs.HasKey("Hat"))
        {
            currentHatID = PlayerPrefs.GetInt("Hat");
        }
        if (PlayerPrefs.HasKey("ColR"))
        {
            currentColor = new Color(PlayerPrefs.GetFloat("ColR"), PlayerPrefs.GetFloat("ColG"), PlayerPrefs.GetFloat("ColB"));
        }
        slider_r.value = PlayerPrefs.GetFloat("ColR");
        slider_g.value = PlayerPrefs.GetFloat("ColG");
        slider_b.value = PlayerPrefs.GetFloat("ColB");
        Hatslider.value = currentHatID;
        ChangeWeapon(currentWepID);
    }

    public void ChangeWeapon(int id)
    {
        Player.GetComponent<PlayerMovement>().ChangeWeapon(Weapons[id]);
        currentWepID = id;
    }

    public void ChangeColor()
    {
        for(int i = 0; i < PlayerBody.Length;i++)
        {
            PlayerBody[i].GetComponent<SpriteRenderer>().color = new Color(slider_r.value / 10, slider_g.value / 10, slider_b.value / 10);
        }
        currentColor = PlayerBody[0].GetComponent<SpriteRenderer>().color;
    }

    public void ChangeHat()
    {
        Player.GetComponent<SpriteRenderer>().sprite = Hats[(int)Hatslider.value];
        currentHatID = (int)Hatslider.value;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Hat", currentHatID);
        PlayerPrefs.SetFloat("ColR", slider_r.value );
        PlayerPrefs.SetFloat("ColG", slider_g.value);
        PlayerPrefs.SetFloat("ColB", slider_b.value);
        Application.LoadLevel("Menu");
    }
}

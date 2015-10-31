using UnityEngine;
using System.Collections;

public class CustomisationManager : MonoBehaviour
{

    [SerializeField]
    GameObject Head;
    [SerializeField]
    SpriteRenderer[] Bodyparts;
    [SerializeField]
    Sprite[] Hats;
    [SerializeField]
    WeaponBase[] Weapons;

    int PreferredHatID = 0;
    int PreferredWeaponID = 0;
    Color PreferredColor;

    void Start()
    {
        if (PlayerPrefs.HasKey("ColR"))
        {
            PreferredColor = new Color(PlayerPrefs.GetFloat("ColR"), PlayerPrefs.GetFloat("ColG"), PlayerPrefs.GetFloat("ColB"));
        }
        else
        {
            PreferredColor = Color.white;
        }
        for (int i = 0; i < Bodyparts.Length; i++)
        {
            Bodyparts[i].color = PreferredColor;
        }
        if (PlayerPrefs.HasKey("Hat"))
        {
            PreferredHatID = PlayerPrefs.GetInt("Hat");
        }
        else { PreferredHatID = 0; }

        Head.GetComponent<SpriteRenderer>().sprite = Hats[PreferredHatID];

        if (PlayerPrefs.HasKey("Wep"))
        {
            PreferredWeaponID = PlayerPrefs.GetInt("Wep");
        }
        else { PreferredWeaponID = 0; }
        Head.GetComponent<PlayerMovement>().ChangeWeapon(Weapons[PreferredWeaponID]);
        enabled = false;
    }
}

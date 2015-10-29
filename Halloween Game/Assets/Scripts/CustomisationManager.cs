using UnityEngine;
using System.Collections;

public class CustomisationManager : MonoBehaviour
{
    DataContainer data;

    [SerializeField]
    SpriteRenderer Head;
    [SerializeField]
    SpriteRenderer[] Bodyparts;

    [SerializeField]
    Sprite[] Hats;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("GameContainer").GetComponent<DataContainer>();
        for(int i = 0; i < Bodyparts.Length; i++)
        {
            Bodyparts[i].color = data.PreferredBodyColor;
        }
        Head.sprite = Hats[data.PreferredHatID];
        enabled = false;
    }
}

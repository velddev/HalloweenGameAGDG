using UnityEngine;
using System.Collections;

public class CustomisationManager : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer Head;
    [SerializeField]
    SpriteRenderer[] Bodyparts;

    [SerializeField]
    Color PreferredColor;
    [SerializeField]
    int PreferredHat;

    [SerializeField]
    Sprite[] Hats;

    void Start()
    {
        for(int i = 0; i < Bodyparts.Length; i++)
        {
            Bodyparts[i].color = PreferredColor;
        }
        Head.sprite = Hats[PreferredHat];
        enabled = false;
    }
}

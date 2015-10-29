using UnityEngine;
using System.Collections;

public class DataContainer : MonoBehaviour
{
    #region Customisation
    public Color PreferredBodyColor;

    public int PreferredHatID;
    #endregion

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

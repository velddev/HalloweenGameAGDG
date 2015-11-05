using UnityEngine;
public class DataProfile
{
    public string Name;

    public int Level;
    public float Exp, MaxExp;

    public DataProfile(string name)
    {
        Name = name;
        Level = 1;
        Exp = 0;
        MaxExp = 100;
    }

    public void LevelUp()
    {
        Level += 1;
        MaxExp *= 1.33f;
        Exp = 0;
    }

    public void LoadProfile(int id)
    {
        if(PlayerPrefs.HasKey("Profile" + id + "Name"))
        {
            Name = PlayerPrefs.GetString("Profile" + id + "Name");
        }
        if(PlayerPrefs.HasKey("Profile" + id + "Level"))
        {
            Level = PlayerPrefs.GetInt("Profile" + id + "Level");
        }
        if (PlayerPrefs.HasKey("Profile" + id + "Exp"))
        {
            Exp = PlayerPrefs.GetFloat("Profile" + id + "Exp");
        }
        if (PlayerPrefs.HasKey("Profile" + id + "MaxExp"))
        {
            MaxExp = PlayerPrefs.GetFloat("Profile" + id + "MaxExp");
        }
    }

    public void SaveProfile(int id)
    {
        PlayerPrefs.SetString("Profile" + id + "Name", Name);
        PlayerPrefs.SetInt("Profile" + id + "Level", Level);
        PlayerPrefs.SetFloat("Profile" + id + "Exp", Exp);
        PlayerPrefs.SetFloat("Profile" + id + "MaxExp", MaxExp);
    }
}
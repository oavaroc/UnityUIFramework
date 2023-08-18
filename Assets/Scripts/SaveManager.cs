using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoSingleton<SaveManager>
{
    public enum Profile
    {
        Profile1, Profile2, Profile3
    }

    private Dictionary<Profile, string> _profiles;
    private Profile selectedProfile;
    private void Start()
    {
        _profiles = new Dictionary<Profile, string>();
        

    }
    private void SelectProfile(Profile profile)
    {
        selectedProfile = profile;
    }

    public void SaveData()
    {
        PlayerPrefs.SetString(selectedProfile.ToString(),_profiles[selectedProfile]);
    }
    public void LoadData()
    {

    }
}

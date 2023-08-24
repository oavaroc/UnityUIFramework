using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoSingleton<SaveManager>
{
    public enum Profile
    {
        Profile1, Profile2, Profile3
    }

    public enum Game
    {
        MathGame, BubbleGame, MemoryGame
    }

    private Dictionary<Profile, Dictionary<Game, int>> _profiles;
    private Profile selectedProfile;

    private void Start()
    {
        _profiles = new Dictionary<Profile, Dictionary<Game, int>>();
        LoadProfiles();
    }

    private void LoadProfiles()
    {
        // Load profile data from PlayerPrefs
        foreach (Profile profile in (Profile[])System.Enum.GetValues(typeof(Profile)))
        {
            LoadProfileData(profile);
        }
    }

    private void LoadProfileData(Profile profile)
    {
        // Load high scores for each game from PlayerPrefs
        foreach (Game game in (Game[])System.Enum.GetValues(typeof(Game)))
        {
            int highScore = PlayerPrefs.GetInt($"{profile}_{game}_HighScore", 0);
            SetHighScore(profile, game, highScore);
        }
    }

    public void SelectProfile(int profile)
    {
        selectedProfile = (Profile)profile;
    }
    public void SaveHighScore(Game game, int score)
    {

        if (_profiles.ContainsKey(selectedProfile))
        {
            if (_profiles[selectedProfile].ContainsKey(game))
            {
                int currentHighScore = _profiles[selectedProfile][game];

                if (score > currentHighScore)
                {
                    _profiles[selectedProfile][game] = score;
                    PlayerPrefs.SetInt($"{selectedProfile}_{game}_HighScore", score);
                    PlayerPrefs.Save(); // Save PlayerPrefs changes
                }
                else
                {
                    Debug.Log("New score is not higher than the current high score.");
                }
            }
            else
            {
                Debug.LogError("Game not found in the profile.");
            }
        }
        else
        {
            Debug.LogError("Profile not found.");
        }
    }

    public int LoadGameHighScore(Game game)
    {
        return PlayerPrefs.GetInt($"{selectedProfile}_{game}_HighScore");
    }


    public int LoadHighScore(Profile profile, Game game)
    {
        if (_profiles.ContainsKey(profile) && _profiles[profile].ContainsKey(game))
        {
            return _profiles[profile][game];
        }
        else
        {
            Debug.LogError("Profile or game not found.");
            return 0;
        }
    }

    private void SetHighScore(Profile profile, Game game, int score)
    {
        if (!_profiles.ContainsKey(profile))
        {
            _profiles[profile] = new Dictionary<Game, int>();
        }
        _profiles[profile][game] = score;
    }
}
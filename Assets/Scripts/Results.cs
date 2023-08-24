using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _score;
    [SerializeField]
    private TextMeshProUGUI _highsScore;
    public void UpdateResults(SaveManager.Game game, int score)
    {
        _score.text = score.ToString();
        _highsScore.text = SaveManager.Instance.LoadGameHighScore(game).ToString();
    }
}

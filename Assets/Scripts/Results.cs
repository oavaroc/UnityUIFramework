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

    /* Summary: Updates the score and high score on the result screen for the game
     * 
     * Parameters: 
     * game : the game that was completed
     * score : the score that was obtained
     */
    public void UpdateResults(SaveManager.Game game, int score)
    {
        _score.text = score.ToString();
        _highsScore.text = SaveManager.Instance.LoadGameHighScore(game).ToString();
    }
}

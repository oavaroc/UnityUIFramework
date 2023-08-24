using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _score;


    /* Summary: Updates the score on the UI
     * 
     * Parameters: 
     * score : the score that was obtained
     */
    public void UpdateScore(int score)
    {
        _score.text = "Score: " + score;

    }
}

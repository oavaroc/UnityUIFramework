using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _score;


    public void UpdateScore(int score)
    {
        _score.text = "Score: " + score;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGame : PlayableGame
{
    [SerializeField]
    private Score _scoreText;
    private int _score = 0;

    public void AddScore()
    {
        _scoreText.UpdateScore(++_score);
    }
    public override void HandleGameOver()
    {
        Debug.Log("Game Over");
    }
}

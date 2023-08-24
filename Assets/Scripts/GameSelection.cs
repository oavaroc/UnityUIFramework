using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelection : MonoBehaviour
{
    [SerializeField]
    private Transform _gameParent;
    [SerializeField]
    private GameObject _mathGame;
    [SerializeField]
    private Transform _mathGameLocation;
    [SerializeField]
    private GameObject _bubbleCount;
    [SerializeField]
    private Transform _bubbleGameLocation;
    [SerializeField]
    private GameObject _memoryGame;
    [SerializeField]
    private Transform _memoryGameLocation;

    [SerializeField]
    private Results _resultScreen;

    public void LoadMathGame()
    {
        if(Instantiate(_mathGame, _mathGameLocation.position, Quaternion.identity, _gameParent).TryGetComponent(out MathGame mathgame))
        {
            mathgame.SetResults(_resultScreen);
        }
    }
    public void LoadBubbleGame()
    {
        if(Instantiate(_bubbleCount, _bubbleGameLocation.position, Quaternion.identity, _gameParent).TryGetComponent(out BubbleCount bubbleCount))
        {
            bubbleCount.SetResults(_resultScreen);
        }

    }
    public void LoadMemoryGame()
    {
        if(Instantiate(_memoryGame, _memoryGameLocation.position, Quaternion.identity, _gameParent).TryGetComponent(out MatchGame matchGame))
        {
            matchGame.SetResults(_resultScreen);
        }

    }
}

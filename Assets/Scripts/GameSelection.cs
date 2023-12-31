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

    /* Summary: Loads the math game from the game select screen
     * 
     */
    public void LoadMathGame()
    {
        if(Instantiate(_mathGame, _mathGameLocation.position, Quaternion.identity, _gameParent).TryGetComponent(out MathGame mathgame))
        {
            mathgame.SetResults(_resultScreen);
        }
    }
    /* Summary: Loads the bubble game from game select screen
     * 
     */
    public void LoadBubbleGame()
    {
        if(Instantiate(_bubbleCount, _bubbleGameLocation.position, Quaternion.identity, _gameParent).TryGetComponent(out BubbleCount bubbleCount))
        {
            bubbleCount.SetResults(_resultScreen);
        }

    }
    /* Summary: Loads memory game from game selecty screen
     * 
     */
    public void LoadMemoryGame()
    {
        if(Instantiate(_memoryGame, _memoryGameLocation.position, Quaternion.identity, _gameParent).TryGetComponent(out MatchGame matchGame))
        {
            matchGame.SetResults(_resultScreen);
        }

    }
}

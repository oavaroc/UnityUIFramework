using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MatchGame : PlayableGame
{
    private List<Toggle> _matchObjects;
    [SerializeField]
    private Score _scoreText;
    private int _score = 0;
    [SerializeField]
    private GameObject _matchItem;
    [SerializeField]
    private int _matchCount = 60;
    [SerializeField]
    private Transform _matchParent;
    [SerializeField]
    private List<Sprite> _fruitSprites;

    private Toggle _selectedToggle;

    private bool gameOver = false;


    /* Summary: instantiated the match items for how many were serialized by count
     *          initializes the fruit id and the sprite
     *          keeps a list of match items by toggle
     *          
     */
    private void Start()
    {
        _matchObjects = new List<Toggle>();
        for (int i =0; i < _matchCount; i++)
        {
            GameObject instantiatedObject = Instantiate(_matchItem, _matchParent.position, Quaternion.identity, _matchParent);
            instantiatedObject.name += i;
            if (instantiatedObject.TryGetComponent(out MatchItem matchItem))
            {
                matchItem.SetFruit(Mathf.FloorToInt(i/2),_fruitSprites[Mathf.FloorToInt(i / 2)]);
            }
            if(instantiatedObject.TryGetComponent(out Toggle toggle))
            {
                _matchObjects.Add(toggle);
            }
        }
        RandomizeItems();
    }

    /* Summary: Randomize the order of the items with the fisher-yates shuffle
     */
    private void RandomizeItems()
    {
        
        List<Transform> children = new List<Transform>();
        foreach (Transform child in _matchParent)
        {
            children.Add(child);
        }

        // Shuffle the order of the children using Fisher-Yates shuffle algorithm
        System.Random rng = new System.Random();
        int n = children.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Transform value = children[k];
            children[k] = children[n];
            children[n] = value;
        }

        // Reparent the shuffled children under the parent GameObject
        foreach (Transform child in children)
        {
            child.SetParent(null);
            child.SetParent(_matchParent);
        }
    }


    /* Summary: determines if the selected toggle is the first of the pair of selects, if second, it will continue, if first, it will be saved
     * 
     * Parameters: 
     * compareMe : the toggle that is selected just now
     */
    public void CheckSelected(Toggle compareMe)
    {
        AudioManager.Instance.PlayMatchItemFlipped();
        if (_selectedToggle == null)
        {
            _selectedToggle = compareMe;
        }
        else
        {
            CompareSelected(compareMe);
        }
    }

    /* Summary: compares the second click with the first click by comparing the enum on the Match Item
     *          if the second click is the first item that was clicked, it is unselected and proceeds no further
     *          if paired, runs correct method
     *          if wrong, runs wrong method
     * 
     * Parameters: 
     * compareMe : the toggle that is selectred just now
     */
    private void CompareSelected(Toggle compareMe)
    {

        if (_selectedToggle.TryGetComponent(out MatchItem item))
        {
            if(compareMe.TryGetComponent(out MatchItem itemCompare))
            {
                Debug.Log("Checking fruit 1: " + item.GetFruit());
                Debug.Log("Checking fruit 2: " + itemCompare.GetFruit());
                Debug.Log("selected: " + _selectedToggle.name);
                Debug.Log("compareMe: " + compareMe.name);
                if (_selectedToggle.name.Equals(compareMe.name))
                {
                    Debug.Log("Same button clicked");
                    _selectedToggle = null;
                    return;
                }

                if (item.GetFruit().Equals(itemCompare.GetFruit()))
                {
                    item.RemoveOnClick();
                    itemCompare.RemoveOnClick();
                    Correct(_selectedToggle,compareMe);
                }
                else
                {
                    Wrong(_selectedToggle,compareMe);
                }
                _selectedToggle = null;
            }
        }
    }

    /* Summary: handles the correct pairing of items
     * 
     * Parameters: 
     * selectredToggle : the toggle that was clicked first
     * compareMe : the toggle that was clicked second
     */
    private void Correct(Toggle selectedToggle, Toggle compareMe)
    {
        Debug.Log("Right");
        AudioManager.Instance.PlayMatchItemRight();
        selectedToggle.interactable = false;
        compareMe.interactable = false;
        AddScore();

    }

    /* Summary: Handles the wrong pairing of items
     * 
     * Parameters: 
     * selectedToggle : the toggle that was clicked first
     * compareMe : the toggle that was clicked second
     */
    private void Wrong(Toggle selectedToggle, Toggle compareMe)
    {
        Debug.Log("Wrong");
        AudioManager.Instance.PlayMatchItemWrong();
        selectedToggle.interactable = false;
        compareMe.interactable = false;
        StartCoroutine(WrongRoutine(selectedToggle,compareMe));

    }

    /* Summary: Delays the hiding of the wrong pair to show what was there
     * 
     * Parameters: 
     * selectedToggle : the first toggle selected
     * compareMe : the second toggle selected
     */
    IEnumerator WrongRoutine(Toggle selectedToggle, Toggle compareMe)
    {
        yield return new WaitForSeconds(1f);
        if (!gameOver)
        {

            selectedToggle.isOn = false;
            compareMe.isOn = false;
            compareMe.interactable = true;
            selectedToggle.interactable = true;
        }
    }

    /* Summary: Adds the score
     * 
     */
    public void AddScore()
    {
        _scoreText.UpdateScore(++_score);
    }
    /* Summary: disables all buttons and stops coroutines, loads the results screen
     * 
     */
    public override void HandleGameOver()
    {
        gameOver = true;
        StopAllCoroutines();
        _matchObjects.ForEach(x => { x.interactable = false; x.isOn = true; });
        Debug.Log("Game Over");
        SaveManager.Instance.SaveHighScore(SaveManager.Game.MemoryGame, _score);
        _results.UpdateResults(SaveManager.Game.MemoryGame, _score);
        _results.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleCount : PlayableGame
{
    private int _currentCount=1; // Bubble count value

    [SerializeField]
    private GameObject _bubble;
    [SerializeField]
    private Transform _bubbleParent;

    private int _nextNumber = 1;
    [SerializeField]
    private BoxCollider2D _spawnAreaCollider; // Reference to the BoxCollider component
    private Coroutine _gameLoop;
    [SerializeField]
    private Score _scoreText;
    private int _score = 0;

    /* Summary: Starts the bubbles spawning and initializes score
     * 
     */
    private void Start()
    {
        _gameLoop= StartCoroutine(SpawnBubblesRoutine());
        _score = 0;
    }
    /* Summary: Starts spawning bubbles every second to try and maintain 10 bubbles
     * 
     */
    IEnumerator SpawnBubblesRoutine()
    {
        while (true)
        {
            while(_bubbleParent.childCount < 10)
            {
                // Calculate random position within the spawn area
                Vector3 randomPosition = GetRandomPosition();
                Debug.Log("randomPosition: "+randomPosition);
                // Instantiate the object at the random position
               
                if (Instantiate(_bubble, randomPosition, Quaternion.identity, _bubbleParent).TryGetComponent(out BouncingButton bouncingButton))
                {
                    bouncingButton.SetNumber(_nextNumber++);
                }

            }
            yield return new WaitForSeconds(1f);

        }
    }

    /* Summary: gets a random position within a small area in the center
     * 
     */
    private Vector3 GetRandomPosition()
    {
        // Get collider's bounds
        Bounds bounds = _spawnAreaCollider.bounds;
        Debug.Log("bounds: " + bounds);

        // Calculate random position within the bounds
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        // Return the calculated random position
        return new Vector3(randomX, randomY, randomZ);
    }

    /* Summary: when a bubble is created, it subscribes to this event
     * 
     */
    private void OnEnable()
    {
        // Subscribe to the onBubbleCreated event
        BouncingButton.onBubbleCreated.AddListener(SubscribeToBubbleEvent);
    }

    /* Summary: when a bubble is disabled, unsubscribes to the event
     * 
     */
    private void OnDisable()
    {
        // Unsubscribe when this script is disabled
        BouncingButton.onBubbleCreated.RemoveListener(SubscribeToBubbleEvent);
    }

    /* Summary: subscribes the new bubble to the event
     * 
     * parameters:
     * bubble : the new bubble created
     */
    private void SubscribeToBubbleEvent(BouncingButton bubble)
    {
        // Subscribe to the bubble click event for the newly instantiated bubble
        bubble.onBubbleClicked.AddListener(CheckBubbleValue);
    }

    /* Summary: checks the bubble when clicked to the current count, if match, bubble is destroyed, else it stays
     * 
     * parameters:
     * clickedValue : value of the bubble clicked
     */
    private void CheckBubbleValue(int clickedValue)
    {
        if (clickedValue == _currentCount)
        {
            AudioManager.Instance.PlayBubbleRight();
            _currentCount++;
            _scoreText.UpdateScore(++_score);
            // Value matches, destroy the bubble button
            Debug.Log("Value matches! Destroying the bubble.");

            // Get the GameObject of the bubble button and destroy it
            GameObject bubbleGameObject = EventSystem.current.currentSelectedGameObject;
            Destroy(bubbleGameObject);
        }
        else
        {
            AudioManager.Instance.PlayBubbleWrong();
            // Value doesn't match, handle accordingly
            Debug.Log("Value doesn't match.");
        }
    }


    /* Summary: destroys the buttons and stops spawning then loads the results screen
     * 
     */
    public override void HandleGameOver()
    {
        Debug.Log("Game Over");
        StopCoroutine(_gameLoop);
        foreach(BouncingButton button in _bubbleParent.GetComponentsInChildren<BouncingButton>())
        {
            Destroy(button.gameObject);
        }
        SaveManager.Instance.SaveHighScore(SaveManager.Game.BubbleGame, _score);
        _results.UpdateResults(SaveManager.Game.BubbleGame, _score);
        _results.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float _timerDuration = 10.0f;
    [SerializeField]
    private TextMeshProUGUI _timer;
    [SerializeField]
    private PlayableGame _game;


    private float _currentTime;
    private Coroutine _gameLoop;
    /* Summary: Starts the timer for the game
     * 
     */
    private void Start()
    {
        _currentTime = _timerDuration;
        _gameLoop = StartCoroutine(StartTimer());
    }

    /* Summary: Starts counting down the gimer and updates the timer display
     * 
     */
    private IEnumerator StartTimer()
    {
        Debug.Log("Timer starting!");
        // Countdown loop
        while (_currentTime > 0f)
        {
            // Wait for 1 second
            yield return new WaitForSeconds(1f);
            UpdateTimerDisplay(--_currentTime);
        }

        // Timer has reached 0, handle game over 
        HandleTimerFinished();
    }

    /* Summary: Stops the game loop and calls the gameover function for the current game
     * 
     */
    private void HandleTimerFinished()
    {
        _game.HandleGameOver();
        StopCoroutine(_gameLoop);
    }

    /* Summary: converts seconds left to mm:ss format and displays it on the timer
     * 
     * Parameters: 
     * currentTime : the current time left on the timer in seconds
     * 
     */
    public void UpdateTimerDisplay(float currentTime)
    {
        // Format the time as minutes:seconds
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        _timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

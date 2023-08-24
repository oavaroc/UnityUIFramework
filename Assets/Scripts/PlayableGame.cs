using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableGame : MonoBehaviour
{

    protected Results _results;

    /* Summary: Handles the game over defined in each game
     * 
     */
    public abstract void HandleGameOver();

    /* Summary: Sets the results screen to the new results screen
     * 
     * Parameters: 
     * results : the results screen object
     */
    public void SetResults(Results results)
    {
        _results = results;
    }
}

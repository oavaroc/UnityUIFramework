using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableGame : MonoBehaviour
{

    protected Results _results;
    public abstract void HandleGameOver();

    public void SetResults(Results results)
    {
        _results = results;
    }
}

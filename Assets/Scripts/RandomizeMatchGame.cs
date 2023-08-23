using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMatchGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform)
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
            child.SetParent(transform);
        }
    }

}

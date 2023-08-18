using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log(typeof(T).ToString() + " is NULL");
            }
            return _instance;
        }
    }

    protected void Awake()
    {
        _instance = (T)this;

        Init();
    }

    public virtual void Init()
    {

    }
}

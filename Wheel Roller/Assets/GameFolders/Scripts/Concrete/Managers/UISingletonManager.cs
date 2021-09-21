using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISingletonManager : MonoBehaviour
{
    public static UISingletonManager Instance { get; private set; }
    private void Awake()
    {
        SingletonThisGameObject();
    }
    public void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

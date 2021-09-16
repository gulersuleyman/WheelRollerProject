using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int _marsScore;
    public int _worldScore;
    public int _saturnScore;


    public static GameManager Instance { get; private set; }


    public event System.Action<int> OnScoreChanged;

    private void Awake()
    {
        SingletonThisGameObject();
    }
    private void SingletonThisGameObject()
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

    public void IncreaseScore(int score1=0,int score2=0,int score3=0)
    {
        _marsScore += score1;
        OnScoreChanged?.Invoke(_marsScore);

        _worldScore += score2;
        OnScoreChanged?.Invoke(_worldScore);

        _saturnScore += score3;
        OnScoreChanged?.Invoke(_saturnScore);
    }
}

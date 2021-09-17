using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelUI : MonoBehaviour
{
    public Text _marsScoreText;
    public Text _worldScoreText;
    public Text _saturnScoreText;
    public Text _gameScoreText;

    private void Start()
    {
        GameManager.Instance.OnGameScoreChanged += HandleOnGameScoreChanged;
        GameManager.Instance.OnPlanetScoreChanged += HandleOnPlanetScoreChanged;
        HandleOnPlanetScoreChanged();
        HandleOnGameScoreChanged();
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameScoreChanged -= HandleOnGameScoreChanged;
        GameManager.Instance.OnPlanetScoreChanged -= HandleOnPlanetScoreChanged;
    }
    private void HandleOnPlanetScoreChanged(int score=0)
    {
        _marsScoreText.text = GameManager.Instance._marsScore.ToString();
        _worldScoreText.text = GameManager.Instance._worldScore.ToString();
        _saturnScoreText.text = GameManager.Instance._saturnScore.ToString();
    }
    private void HandleOnGameScoreChanged(int index=0)
    {
        _gameScoreText.text = GameManager.Instance._gameScore.ToString();
    }
}

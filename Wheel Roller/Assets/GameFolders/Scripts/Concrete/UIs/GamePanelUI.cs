using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelUI : MonoBehaviour
{
    public Text _marsScoreText;
    public Text _worldScoreText;
    public Text _saturnScoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
        HandleOnScoreChanged();
    }
    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= HandleOnScoreChanged;
    }
    private void HandleOnScoreChanged(int score=0)
    {
        _marsScoreText.text = GameManager.Instance._marsScore.ToString();
        _worldScoreText.text = GameManager.Instance._worldScore.ToString();
        _saturnScoreText.text = GameManager.Instance._saturnScore.ToString();
    }
}

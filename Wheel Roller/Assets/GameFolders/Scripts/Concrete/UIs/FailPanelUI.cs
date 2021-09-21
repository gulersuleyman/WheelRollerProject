using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanelUI : MonoBehaviour
{
    [SerializeField] GameObject _gamePanel;
    public void RestartButtonClick()
    {
        GameManager.Instance.lateOpen();
        GameManager.Instance._marsScore = 0;
        GameManager.Instance._worldScore = 0;
        GameManager.Instance._saturnScore = 0;

        this.gameObject.SetActive(false);
        _gamePanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    private ScoreManager _scoreManager;

    [SerializeField] private GameObject _gameOverWindow;
    [SerializeField] private TextMeshProUGUI _finalScoreUI;

    private void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
    }

    public void ShowGameOverWindow()
    {
        _gameOverWindow.SetActive(true);
        _finalScoreUI.SetText(_scoreManager.GetScore().ToString());

        if(PlayerPrefs.HasKey("HighScore"))
        {
            int savedScore = PlayerPrefs.GetInt("HighScore");
            if (savedScore < _scoreManager.GetScore())
                PlayerPrefs.SetInt("HighScore", _scoreManager.GetScore());
        } else
        {
            PlayerPrefs.SetInt("HighScore", _scoreManager.GetScore());
        }

        PlayerPrefs.Save();

        Debug.Log("Game data saved!");
    }
}

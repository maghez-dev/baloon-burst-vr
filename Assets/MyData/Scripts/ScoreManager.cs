using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public bool _unlimitedLives = true;

    private bool _gameOver = false;

    [SerializeField] private int _currentScore = 0;
    [SerializeField] private int _currentLives = 3;

    public void AddScore(int val)
    {
        _currentScore += val;
    }

    public void ReduceLives()
    {
        if (_unlimitedLives)
            return;

        _currentLives--;

        if(_currentLives < 0)
            _currentLives = 0;

        if (_currentLives <= 0 && !_gameOver)
        {
            _gameOver = true;
            GetComponent<GameManager>().GameOver();
        }
    }

    public void ResetGame()
    {
        _currentScore = 0;
        _currentLives = 3;
    }

    public int GetScore()
    {
        return _currentScore;
    }

    public int GetLives()
    {
        return _currentLives;
    }
}

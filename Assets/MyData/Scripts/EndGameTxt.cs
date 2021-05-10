using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameTxt : MonoBehaviour
{
    private ScoreManager _scoreManager;
    [SerializeField] private TextMeshProUGUI _finalScore;


    private void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (_finalScore != null)
            _finalScore.text = ""+_scoreManager.GetScore();
    }
}

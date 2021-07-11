using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FetchScore : MonoBehaviour
{
    [SerializeField] private TextMeshPro _score;


    void Start()
    {
        int score = PlayerPrefs.GetInt("HighScore", 0);
        _score.SetText(score.ToString());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;
    private ScoreManager _scoreManager;
    private bool _check = true;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _scoreManager = GetComponent<ScoreManager>();
    }


    private IEnumerator SceneLoading(int idx)
    {
        if (idx == 1)
            _scoreManager._unlimitedLives = true;
        else
            _scoreManager._unlimitedLives = false;

        GameObject.FindGameObjectWithTag("Transitions").GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(idx);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayEnvironment();
        _gameManager.StartPos();
        _check = true;
    }


    public void LoadMainMenu()
    {
        if (_check)
        {
            _check = false;
            StartCoroutine(SceneLoading(0));
        }
    }


    public void LoadTutorial()
    {
        if(_check)
        {
            _check = false;
            StartCoroutine(SceneLoading(1));
        }
    }


    public void LoadGame()
    {
        if (_check)
        {
            _check = false;
            StartCoroutine(SceneLoading(2));
        }
    }
}

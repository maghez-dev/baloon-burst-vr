using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _check = true;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
    }


    private IEnumerator SceneLoading(int idx)
    {
        Debug.Log("Hi1");
        GameObject.FindGameObjectWithTag("Transitions").GetComponent<Animator>().SetTrigger("FadeOut");
        Debug.Log("Hi2");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(idx);
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

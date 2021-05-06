using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;


    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
    }


    private void SceneLoading(int idx)
    {
        SceneManager.LoadScene(idx);
        _gameManager.StartPos();
    }


    public void LoadMainMenu()
    {
        SceneLoading(0);
    }


    public void LoadTutorial()
    {
        SceneLoading(1);
    }


    public void LoadGame()
    {
        SceneLoading(2);
    }
}

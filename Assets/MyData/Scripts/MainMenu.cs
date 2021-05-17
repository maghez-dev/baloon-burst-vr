using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private LevelManager _lvlManager;

    // Start is called before the first frame update
    void Start()
    {
        _lvlManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>();
    }

    public void LoadTutorial()
    {
        _lvlManager.LoadTutorial();
    }

    public void LoadGame()
    {
        _lvlManager.LoadGame();
    }
}

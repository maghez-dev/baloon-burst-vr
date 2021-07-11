using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour, IPuntableObject
{
    [SerializeField] private GameObject _baloonShooterObj;
    [SerializeField] private GameObject _birdSpawnerObj;
    [SerializeField] private GameObject _wrapperObj;

    public void OnPointerClick()
    {
        Debug.Log("Game start!");

        _baloonShooterObj.SetActive(true);
        _birdSpawnerObj.SetActive(true);
        _wrapperObj.SetActive(false);
    }

    public void OnPointerEnter()
    {
        // Don't Implement
    }

    public void OnPointerExit()
    {
        // Don't Implement
    }
}

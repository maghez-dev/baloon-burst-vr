using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToScore : MonoBehaviour, IPuntableObject
{
    [SerializeField] private bool _forward = true;

    [SerializeField] private GameObject _mainMenuObj;
    [SerializeField] private GameObject _scoreMenuObj;


    public void OnPointerClick()
    {
        if(_forward)
        {
            _scoreMenuObj.SetActive(true);
            _mainMenuObj.SetActive(false);
        } else
        {
            _mainMenuObj.SetActive(true);
            _scoreMenuObj.SetActive(false);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour, IPuntableObject
{
    [SerializeField] private GameObject _thisWindow;


    public void OnPointerClick()
    {
        _thisWindow.SetActive(false);
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

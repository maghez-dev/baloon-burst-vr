using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitClick : MonoBehaviour, IPuntableObject
{
    public void OnPointerClick()
    {
        Debug.Log("Shutting Down...");
        Application.Quit();
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

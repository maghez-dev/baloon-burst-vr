using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitClick : MonoBehaviour, IPuntableObject
{
    public void OnPointerClick()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>().LoadMainMenu();
    }

    public void OnPointerEnter()
    {
        // Don't implement
    }

    public void OnPointerExit()
    {
        // Don't implement
    }
}

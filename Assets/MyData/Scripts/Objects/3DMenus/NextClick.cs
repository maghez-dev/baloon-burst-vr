using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextClick : MonoBehaviour, IPuntableObject
{
    public void OnPointerClick()
    {
        GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialWindowHandler>().NextTutorial();
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

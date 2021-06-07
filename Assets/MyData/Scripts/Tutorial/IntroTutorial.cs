using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTutorial : MonoBehaviour, IPuntableObject
{

    public void OnPointerClick()
    {
        GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialWindowHandler>().NextTutorial();
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

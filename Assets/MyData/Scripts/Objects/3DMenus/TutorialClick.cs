using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialClick : MonoBehaviour, IPuntableObject
{
    public void OnPointerClick()
    {
        //GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>().LoadTutorial();
        StartCoroutine(timeout());
    }

    public void OnPointerEnter()
    {
        // Don't Implement
    }

    public void OnPointerExit()
    {
        // Don't Implement
    }

    private IEnumerator timeout()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>().LoadTutorial();
    }
}

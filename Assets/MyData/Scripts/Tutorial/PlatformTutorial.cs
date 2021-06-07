using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTutorial : MonoBehaviour
{
    void Update()
    {
        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButton(0))
            StartCoroutine(DelayedLevelChange());
    }

    private IEnumerator DelayedLevelChange()
    {
        yield return new WaitForSeconds(2f);

        GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialWindowHandler>().NextTutorial();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTutorial : MonoBehaviour
{
    private int _prevCount;
    private int _currentCount;

    private void Start()
    {
        StartCoroutine(DelayStart());
        _prevCount = 0;
        _currentCount = 0;
    }

    void Update()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Baloon");
        _currentCount = balloons.Length;

        if(_currentCount < _prevCount)
            GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialWindowHandler>().NextTutorial();
        else
            _prevCount = _currentCount;
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(1.5f);

        GameObject.FindGameObjectWithTag("Shooter").GetComponent<BaloonShooter>().enabled = true;
    }
}

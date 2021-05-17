using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindowHandler : MonoBehaviour
{
    private int _currentWindow;

    [SerializeField] private GameObject[] _windowsList;

    // Start is called before the first frame update
    void Start()
    {
        _currentWindow = 0;

        foreach (GameObject g in _windowsList)
        {
            g.SetActive(false);
        }
        _windowsList[_currentWindow].SetActive(true);
    }

    public void NextTutorial()
    {
        _windowsList[_currentWindow].SetActive(false);
        _currentWindow++;
        if (_currentWindow >= _windowsList.Length)
            return;

        StartCoroutine(DelayedActive());
    }

    private IEnumerator DelayedActive()
    {
        yield return new WaitForSeconds(0.2f);

        _windowsList[_currentWindow].SetActive(true);
    }
}

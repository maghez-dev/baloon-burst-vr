using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _crossAim;
    [SerializeField] private GameObject _dotAim;

    void Start()
    {
        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>()._isActive = true;
        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>()._canShoot = true;
        _dotAim.SetActive(false);
        _crossAim.SetActive(true);
    }

    /*
    void Update()
    {
        if(Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButton(0)) {
            GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialWindowHandler>().NextTutorial();
        }
    }
    */
}

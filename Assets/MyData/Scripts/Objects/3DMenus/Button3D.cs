using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour, IPuntableObject
{
    private bool _weaponCheck;

    [SerializeField] private Material _stdColor;
    [SerializeField] private Material _highlightColor;
    [SerializeField] private Material _clickColor;


    void Start()
    {
        GetComponent<Renderer>().material = _stdColor;
    }

    public void OnPointerClick()
    {
        GetComponent<Renderer>().material = _clickColor;

        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled = _weaponCheck;
    }

    public void OnPointerEnter()
    {
        GetComponent<Renderer>().material = _highlightColor;

        _weaponCheck = GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled;
        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled = false;
    }

    public void OnPointerExit()
    {
        GetComponent<Renderer>().material = _stdColor;

        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled = _weaponCheck;
    }
}

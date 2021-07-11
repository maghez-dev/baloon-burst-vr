using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour, IPuntableObject
{
    private Weapon _weapon;

    [SerializeField] private Material _stdColor;
    [SerializeField] private Material _highlightColor;
    [SerializeField] private Material _clickColor;


    void Start()
    {
        _weapon = GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>();
        GetComponent<Renderer>().material = _stdColor;
    }

    public void OnPointerClick()
    {
        GetComponent<Renderer>().material = _clickColor;
    }

    public void OnPointerEnter()
    {
        GetComponent<Renderer>().material = _highlightColor;

        _weapon._canShoot = false;
    }

    public void OnPointerExit()
    {
        GetComponent<Renderer>().material = _stdColor;

        _weapon._canShoot = _weapon._isActive;
    }
}

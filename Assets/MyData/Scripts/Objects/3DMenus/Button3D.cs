using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour, IPuntableObject
{
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
    }

    public void OnPointerEnter()
    {
        GetComponent<Renderer>().material = _highlightColor;
    }

    public void OnPointerExit()
    {
        GetComponent<Renderer>().material = _stdColor;
    }
}

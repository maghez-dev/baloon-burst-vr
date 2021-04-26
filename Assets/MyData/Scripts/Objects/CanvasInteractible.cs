using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasInteractible : MonoBehaviour, IPuntableObject
{
    public void OnPointerClick()
    {
           // Empty
    }

    public void OnPointerEnter()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _crosshairPointer;
    [SerializeField] private GameObject _standardPointer;


    public void OnPointerClick()
    {
        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled = true;
        _crosshairPointer.SetActive(true);
        _standardPointer.SetActive(false);
    }

    public void OnPointerEnter()
    {
        // Don't implement
    }

    public void OnPointerExit()
    {
        // Don't implement
    }
}

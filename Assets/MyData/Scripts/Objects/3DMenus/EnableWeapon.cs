using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWeapon : MonoBehaviour
{
    public void OnPointerClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>().enabled = true;
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

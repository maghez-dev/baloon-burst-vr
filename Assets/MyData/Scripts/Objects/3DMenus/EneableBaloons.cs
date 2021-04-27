using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneableBaloons : MonoBehaviour
{
    public void OnPointerClick()
    {
        GameObject.FindGameObjectWithTag("Shooter").GetComponent<BaloonShooter>().enabled = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuntableObject
{
    // This method is called by the Main Camera when it starts gazing at this GameObject.
    void OnPointerEnter();

    // This method is called by the Main Camera when it stops gazing at this GameObject.
    void OnPointerExit();

    // This method is called by the Main Camera when it is gazing at this GameObject and the screen is touched.
    void OnPointerClick();
}

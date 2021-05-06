using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraPosition : MonoBehaviour
{
    [SerializeField] private Transform _outerPos;


    public void FixPosition(Transform tr)
    {
        _outerPos.position = tr.position;
        _outerPos.rotation = tr.rotation;
    }
}

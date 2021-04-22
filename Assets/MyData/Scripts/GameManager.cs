using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Transform _redPosition;
    [SerializeField] private Transform _greenPosition;
    [SerializeField] private Transform _bluePosition;

    [SerializeField] private Material _redMat;
    [SerializeField] private Material _greenMat;
    [SerializeField] private Material _blueMat;


    public void Start()
    {
        TeleportTo(_greenMat);
    }

    public void TeleportTo(Material mat)
    {

        if (mat.color == _redMat.color)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = _redPosition.position;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().rotation = _redPosition.rotation;
        } else if (mat.color == _greenMat.color)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = _greenPosition.position;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().rotation = _greenPosition.rotation;
        } else if (mat.color == _blueMat.color)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = _bluePosition.position;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().rotation = _bluePosition.rotation;
        }
    }
}
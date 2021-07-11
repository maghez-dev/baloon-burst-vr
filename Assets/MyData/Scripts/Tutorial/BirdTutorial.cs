using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _birdSpawner;


    void Start()
    {
        _birdSpawner.SetActive(true);

        _birdSpawner.GetComponent<BirdSpawner>().SpawnBird();
    }
}

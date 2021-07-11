using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] private Transform _northSpawn;
    [SerializeField] private Transform _southSpawn;
    [SerializeField] private Transform _eastSpawn;
    [SerializeField] private Transform _westSpawn;

    [SerializeField] private GameObject _birdPrefab;


    void Start()
    {
        StartCoroutine(SpawnDelay(20f));
    }


    private IEnumerator SpawnDelay(float delay)
    {
        Debug.Log("Bird will spawn in: " + delay + " seconds");

        yield return new WaitForSeconds(delay);

        SpawnBird();
        float rand = Random.Range(30f, 60f);
        StartCoroutine(SpawnDelay(rand));

        yield return null;
    }


    public void SpawnBird()
    {
        int rand = Random.Range(1, 4);
        //int rand = 4;

        GameObject birdObject;
        switch (rand)
        {
            case 1:
                birdObject = Instantiate(_birdPrefab, _northSpawn.position, _northSpawn.rotation);
                break;
            case 2:
                birdObject = Instantiate(_birdPrefab, _southSpawn.position, _southSpawn.rotation);
                break;
            case 3:
                birdObject = Instantiate(_birdPrefab, _eastSpawn.position, _eastSpawn.rotation);
                break;
            case 4:
                birdObject = Instantiate(_birdPrefab, _westSpawn.position, _westSpawn.rotation);
                break;
            default:
                Debug.Log("Internal error");
                break;
        }
    }
}

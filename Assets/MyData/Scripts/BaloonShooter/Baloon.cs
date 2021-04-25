using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField] private float _timeToLive = 4f;
    [SerializeField] private float _bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

        StartCoroutine(DestroyDelay(_timeToLive));
    }

    void Update()
    {
        transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyMe();
    }

    private IEnumerator DestroyDelay(float time)
    {
        yield return new WaitForSeconds(time);

        DestroyMe();
        yield return null;
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}

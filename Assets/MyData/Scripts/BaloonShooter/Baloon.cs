using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField] private float _timeToLive = 4f;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private int _scoreValue = 1;


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
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().AddScore(_scoreValue);
        }
        DestroyMe();
    }

    private IEnumerator DestroyDelay(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().ReduceLives();
        DestroyMe();
        yield return null;
    }

    private void DestroyMe()
    {
        //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayPop();
        //GetComponent<AudioSource>().Play();
        //Destroy(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;

        StartCoroutine(DestroySoundDelay());
    }

    private IEnumerator DestroySoundDelay()
    {
        GetComponent<AudioSource>().Play();
        float time = GetComponent<AudioSource>().clip.length;

        yield return new WaitForSeconds(time);

        Destroy(gameObject);
        yield return null;
    }
}

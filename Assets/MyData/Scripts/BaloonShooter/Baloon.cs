using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField] private MeshRenderer _mesh1;
    [SerializeField] private MeshRenderer _mesh2;
    [SerializeField] private Transform _pivot;

    [SerializeField] private float _timeToLive = 4f;
    [SerializeField] private float _rotationSpeed = 30f;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private int _scoreValue = 1;

    [SerializeField] private GameObject _deathEffect;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

        StartCoroutine(DestroyDelay(_timeToLive));
    }

    void Update()
    {
        transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
        _pivot.Rotate(_rotationSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().AddScore(_scoreValue);

            GameObject death = Instantiate(_deathEffect);
            death.GetComponent<FloatingScore>().SetText(""+_scoreValue);
            death.transform.position = _transform.position;
        }
        DestroyMe("miss");
    }

    private IEnumerator DestroyDelay(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().ReduceLives();
        DestroyMe("miss");

        yield return null;
    }

    private void DestroyMe(string msg)
    {
        _mesh1.enabled = false;
        _mesh2.enabled = false;

        GetComponent<SphereCollider>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private int _lifeGiven = 1;
    private bool _hit = false;
    public bool _active = true;

    [SerializeField] private float _birdSpeed = 10f;
    [SerializeField] private float _timeToLive = 10f;

    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private SkinnedMeshRenderer _mesh;
    [SerializeField] private AudioClip _hitSound;


    private void Start()
    {
        StartCoroutine(TimeToLive(_timeToLive));
    }


    void Update()
    {
        transform.position += transform.forward * _birdSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (_active)
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().AddLives(_lifeGiven);

            GameObject death = Instantiate(_deathEffect);
            death.GetComponent<FloatingScore>().SetText("+" + _lifeGiven);
            TextMeshProUGUI text = death.GetComponent<FloatingScore>().GetText();
            text.color = new Color(255, 0, 0);
            death.transform.position = transform.position;

            _hit = true;
        }
        DestroyMe();
    }


    private IEnumerator TimeToLive(float time)
    {
        yield return new WaitForSeconds(time);

        DestroyMe();
    }

    private void DestroyMe()
    {
        StopAllCoroutines();

        _mesh.enabled = false;
        BoxCollider[] colliders = GetComponents<BoxCollider>();
        foreach (BoxCollider coll in colliders)
        {
            coll.enabled = false;
        }

        StartCoroutine(DestroySoundDelay());
    }


    private IEnumerator DestroySoundDelay()
    {
        float time = 0f;

        if(_hit)
        {
            GetComponent<AudioSource>().clip = _hitSound;
            GetComponent<AudioSource>().maxDistance = 1000;
            GetComponent<AudioSource>().Play();
            time = GetComponent<AudioSource>().clip.length;
        }

        yield return new WaitForSeconds(time);

        Destroy(gameObject);

        yield return null;
    }
}

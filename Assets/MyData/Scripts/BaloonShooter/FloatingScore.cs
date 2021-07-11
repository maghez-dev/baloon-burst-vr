using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingScore : MonoBehaviour
{
    private Camera _cameraToLookAt;

    [SerializeField] private float _upSpeed = 0.5f;
    [SerializeField] private float _timeToLive = 2f;
    [SerializeField] private TextMeshProUGUI _scoreTxt;

    private void Start()
    {
        _cameraToLookAt = GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Camera>();

        StartCoroutine(DestroyDelay(_timeToLive));
    }

    private void Update()
    {
        Vector3 v = _cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(_cameraToLookAt.transform.position);
        transform.Rotate(0, 180, 0);

        transform.Translate(Vector3.up * _upSpeed * Time.deltaTime, Space.World);
    }

    private IEnumerator DestroyDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }


    public TextMeshProUGUI GetText()
    {
        return _scoreTxt;
    }

    public void SetText(string val)
    {
        _scoreTxt.text = "+" + val;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool _canShoot = true;

    [SerializeField] private float _shootDelay = 0.5f;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firepoint;


    private void Start()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().StartPos();
    }

    void Update()
    {
        if ((Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButton(0)) && _canShoot)
        {
            GameObject bulletObject = Instantiate(_bulletPrefab);
            bulletObject.transform.position = _playerCamera.transform.position + _playerCamera.transform.forward;
            bulletObject.transform.forward = _playerCamera.transform.forward;

            StartCoroutine(ShootDelay(_shootDelay));
        }
    }

    private IEnumerator ShootDelay(float delay)
    {
        _canShoot = false;

        yield return new WaitForSeconds(delay);

        _canShoot = true;
    }
}

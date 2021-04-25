using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonShooter : MonoBehaviour
{
    private bool _canShoot = true;

    [SerializeField] private float _shootDelay = 1.5f;
    [SerializeField] private GameObject _baloonPrefab;
    [SerializeField] private Transform _firepoint;


    private void Update()
    {
        if (_canShoot)
        {
            RandomRotate();

            GameObject bulletObject = Instantiate(_baloonPrefab);
            bulletObject.transform.position = _firepoint.position + _firepoint.transform.forward;
            bulletObject.transform.forward = transform.forward;

            StartCoroutine(ShootDelay(_shootDelay));
        }
    }

    private void RandomRotate()
    {
        StandardPos();

        int yRotAngle = Random.Range(-90, 90);
        int yOffset = 180;
        int xRotAngle = Random.Range(5, -30);

        Quaternion rot = Quaternion.Euler(xRotAngle, yRotAngle+yOffset, 0);
        transform.rotation = rot;
    }

    private IEnumerator ShootDelay(float delay)
    {
        _canShoot = false;

        yield return new WaitForSeconds(delay);

        _canShoot = true;
    }

    private void StandardPos()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

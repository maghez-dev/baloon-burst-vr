using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonShooter : MonoBehaviour
{
    private bool _canShoot = true;

    [SerializeField] private Mode _mode;
    [SerializeField] private float _shootDelay = 1.5f;
    [SerializeField] private GameObject _baloonPrefab;
    [SerializeField] private Transform _firepoint;

    public enum Mode
    {
        Red,
        Green,
        Blue
    }

    private void Update()
    {
        if (_canShoot)
        {
            Rotate(_mode);

            GameObject bulletObject = Instantiate(_baloonPrefab);
            bulletObject.transform.position = _firepoint.position + _firepoint.transform.forward;
            bulletObject.transform.forward = transform.forward;

            StartCoroutine(ShootDelay(_shootDelay));
        }
    }

    private void Rotate(Mode mode)
    {
        StandardPos();

        int offset = 180;
        int xRotAngle = Random.Range(0, -10);
        int yRotAngle = 0;

        switch (mode)
        {
            case Mode.Blue:
                yRotAngle = Random.Range(-135, -45);
                break;
            case Mode.Green:
                yRotAngle = Random.Range(-45, 45);
                break;
            case Mode.Red:
                yRotAngle = Random.Range(45, 135);
                break;
        }

        Quaternion rot = Quaternion.Euler(xRotAngle, yRotAngle+offset, 0);
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

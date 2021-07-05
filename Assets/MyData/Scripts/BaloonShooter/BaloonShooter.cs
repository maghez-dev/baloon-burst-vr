using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonShooter : MonoBehaviour
{
    private int _balloonCounter = 0;
    private bool _bonus = false;
    private bool _canShoot = true;
    private Mode[] modes = new Mode[]{Mode.Red, Mode.Green, Mode.Blue};

    [SerializeField] private Mode _mode;
    [SerializeField] private float _shootDelay = 1.5f;
    [SerializeField] private GameObject _baloonPrefab;
    [SerializeField] private GameObject _baloonBonusPrefab;
    [SerializeField] private Transform _firepoint;

    public enum Mode
    {
        Red,
        Green,
        Blue
    }

    private void Start()
    {
        _balloonCounter = 0;
        float delay = Random.Range(5, 15);
        StartCoroutine(BonusDelay(delay));
    }

    private void Update()
    {
        if (_canShoot)
        {
            // Difficulty increase
            _balloonCounter++;
            if (_balloonCounter > 15 && _balloonCounter <= 20)
                _shootDelay = 4f;
            else if (_balloonCounter > 20 && _balloonCounter <= 35)
                _shootDelay = 3f;
            else if (_balloonCounter > 35)
                _shootDelay = 2f;

            // Random balloon direction
            int idx = Random.Range(1, 3);
            _mode = modes[idx];
            Rotate(_mode);

            // Balloon instantiation
            GameObject bulletObject;
            if(_bonus)
            {
                _bonus = false;
                float delay = Random.Range(10, 20);
                StartCoroutine(BonusDelay(delay));
                bulletObject = Instantiate(_baloonBonusPrefab);
            } else
            {
                bulletObject = Instantiate(_baloonPrefab);
            }
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

    private IEnumerator BonusDelay(float delay)
    {
        _bonus = false;

        Debug.Log("Next Bonus in " + delay + " seconds");

        yield return new WaitForSeconds(delay);

        _bonus = true;
    }

    private void StandardPos()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

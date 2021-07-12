using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonShooter : MonoBehaviour
{
    private bool _bonus = false;
    private bool _canShoot = true;
    private bool _levelCheck = true;
    private int _currentDifficultyLevel = 1;
    private Mode[] modes = new Mode[]{Mode.Red, Mode.Green, Mode.Blue};

    public int _balloonCounter = 0;
    public bool _active = true;

    [SerializeField] private Mode _mode;
    [SerializeField] private float _shootDelay = 1.5f;
    [SerializeField] private GameObject _baloonPrefab;
    [SerializeField] private GameObject _baloonBonusPrefab;
    [SerializeField] private Transform _firepoint;
    [SerializeField] private Material _greenMat;
    [SerializeField] private Material _yellowMat;
    [SerializeField] private Material _redMat;

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
            _balloonCounter++;
            Debug.Log("Balloon shot: " + _balloonCounter);
            if (_levelCheck && (_balloonCounter == 10 || _balloonCounter == 20 || _balloonCounter == 30))
            {
                _levelCheck = false;
                LevelUpDifficulty();
            }
            if (_balloonCounter == 11 || _balloonCounter == 21 || _balloonCounter == 31)
            {
                _levelCheck = true;
            }

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
            bulletObject.GetComponent<Baloon>()._active = _active;

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


    public void LevelUpDifficulty()
    {
        _currentDifficultyLevel++;
        Debug.Log("Current difficulty level: " + _currentDifficultyLevel);

        switch (_currentDifficultyLevel)
        {
            case 2:
                GetComponent<MeshRenderer>().material = _greenMat;
                _shootDelay = 3.5f;
                break;
            case 3:
                GetComponent<MeshRenderer>().material = _yellowMat;
                _shootDelay = 3f;
                break;
            case 4:
                GetComponent<MeshRenderer>().material = _redMat;
                _shootDelay = 2.5f;
                break;
            default:
                break;
        }

        GetComponent<AudioSource>().Play();
    }
}

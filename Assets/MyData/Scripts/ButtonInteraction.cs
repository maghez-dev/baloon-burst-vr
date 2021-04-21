using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour, IPuntableObject
{
    private Renderer _renderer;
    private Material _myMat;

    [SerializeField] private Material _yellow;
    [SerializeField] private Material _white;

    [SerializeField] private Transform _targetTransform;

    public void Start()
    {
        _renderer = GetComponent<Renderer>();
        _myMat = _renderer.material;
    }

    public void OnPointerClick()
    {
        _renderer.material = _white;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = _targetTransform.position;
        
        StartCoroutine(ResetColor());
    }

    public void OnPointerEnter()
    {
        _renderer.material = _yellow;
    }

    public void OnPointerExit()
    {
        _renderer.material = _myMat;
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(2f);
        _renderer.material = _myMat;
    }
}

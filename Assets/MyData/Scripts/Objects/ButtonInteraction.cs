using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour, IPuntableObject
{
    private Renderer _renderer;
    private Material _myMat;
    private bool _pause = false;
    private GameManager _manager;

    [SerializeField] private Material _yellow;
    [SerializeField] private Material _white;


    public void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _renderer = GetComponent<Renderer>();
        _myMat = _renderer.material;
    }

    public void OnPointerClick()
    {
        if (_pause)
            return;

        _renderer.material = _white;

        StartCoroutine(Teleport());
    }

    public void OnPointerEnter()
    {
        if (_pause)
            return;

        _renderer.material = _yellow;
    }

    public void OnPointerExit()
    {
        if (_pause)
            return;

        _renderer.material = _myMat;
    }

    private IEnumerator Teleport()
    {
        _pause = true;
        GameObject.FindGameObjectWithTag("Transitions").GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        _manager.TeleportTo(_myMat);
        GameObject.FindGameObjectWithTag("Transitions").GetComponent<Animator>().SetTrigger("FadeIn");

        yield return new WaitForSeconds(1.5f);

        _pause = false;
        _renderer.material = _myMat;
    }
}

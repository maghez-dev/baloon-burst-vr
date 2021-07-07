using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour, IPuntableObject
{
    private Renderer _renderer;
    private bool _pause = false;
    private GameManager _manager;
    private bool _weaponCheck;

    [SerializeField] private Material _material;
    [SerializeField] private Material _materialDark;
    [SerializeField] private Material _black;

    public void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _renderer = GetComponent<Renderer>();
    }

    public void OnPointerClick()
    {
        if (_pause)
            return;

        _renderer.material = _black;

        StartCoroutine(Teleport());
    }

    public void OnPointerEnter()
    {
        if (_pause)
            return;

        _renderer.material = _materialDark;

        _weaponCheck = GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled;
        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled = false;
    }

    public void OnPointerExit()
    {
        if (_pause)
            return;

        _renderer.material = _material;

        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled = _weaponCheck;
    }

    private IEnumerator Teleport()
    {
        _pause = true;
        GameObject.FindGameObjectWithTag("Transitions").GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Weapon>().enabled = _weaponCheck;

        _manager.TeleportTo(_material);
        GameObject.FindGameObjectWithTag("Transitions").GetComponent<Animator>().SetTrigger("FadeIn");

        yield return new WaitForSeconds(1.5f);

        _pause = false;
        _renderer.material = _material;
    }
}

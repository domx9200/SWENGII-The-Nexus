using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownHandler : MonoBehaviour
{
    [SerializeField] private GameObject _dropDown;
    private Animator _animator;

    private void Start()
    {
        // Null check animator
        _animator = _dropDown.GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("DropDownHandler::Animator is null");
        }
    }

    public void OpenDropDown()
    {
        if (_dropDown != null)
        {
            _dropDown.SetActive(!_dropDown.activeSelf);
            bool isOpen = _animator.GetBool("open");
            _animator.SetBool("open", !isOpen);
            StartCoroutine(WaitForOpenAnimation(_animator.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    public void CloseDropDown()
    {
        if (_dropDown != null)
        {
            // Set all children inactive
            foreach (Transform child in _dropDown.transform)
            {
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }

            bool isOpen = _animator.GetBool("open");
            _animator.SetBool("open", !isOpen);
            StartCoroutine(WaitForCloseAnimation(_animator.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    IEnumerator WaitForOpenAnimation(float delay = 0)
    {
        yield return new WaitForSeconds(delay);

        // Set all children active
        foreach (Transform child in _dropDown.transform)
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
        this.gameObject.SetActive(false);
    }

    IEnumerator WaitForCloseAnimation(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        _dropDown.SetActive(!_dropDown.activeSelf);
        this.gameObject.SetActive(false);
    }
}

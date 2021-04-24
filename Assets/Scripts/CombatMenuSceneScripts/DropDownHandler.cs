﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour
{
    [SerializeField] private GameObject _dropDown;
    private Animator _dropDownAnimator;
    private float _DropDownSize = 166.3731f;

    private void Start()
    {
        // Null check animator
        _dropDownAnimator = _dropDown.GetComponent<Animator>();
        if (_dropDownAnimator == null)
        {
            Debug.LogError("DropDownHandler::Animator is null");
        }
    }

    public void OpenDropDown()
    {
        if (_dropDown != null)
        {
            _dropDown.SetActive(!_dropDown.activeSelf);
            bool isOpen = _dropDownAnimator.GetBool("open");
            _dropDownAnimator.SetBool("open", !isOpen);
            StartCoroutine(WaitForOpenAnimation(_dropDownAnimator.GetCurrentAnimatorStateInfo(0).length));
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
            bool isOpen = _dropDownAnimator.GetBool("open");
            _dropDownAnimator.SetBool("open", !isOpen);
            StartCoroutine(WaitForCloseAnimation(_dropDownAnimator.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    IEnumerator WaitForOpenAnimation(float delay = 0)
    {
        // Prevent double clicking
        this.gameObject.transform.GetComponent<Button>().enabled = false;
        this.gameObject.transform.parent.GetChild(2).GetComponent<Button>().enabled = false;

        // Change size of scrollview
        RectTransform contentRT = this.transform.parent.parent.parent.gameObject.GetComponent<RectTransform>();
        contentRT.sizeDelta = new Vector2(0, contentRT.rect.height + _DropDownSize);

        GameObject initList = _dropDown.transform.parent.parent.gameObject;
        int currIndex = _dropDown.transform.parent.GetSiblingIndex();

        for(int i = currIndex + 1; i < initList.transform.childCount; i++)
        {
            var currCreature = initList.transform.GetChild(i).gameObject;
            float newY = currCreature.transform.localPosition.y - _DropDownSize;
            currCreature.GetComponent<CreatureMoveController>().updateMoveTo(newY);
        }

        // Animate
        yield return new WaitForSeconds(delay - 0.2f);

        // Set all children active
        foreach (Transform child in _dropDown.transform)
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
        this.gameObject.SetActive(false);

        // Reset buttons
        this.gameObject.transform.GetComponent<Button>().enabled = true;
        this.gameObject.transform.parent.GetChild(2).GetComponent<Button>().enabled = true;
    }

    IEnumerator WaitForCloseAnimation(float delay = 0)
    {
        // Prevent double clicking
        this.gameObject.transform.GetComponent<Button>().enabled = false;
        this.gameObject.transform.parent.GetChild(1).GetComponent<Button>().enabled = false;

        GameObject initList = _dropDown.transform.parent.parent.gameObject;
        int currIndex = _dropDown.transform.parent.GetSiblingIndex();

        for (int i = currIndex + 1; i < initList.transform.childCount; i++)
        {
            var currCreature = initList.transform.GetChild(i).gameObject;
            float newY = currCreature.transform.localPosition.y + _DropDownSize;
            currCreature.GetComponent<CreatureMoveController>().updateMoveTo(newY);
        }

        // Animate
        yield return new WaitForSeconds(delay);

        // Change size of scrollview
        RectTransform contentRT = this.transform.parent.parent.parent.GetComponent<RectTransform>();
        contentRT.sizeDelta = new Vector2(0, contentRT.rect.height - _DropDownSize);

        _dropDown.SetActive(!_dropDown.activeSelf);
        this.gameObject.SetActive(false);

        // Reset buttons
        this.gameObject.transform.GetComponent<Button>().enabled = true;
        this.gameObject.transform.parent.GetChild(1).GetComponent<Button>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour
{
    [SerializeField] private GameObject _dropDown;
    private Animator _dropDownAnimator;

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
        contentRT.sizeDelta = new Vector2(0, contentRT.rect.height + 166.3731f);

        // get init list
        GameObject initList = transform.parent.parent.gameObject;
        int currIndex = transform.parent.GetSiblingIndex(); // current creature in list

        // Loop through all creatures below current creature and animate
        for (int i = currIndex + 1; i < initList.transform.childCount; i++)
        {
            Animator anim = initList.transform.GetChild(i).GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool("open", true);
                anim.SetInteger("status", 1);

            }
            else
            {
                Debug.Log("DropDownHandler::No animator on creature: " + initList.transform.GetChild(i).name);
            }
        }


        // Anaimate
        yield return new WaitForSeconds(delay);

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

        // Get init list
        GameObject initList = transform.parent.parent.gameObject;
        int currIndex = transform.parent.GetSiblingIndex(); // index of current creature in init list

        // Loop through all creatures below current creature and animate
        for (int i = currIndex + 1; i < initList.transform.childCount; i++)
        {
            Animator anim = initList.transform.GetChild(i).GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool("open", false);
                anim.SetInteger("status", 2);
            }
            else
            {
                Debug.Log("DropDownHandler::No animator on creature: " + initList.transform.GetChild(i).name);
            }
        }

        // Animate
        yield return new WaitForSeconds(delay);

        // Change size of scrollview
        RectTransform contentRT = this.transform.parent.parent.parent.GetComponent<RectTransform>();
        contentRT.sizeDelta = new Vector2(0, contentRT.rect.height - 166.3731f);

        _dropDown.SetActive(!_dropDown.activeSelf);
        this.gameObject.SetActive(false); 
        RectTransform contentRT = this.transform.parent.parent.parent.gameObject.GetComponent<RectTransform>();
        contentRT.sizeDelta = new Vector2(0, contentRT.rect.height - 166.3731f);

        _dropDown.SetActive(!_dropDown.activeSelf);
        this.gameObject.SetActive(false);

        // Reset buttons
        this.gameObject.transform.GetComponent<Button>().enabled = true;
        this.gameObject.transform.parent.GetChild(1).GetComponent<Button>().enabled = true;
    }
}

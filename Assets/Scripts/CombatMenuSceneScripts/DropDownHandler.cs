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
<<<<<<< Updated upstream
=======
        // Prevent double clicking
        this.gameObject.transform.GetComponent<Button>().enabled = false;
        this.gameObject.transform.parent.GetChild(2).GetComponent<Button>().enabled = false;

        // Change size of scrollview
        RectTransform contentRT = this.transform.parent.parent.parent.gameObject.GetComponent<RectTransform>();
        contentRT.sizeDelta = new Vector2(0, contentRT.rect.height + 166.3731f);

        // get init list
        GameObject initList = transform.parent.parent.gameObject;
        int currIndex = transform.parent.GetSiblingIndex(); // current creature in list
        Debug.Log("Creature expanding is: " + initList.transform.GetChild(currIndex));

        // Loop through all creatures below current creature and animate
        for (int i = currIndex + 1; i < initList.transform.childCount; i++)
        {
            Debug.Log("Current Creature moving is: " + initList.transform.GetChild(i).name);
            Animator anim = initList.transform.GetChild(i).GetComponent<Animator>();
            Debug.Log("tst 1/1");
            if (anim != null)
            {
                Debug.Log("tset 2/1");
                anim.SetBool("open", true);
                Debug.Log("test 3/1");
            }
            else
            {
                Debug.Log("DropDownHandler::No animator on creature: " + initList.transform.GetChild(i).name);
            }
        }

        Debug.Log("test 4/1");

        // Anaimate
>>>>>>> Stashed changes
        yield return new WaitForSeconds(delay);

        Debug.Log("test 5/1");

        // Set all children active
        foreach (Transform child in _dropDown.transform)
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
        this.gameObject.SetActive(false);
<<<<<<< Updated upstream
=======

        Debug.Log("test 6/1");

        // Reset buttons
        this.gameObject.transform.GetComponent<Button>().enabled = true;
        this.gameObject.transform.parent.GetChild(2).GetComponent<Button>().enabled = true;

        Debug.Log("test 7/1");

>>>>>>> Stashed changes
    }

    IEnumerator WaitForCloseAnimation(float delay = 0)
    {
<<<<<<< Updated upstream
=======
        // Prevent double clicking
        this.gameObject.transform.GetComponent<Button>().enabled = false;
        this.gameObject.transform.parent.GetChild(1).GetComponent<Button>().enabled = false;

        // Get init list
        GameObject initList = transform.parent.parent.gameObject;
        int currIndex = transform.parent.GetSiblingIndex(); // index of current creature in init list
        Debug.Log("Creature collapsing is: " + initList.transform.GetChild(currIndex));

        // Loop through all creatures below current creature and animate
        for (int i = currIndex + 1; i < initList.transform.childCount; i++)
        {
            Debug.Log("Current Creature moving is: " + initList.transform.GetChild(i).name);
            Animator anim = initList.transform.GetChild(i).GetComponent<Animator>();
            Debug.Log("tast 1/2");
            if (anim != null)
            {
                Debug.Log("Test 2/2");
                anim.SetBool("open", false);
                Debug.Log("test 3/2");
            }
            else
            {
                Debug.Log("DropDownHandler::No animator on creature: " + initList.transform.GetChild(i).name);
            }
        }

        Debug.Log("test 4/2");

        // Animate
>>>>>>> Stashed changes
        yield return new WaitForSeconds(delay);
        _dropDown.SetActive(!_dropDown.activeSelf);
        this.gameObject.SetActive(false);
    }
}

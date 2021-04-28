using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour
{
    [SerializeField] private GameObject _dropDown;
    private Animator _dropDownAnimator;
    private float _DropDownSize = 166.3731f;
    public bool _IsActive = false;

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
            _dropDown.SetActive(true);
            _IsActive = true;
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
                child.gameObject.SetActive(false);
            }
            transform.parent.GetChild(1).gameObject.SetActive(true);
            _IsActive = false;
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

        //prevent clicking of the side buttons to prevent errors
        var Canvas = transform.parent.parent.parent.parent.parent.parent.gameObject;
        Canvas.transform.GetChild(3).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(4).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(5).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(6).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(10).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(11).GetComponent<Button>().enabled = false;

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
            child.gameObject.SetActive(true);
        }

        // Reset buttons
        this.gameObject.transform.GetComponent<Button>().enabled = true;
        this.gameObject.transform.parent.GetChild(2).GetComponent<Button>().enabled = true;
        _dropDown.transform.parent.GetChild(1).gameObject.SetActive(false);
        _dropDown.transform.parent.GetChild(2).gameObject.SetActive(true);
        var currentTurn = initList.transform.parent.GetChild(0).gameObject;
        int currTurnIndex = currentTurn.GetComponent<ControlCombatScript>().TurnIndex;
        currentTurn.transform.position = new Vector2(51.10001f, initList.transform.GetChild(currTurnIndex).position.y);

        Canvas.transform.GetChild(3).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(4).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(5).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(6).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(10).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(11).GetComponent<Button>().enabled = true;
    }

    IEnumerator WaitForCloseAnimation(float delay = 0, bool isJank = false)
    {
        // Prevent double clicking
        this.gameObject.transform.GetComponent<Button>().enabled = false;
        this.gameObject.transform.parent.GetChild(1).GetComponent<Button>().enabled = false;

        //prevent clicking of the side buttons to prevent errors
        var Canvas = transform.parent.parent.parent.parent.parent.parent.gameObject;
        Canvas.transform.GetChild(3).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(4).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(5).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(6).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(10).GetComponent<Button>().enabled = false;
        Canvas.transform.GetChild(11).GetComponent<Button>().enabled = false;

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

        _dropDown.SetActive(false);

        // Reset buttons
        this.gameObject.transform.GetComponent<Button>().enabled = true;
        this.gameObject.transform.parent.GetChild(1).GetComponent<Button>().enabled = true;
        _dropDown.transform.parent.GetChild(1).gameObject.SetActive(true);
        _dropDown.transform.parent.GetChild(2).gameObject.SetActive(false);
        var currentTurn = initList.transform.parent.GetChild(0).gameObject;
        int currTurnIndex = currentTurn.GetComponent<ControlCombatScript>().TurnIndex;
        currentTurn.transform.position = new Vector2(51.10001f, initList.transform.GetChild(currTurnIndex).position.y);

        Canvas.transform.GetChild(3).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(4).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(5).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(6).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(10).GetComponent<Button>().enabled = true;
        Canvas.transform.GetChild(11).GetComponent<Button>().enabled = true;
    }
}

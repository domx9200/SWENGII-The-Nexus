using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//Script to control the initiative within the combat menu.
public class OrderInitiativeScript : MonoBehaviour
{
    // Global variables for control.
    public GameObject Initiative = null;

    //Find the Initiative List.
    public void Start()
    {
        Initiative = GameObject.Find("InitiativeList");

    }


    // Method to move initiatives down in the list.
    public void SlideDown()
    {
        Initiative = transform.parent.gameObject;
        Debug.Log(Initiative.name);
        // Check to first make sure we aren't trying to slide the final initiative further down.
        // Updated the function to use the sibling indexes to determine what is the lowest and highest
        // that way multiple creatures of the same name can be set if wanted.
        if (transform.GetSiblingIndex() == Initiative.transform.childCount - 1)
        {
            Debug.Log(string.Format("Cannot Slide the last initiative further down"));
        }
        else
        {
            GameObject BottomPosition = Initiative.transform.GetChild(this.transform.GetSiblingIndex() + 1).gameObject;
            int SwapIndex = this.transform.GetSiblingIndex() + 1;

            float TopPos = this.transform.localPosition.y;
            float BotPos = BottomPosition.transform.localPosition.y;

            gameObject.GetComponent<CreatureMoveController>().updateMoveTo(BotPos);
            BottomPosition.GetComponent<CreatureMoveController>().updateMoveTo(TopPos);

            BottomPosition.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
            this.transform.SetSiblingIndex(SwapIndex);
        }
    }

    // Method to move initiatives up in the list
    public void SlideUp()
    {
        Initiative = transform.parent.gameObject;
        // Check to first make sure we aren't trying to slide the first initiative higher up.
        if (transform.GetSiblingIndex() == 0)
        {
            Debug.Log(string.Format("Cannot Slide the first initiative higher up"));
        }
        else
        {
            GameObject TopPosition = Initiative.transform.GetChild(this.transform.GetSiblingIndex() - 1).gameObject;
            int SwapIndex = this.transform.GetSiblingIndex() - 1;

            float BotPos = this.transform.localPosition.y;
            float TopPos =  TopPosition.transform.localPosition.y;

            gameObject.GetComponent<CreatureMoveController>().updateMoveTo(TopPos);
            TopPosition.GetComponent<CreatureMoveController>().updateMoveTo(BotPos);

            TopPosition.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
            this.transform.SetSiblingIndex(SwapIndex);
        }
    }
}
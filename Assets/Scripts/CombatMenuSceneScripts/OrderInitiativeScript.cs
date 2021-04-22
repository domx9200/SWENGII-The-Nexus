﻿using System.Collections;
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
        // Check to first make sure we aren't trying to slide the final initiative further down.
        if (this.name == Initiative.transform.GetChild(Initiative.transform.childCount - 1).name)
        {
            Debug.Log(string.Format("Cannot Slide the last initiative further down"));
        }
        else
        {
            GameObject BottomPosition = Initiative.transform.GetChild(this.transform.GetSiblingIndex() + 1).gameObject;
            int j = this.transform.GetSiblingIndex() + 1;

            Vector3 TempPosition = this.transform.position;
            this.transform.position = BottomPosition.transform.position;
            BottomPosition.transform.position = TempPosition;

            BottomPosition.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
            this.transform.SetSiblingIndex(j);
        }
    }

    // Method to move initiatives up in the list
    public void SlideUp()
    {
        // Check to first make sure we aren't trying to slide the first initiative higher up.
        if(this.name == Initiative.transform.GetChild(0).name)
        {
            Debug.Log(string.Format("Cannot Slide the first initiative higher up"));
        }
        else
        {
            GameObject TopPosition = Initiative.transform.GetChild(this.transform.GetSiblingIndex() - 1).gameObject;
            int j = this.transform.GetSiblingIndex() - 1;

            Vector3 TempPosition = this.transform.position;
            this.transform.position = TopPosition.transform.position;
            TopPosition.transform.position = TempPosition;

            TopPosition.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
            this.transform.SetSiblingIndex(j);

        }
    }
}
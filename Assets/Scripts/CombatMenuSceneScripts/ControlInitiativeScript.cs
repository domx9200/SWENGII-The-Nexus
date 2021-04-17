using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//Script to control the initiative within the combat menu.
public class ControlInitiativeScript : MonoBehaviour
{
    // Global variables for control.
    public GameObject Initiative = null;
    public GameObject RoundCounter = null;
    public int TurnIndex = 0;
    public int RoundCount = 1;

    //Find the Initiative List, as well as the Round Counter's Text, and set the turn count to 1 at the start.
    public void Start()
    {
        Initiative = GameObject.Find("InitiativeList");
        RoundCounter = GameObject.Find("RoundCounterText");
        RoundCounter.GetComponent<Text>().text = "Round Count: " + RoundCount;
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

    // Method to advance to the next turn, and advance the round counter as necessary.
    public void NextTurn()
    {
        
        GameObject CurrentTurn = GameObject.Find("CurrentTurn");
        GameObject nextCreature;

        /* First make sure we aren't trying to advance if we are at the final initiative in the list.
         * If we are the final initiative we return to the top of the list, set the TurnIndex back to 0, 
         * increment the round counter, and then update the round counter text.
         */
        if(TurnIndex < Initiative.transform.childCount - 1)
        {
            nextCreature = Initiative.transform.GetChild(TurnIndex + 1).gameObject;
            CurrentTurn.transform.position = new Vector3(CurrentTurn.transform.position.x, nextCreature.transform.position.y, CurrentTurn.transform.position.z);
            TurnIndex++;

        }
        else
        {
            nextCreature = Initiative.transform.GetChild(0).gameObject;
            CurrentTurn.transform.position = new Vector3(CurrentTurn.transform.position.x, nextCreature.transform.position.y, CurrentTurn.transform.position.z);
            TurnIndex = 0;
            RoundCount++;
            RoundCounter.GetComponent<Text>().text = "Round Count: " + RoundCount;
        }
    }

    // Method to return to the previous turn.
    public void PreviousTurn()
    {
        GameObject CurrentTurn = GameObject.Find("CurrentTurn");
        GameObject PreviousCreature;

        // Make sure we aren't the first turn in the initiative list.
        if(TurnIndex != 0)
        {
            PreviousCreature = Initiative.transform.GetChild(TurnIndex - 1).gameObject;
            CurrentTurn.transform.position = new Vector3(CurrentTurn.transform.position.x, PreviousCreature.transform.position.y, CurrentTurn.transform.position.z);
            TurnIndex--;
        }
    }
}
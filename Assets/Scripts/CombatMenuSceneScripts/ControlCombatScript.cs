using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCombatScript : MonoBehaviour
{
    public GameObject RoundCounter = null;
    public GameObject Initiative = null;
    public int TurnIndex = 0;
    public int RoundCount = 1;

    void Start()
    {
        Initiative = GameObject.Find("InitiativeList");
        RoundCounter = GameObject.Find("RoundCounterText");
        RoundCounter.GetComponent<Text>().text = "Round Count: " + RoundCount;
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
        if (TurnIndex < Initiative.transform.childCount - 1)
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
        if (TurnIndex != 0)
        {
            PreviousCreature = Initiative.transform.GetChild(TurnIndex - 1).gameObject;
            CurrentTurn.transform.position = new Vector3(CurrentTurn.transform.position.x, PreviousCreature.transform.position.y, CurrentTurn.transform.position.z);
            TurnIndex--;
        }
    }
}

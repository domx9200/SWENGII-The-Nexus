using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCombatScript : MonoBehaviour
{
    public GameObject RoundCounter = null;
    public GameObject Initiative = null;
    public GameObject CurrentTurn = null;
    public int TurnIndex = 0;
    public int RoundCount = 1;
    [SerializeField] private GameObject _debugText;

    void Start()
    {
        Initiative = GameObject.Find("InitiativeList");
        CurrentTurn = GameObject.Find("CurrentTurn");
        RoundCounter = GameObject.Find("RoundCounterText");
        RoundCounter.GetComponent<Text>().text = "Round Count: " + RoundCount;
    }

    // Method to advance to the next turn, and advance the round counter as necessary.
    public void NextTurn()
    {
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
        GameObject PreviousCreature;

        // Make sure we aren't the first turn in the initiative list.
        if (TurnIndex != 0)
        {
            PreviousCreature = Initiative.transform.GetChild(TurnIndex - 1).gameObject;
            CurrentTurn.transform.position = new Vector3(CurrentTurn.transform.position.x, PreviousCreature.transform.position.y, CurrentTurn.transform.position.z);
            TurnIndex--;
        }
    }

    // Method to remove a creature from the list (currently removes the creature that current is on
    public void RemoveCreature()
    {
        if (Initiative.transform.childCount == 0)
        {
            StartCoroutine(ShowDebugMessage());
            return;
        }

        // First we need to check if we are trying to delete the first child in the list. If so we need to move everything up
        GameObject CurrentCreature = Initiative.transform.GetChild(TurnIndex).gameObject;
        if (CurrentCreature.name == Initiative.transform.GetChild(0).name)
        {
            Vector3 TopPosition = CurrentCreature.transform.position;
            Destroy(Initiative.transform.GetChild(TurnIndex).gameObject);
            for (int i = 0; i < Initiative.transform.childCount - 1; i++)
            {
                Vector3 TempPosition = Initiative.transform.GetChild(i + 1).position;
                Initiative.transform.GetChild(i + 1).position = TopPosition;
                TopPosition = TempPosition;
            }
        }

        // If not the first position, we check to see if we are in the middle of the list
        else if (CurrentCreature.name != Initiative.transform.GetChild(0).name && CurrentCreature.name != Initiative.transform.GetChild(Initiative.transform.childCount - 1).name)
        {
            Vector3 TopPosition = CurrentCreature.transform.position;
            Destroy(Initiative.transform.GetChild(TurnIndex).gameObject);
            for(int i = TurnIndex - 1; i < Initiative.transform.childCount - 1; i++)
            {
                Vector3 TempPosition = Initiative.transform.GetChild(i + 1).position;
                Initiative.transform.GetChild(i + 1).position = TopPosition;
                TopPosition = TempPosition;
            }
  
        }

        // Final Case is the last creature in the list. 
        else
        {
        GameObject PreviousCreature = Initiative.transform.GetChild(TurnIndex - 1).gameObject;
        Destroy(Initiative.transform.GetChild(TurnIndex).gameObject);
        CurrentTurn.transform.position = new Vector3(CurrentTurn.transform.position.x, PreviousCreature.transform.position.y, CurrentTurn.transform.position.z);
        TurnIndex--;
        }
    }

    IEnumerator ShowDebugMessage()
    {
        _debugText.SetActive(!_debugText.activeSelf);
        yield return new WaitForSeconds(3);
        _debugText.SetActive(!_debugText.activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlCombatScript : MonoBehaviour
{
    public GameObject RoundCounter = null;
    public GameObject Initiative = null;
    public GameObject CurrentTurn = null;
    public int TurnIndex = 0;
    public int RoundCount = 1;
    

    void Start()
    {
        CurrentTurn = GameObject.Find("CurrentTurn");
        RoundCounter = GameObject.Find("RoundCounterText");
        RoundCounter.GetComponent<Text>().text = "Round Count: " + RoundCount;
    }

    // Method to sort the initiative list in descending order by the creature's initiative 
    public void SortInitiative()
    {
        int n = Initiative.transform.childCount;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                int jInit = 0;
                int J1Init = 0;
                int.TryParse(Initiative.transform.GetChild(j).GetChild(0).GetChild(0).GetComponent<TMP_InputField>().text, out jInit);
                int.TryParse(Initiative.transform.GetChild(j + 1).GetChild(0).GetChild(0).GetComponent<TMP_InputField>().text, out J1Init);
                if (jInit < J1Init)
                {
                    // Swap their positions
                    GameObject TopPosition = Initiative.transform.GetChild(j).gameObject;
                    GameObject BottomPosition = Initiative.transform.GetChild(j + 1).gameObject;

                    TopPosition.transform.SetSiblingIndex(j + 1);
                    BottomPosition.transform.SetSiblingIndex(j);
                }
            }
        }

        float offset = 0f;
        for(int i = 0; i < n; i++)
        {
            //unless it's the first creature check to see if the dropdown is down.
            if(i != 0)
                if(Initiative.transform.GetChild(i - 1).GetChild(7).GetComponent<Animator>().GetBool("open"))
                {
                    offset -= 166.3731f;
                }
            Initiative.transform.GetChild(i).GetComponent<CreatureMoveController>().updatePosAndMoveTo(offset);
            offset -= 31.61026f;
        }
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

        // Loop back around to the bottom of the list. We cannot do this if it's the first round.
        else if (RoundCount != 1)
        {
            PreviousCreature = Initiative.transform.GetChild(Initiative.transform.childCount - 1).gameObject;
            CurrentTurn.transform.position = new Vector3(CurrentTurn.transform.position.x, PreviousCreature.transform.position.y, CurrentTurn.transform.position.z);
            TurnIndex = Initiative.transform.childCount - 1;
            Debug.Log(TurnIndex);
            RoundCount--;
            RoundCounter.GetComponent<Text>().text = "Round Count: " + RoundCount;
        }
    }

    // Method to remove a creature from the list (currently removes the creature that current is on
    public void RemoveCreature()
    {
        if (Initiative.transform.childCount == 0)
        {
            return;
        }

        // First we need to check if we are trying to delete the first child in the list. If so we need to move everything up
        GameObject CurrentCreature = Initiative.transform.GetChild(TurnIndex).gameObject;
        if (CurrentCreature.name == Initiative.transform.GetChild(0).name)
        {
            Vector3 TopPosition = CurrentCreature.transform.localPosition;
            Destroy(Initiative.transform.GetChild(TurnIndex).gameObject);
            for (int i = 0; i < Initiative.transform.childCount - 1; i++)
            {
                Vector3 TempPosition = Initiative.transform.GetChild(i + 1).localPosition;
                Initiative.transform.GetChild(i + 1).localPosition = TopPosition;
                Initiative.transform.GetChild(i + 1).GetComponent<CreatureMoveController>().updateMoveTo(TopPosition.y);
                TopPosition = TempPosition;
            }
        }

        // If not the first position, we check to see if we are in the middle of the list
        else if (CurrentCreature.name != Initiative.transform.GetChild(0).name && CurrentCreature.name != Initiative.transform.GetChild(Initiative.transform.childCount - 1).name)
        {
            Vector3 TopPosition = CurrentCreature.transform.localPosition;
            Destroy(Initiative.transform.GetChild(TurnIndex).gameObject);
            for(int i = TurnIndex - 1; i < Initiative.transform.childCount - 1; i++)
            {
                Vector3 TempPosition = Initiative.transform.GetChild(i + 1).localPosition;
                Initiative.transform.GetChild(i + 1).localPosition = TopPosition;
                TopPosition = TempPosition;
            }
  
        }

        // Final Case is the last creature in the list. 
        else
        {
        GameObject PreviousCreature = Initiative.transform.GetChild(TurnIndex - 1).gameObject;
        Destroy(Initiative.transform.GetChild(TurnIndex).gameObject);
        CurrentTurn.transform.localPosition = new Vector3(CurrentTurn.transform.localPosition.x, PreviousCreature.transform.localPosition.y, CurrentTurn.transform.localPosition.z);
        TurnIndex--;
        }

        if (Initiative.transform.childCount == 0)
        {
            CurrentTurn.gameObject.SetActive(false);
        }
        else
        {
            CurrentTurn.gameObject.SetActive(true);
        }
    }

    public void ChangeRoundCount()
    {
        RoundCounter.GetComponent<Text>().text = "Round Count: " + RoundCount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class RollInit : MonoBehaviour
{
    [SerializeField] GameObject _Initiative = null;
    [SerializeField] GameObject _RoundCounter = null;
    public void RollInitiative()
    {
        int n = _Initiative.transform.childCount;
        for(int i = 0; i < n; i++)
        {
            int Rand = RollDie() + _Initiative.transform.GetChild(i).GetComponent<CreatureStats>()._Initiative;
            _Initiative.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TMP_InputField>().text = Rand.ToString();
        }
        _RoundCounter.GetComponent<ControlCombatScript>().SortInitiative();
    }

    public int RollDie()
    {
        int temp = (int)Math.Round((double)UnityEngine.Random.Range(1f, 20f), 0);
        return temp;
    }
}

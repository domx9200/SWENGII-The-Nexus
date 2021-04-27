/*
    StatsData simple class, made for simplifying the access of
    CreatureStats variables
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsData
{
    public string _Name;
    public int _HP, _AC, _Initiative;
    public int[] _Strength = new int[3], _Dexterity = new int[3], _Constitution = new int[3],
                  _Intelligence = new int[3], _Wisdom = new int[3], _Charisma = new int[3], _Passives = new int[3];

    public StatsData () {}
    public StatsData (CreatureStats stats)
    {
        _Name = stats._Name;
        _HP = stats._HP;
        _AC = stats._AC;
        _Initiative = stats._Initiative;

        _Strength = stats._Strength;
        _Dexterity = stats._Dexterity;
        _Constitution = stats._Constitution;
        _Intelligence = stats._Intelligence;
        _Wisdom = stats._Wisdom;
        _Charisma = stats._Charisma;
        _Passives = stats._Passives;
    }   
}

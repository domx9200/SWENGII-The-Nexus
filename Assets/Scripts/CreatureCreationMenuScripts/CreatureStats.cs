using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStats : MonoBehaviour
{
    //start by defining all the private variables that our creature is goiong to have
    public string _Name;
    public int _HP, _AC, _Initiative;
    public int[] _Strength = new int[3], _Dexterity = new int[3], _Constitution = new int[3],
                  _Intelligence = new int[3], _Wisdom = new int[3], _Charisma = new int[3], _Passives = new int[3];

    //constructor class for what will become the new creature, abilityStuff is a two dimensional array that
    //holds all ability info, this is so that we have less inputs. since there are six abilities, it should
    //always be [6][3] in size.
    public void SetValues(string name, int hp, int ac, int initiative, int[,] abilityStuff, int[] passives) 
    {
        _Name = name;
        _HP = hp;
        _AC = ac;
        _Initiative = initiative;
        for(int i = 0; i < 3; i++)
        {
            _Strength[i] = abilityStuff[0, i];
            _Dexterity[i] = abilityStuff[1, i];
            _Constitution[i] = abilityStuff[2, i];
            _Wisdom[i] = abilityStuff[3, i];
            _Intelligence[i] = abilityStuff[4, i];
            _Charisma[i] = abilityStuff[5, i];
        }
        _Passives = passives;
    }
}

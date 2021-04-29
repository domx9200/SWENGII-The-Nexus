using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;

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

    // Overload of SetValues compatible with StatsData
    public void SetValues(StatsData data) 
    {
        _Name = data._Name;
        _HP = data._HP;
        _AC = data._AC;
        _Initiative = data._Initiative;

        _Strength = data._Strength;
        _Dexterity = data._Dexterity;
        _Constitution = data._Constitution;
        _Intelligence = data._Intelligence;
        _Wisdom = data._Wisdom;
        _Charisma = data._Charisma;
        _Passives = data._Passives;
    }

    public StatsData GetValues() 
    {
        StatsData data = new StatsData(this);
        return data;
    }

    public void SaveValues()
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Save creature as JSON", 
            JsonHandler.SAVE_FOLDER, _Name + ".json", "json"); // Ensure the JSON file extension")
        JsonHandler.Save(this, path);
    }

    // Need to get file name at runtime
    public void LoadValues()
    {
        string path = StandaloneFileBrowser.OpenFilePanel("Load creature from JSON", JsonHandler.SAVE_FOLDER, "json", false)[0];
        StatsData data = JsonHandler.Load(path);
        // overwrite
        this.SetValues(data);
    }
}

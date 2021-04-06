/*
    JsonHandler class definition. Used for conversions of creature stats into 
    JSON-formatted strings and vice-versa. 
    
    Designed to be called at the end of FinishCreation.OnCreatureFinish()
    once a creature has been completed. The user will be prompted to save 
    their creature and this routine will run upon confirmation. 
*/

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JsonHandler
{
    private GameObject newCreature = null;  

    public JsonHandler(GameObject creature)
    {
        newCreature = creature;
        SaveSystem.Init();
    }

    // Convert the object's CreatureStats to a JSON-formatted string
    // then write that string to a file.
    public void Save()
    {       
        if (newCreature == null)
        {
            Debug.Log("Creature object not found. Could not save data.\n");
            return;
        }

        var stats = newCreature.GetComponent<CreatureStats>();
        string json = JsonUtility.ToJson(stats, true);
        
        SaveSystem.Save(json);
    }

    // Read a JSON-formatted string from a file, then parse that string and
    // overwrite the CreatureStats of our object.
    public void Load()
    {
        var stats = newCreature.GetComponent<CreatureStats>();
        
        if (stats == null)
        {
            Debug.Log("Creature object not found. Could not load data.\n");
            return;
        }

        string saveString = SaveSystem.Load();
        
        if (saveString != null)
        {             
            JsonUtility.FromJsonOverwrite(saveString, stats);
        }
    }
}

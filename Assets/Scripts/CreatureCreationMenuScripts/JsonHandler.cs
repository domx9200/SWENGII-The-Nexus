/*
    JsonHandler class definition. Used for conversions of creature stats into 
    JSON-formatted strings and vice-versa. 
    
    Designed to be called once a creature has been completed or when choosing
    to save or load a creature.  
*/

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class JsonHandler 
{
    public GameObject newCreature = null;   

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
            // Make this an error log
            Debug.Log("Creature object not found. Could not save data.\n"); 
            return;
        }
        var stats = newCreature.GetComponent<CreatureStats>(); // Our CreatureStats 
        string json = JsonUtility.ToJson(stats, true);  // Convert the stats to a JSON string
        
        string path = EditorUtility.SaveFilePanel("Save creature as JSON", 
            SaveSystem.SAVE_FOLDER, stats._Name + ".json", "json"); // Ensure the JSON file extension

        SaveSystem.Save(json, path);
    }

    // Read a JSON-formatted string from a file, then parse that string and
    // overwrite the CreatureStats of our object.
    public void Load()
    {
        var stats = newCreature.GetComponent<CreatureStats>(); 
        if (stats == null)
        {
            // Make this an error log
            Debug.Log("Creature object not found. Could not load data.\n"); 
            return;
        }

        string saveString = SaveSystem.Load();
        if (saveString != null)
        {             
            JsonUtility.FromJsonOverwrite(saveString, stats);
        }
        else 
        {
            // Make this an error log
            Debug.Log("Problems loading the creature file. Use a valid path and file extension.\n");
            return;
        }
    }
}
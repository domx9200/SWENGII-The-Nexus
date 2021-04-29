/*
    JsonHandler class definition. Used for conversions of creature stats into 
    JSON-formatted strings and vice-versa. 
*/

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHandler 
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";  // Default directory for save files   

    public static void Init()
    {
        // Test if save folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // Create save folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }        
    }

    // Convert the object's CreatureStats to a JSON-formatted string
    // then write that string to a file.
    public static void Save(CreatureStats stats, string path)
    {        
        string json = JsonUtility.ToJson(stats, true); 

        File.WriteAllText(path, json);
    }

    // Reads from a creature file and returns the stats
    public static StatsData Load(string path)
    {
        StatsData data = new StatsData(); 

        if (File.Exists(path))
        {   
            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, data);          
            return data;
        }
        else 
        {
            Debug.LogError("Problems loading the creature file. Use a valid path and file extension.\n");
            return null;
        }
    }
    
}
/*
    Simple static class SaveSystem. Used by JsonHandler for writing
    to and reading from files. 
    
    Since JsonHandler is the only routine that uses SaveSystem, I 
    made SaveSystem a simple class. I made SaveSystem static so it's
    only initialized when the JsonHandler routine is running.
*/

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";  // Directory for save files
           
    public static void Init()
    {
        // Test if save folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // Create save folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }        
    }

    // Save to a given file 
    public static void Save(string saveString)
    {
        // Simple write to file on our save file
        File.WriteAllText(SAVE_FOLDER + "save.json", saveString);
    }

    // Get data from a JSON file, then return it as a string
    public static string Load()
    {
        // Check that the desired file exists
        if (File.Exists(SAVE_FOLDER + "save.json"))
        {
            // Put data into a string so that it can be parsed
            string saveString = File.ReadAllText(SAVE_FOLDER + "save.json");
            return saveString;
        }
        else
        {  
            return null;
        }
    }
}

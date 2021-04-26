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
using UnityEditor;
using SFB;

public static class SaveSystem
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

    // Save to a given file 
    public static void Save(string saveString, string path)
    {
        File.WriteAllText(path, saveString);
    }

    // Get data from a JSON file, then return it as a string
    // Loads one file per call
    public static string Load()
    {
        // Open directory with OpenFilePanel 
        string path = StandaloneFileBrowser.OpenFilePanel("Load creature from JSON", SAVE_FOLDER, "json", false)[0];
        string saveString = File.ReadAllText(path);
        
        if (path.Length != 0)
        {
            return saveString;
        }

        return null;
    }
}
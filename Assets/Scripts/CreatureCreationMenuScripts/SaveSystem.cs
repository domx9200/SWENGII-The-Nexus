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
        int saveNumber = 1;
        // Save without overwriting
        while (File.Exists("save_" + saveNumber + ".json"))
        {
            saveNumber++;            
        }
        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + ".json", saveString);
    }

    // Get data from a JSON file, then return it as a string
    public static string Load()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);   // New DirectoryInfo object on our save folder's path
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.json");    // Array of save files in the save folder
        FileInfo mostRecentFile = null;     // Initialize info on our most recent file as null before checking file info

        // Update our most recent file according to last write time
        foreach (FileInfo fileInfo in saveFiles)
        {
            if (mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }

        // Check that there is a most recent file
        // Load from most recent file by default
        if (mostRecentFile != null)
        {
            // Put data into a string so that it can be parsed
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            return saveString;
        }
        else 
        {
            return null;
        }
    }
}

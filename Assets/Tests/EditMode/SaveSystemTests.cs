using System.IO;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SaveSystemTests
    {          
        // Should fail if a load succeeds despite not having a save file 
        [Test]
        public void LoadFromFileFails() 
        { 
            DeleteSaveFolderBeforeTest(); 
            SaveSystem.Init();

            string test = SaveSystem.Load();
            Assert.IsTrue(test == null);           
        }

        // Should fail if the save file is not created
        [Test]
        public void SaveToFile() 
        {  
            DeleteSaveFolderBeforeTest();
            string name = "intput";
            int hp = 120, ac = 21, initiative = 7;
            int[,] abilities = new int[6, 3] {{10,0,1}, {12,1,2}, {14,2,3}, {16,3,4}, {18,4,5}, {20,5,6}};
            int[] passives = new int[3] {15,17,19};
            SaveSystem.Init();

            var holder = new GameObject();
            var creatureTest = holder.AddComponent<CreatureStats>();
            creatureTest.SetValues(name, hp, ac, initiative, abilities, passives);
            string json = JsonUtility.ToJson(creatureTest);
            SaveSystem.Save(json);

            Assert.IsTrue(File.Exists(Application.dataPath + "/Saves/save_1.json"));          
        }

        // Should fail if test is not written to despite having a save file to read from
        [Test]
        public void LoadFromFileSucceeds() 
        {  
            DeleteSaveFolderBeforeTest();
            string name = "intput";
            int hp = 120, ac = 21, initiative = 7;
            int[,] abilities = new int[6, 3] {{10,0,1}, {12,1,2}, {14,2,3}, {16,3,4}, {18,4,5}, {20,5,6}};
            int[] passives = new int[3] {15,17,19};
            SaveSystem.Init();

            var holder = new GameObject();
            var creatureTest = holder.AddComponent<CreatureStats>();
            creatureTest.SetValues(name, hp, ac, initiative, abilities, passives);
            string json = JsonUtility.ToJson(creatureTest);
            SaveSystem.Save(json);

            string test = SaveSystem.Load();
            Assert.IsTrue(test != null);           
        }

        // Should fail if the string read from the file differs from the string written to it 
        [Test]
        public void SaveAndLoadFromFile() 
        {  
            DeleteSaveFolderBeforeTest();
            string name = "intput";
            int hp = 120, ac = 21, initiative = 7;
            int[,] abilities = new int[6, 3] {{10,0,1}, {12,1,2}, {14,2,3}, {16,3,4}, {18,4,5}, {20,5,6}};
            int[] passives = new int[3] {15,17,19};
            SaveSystem.Init();

            var holder = new GameObject();
            var creatureTest = holder.AddComponent<CreatureStats>();
            creatureTest.SetValues(name, hp, ac, initiative, abilities, passives);
            string json = JsonUtility.ToJson(creatureTest);
            SaveSystem.Save(json);

            string test = SaveSystem.Load();
            Assert.IsTrue(test == json);           
            DeleteSaveFolderBeforeTest();
        }

        public void DeleteSaveFolderBeforeTest()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath + "/Saves/");
            if (Directory.Exists(Application.dataPath + "/Saves/"))
            {
                directoryInfo.Delete(true);
            }   
        }
    }
}

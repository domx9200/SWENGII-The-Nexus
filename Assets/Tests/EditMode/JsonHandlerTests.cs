using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Tests
{
    public class JsonHandlerTests
    {
        // Check that we save to the file and it has the right data
        [Test]
        public void SaveToFileSucceeds()
        {
            JsonHandler.Init();
            string name = "test";
            int hp = 120, ac = 21, initiative = 7;
            int[,] abilities = new int[6, 3] {{10,0,1}, {12,1,2}, {14,2,3}, {16,3,4}, {18,4,5}, {20,5,6}};
            int[] passives = new int[3] {15,17,19};
            var holder =  new GameObject();
            var creatureTest = holder.AddComponent<CreatureStats>();
            creatureTest.SetValues(name, hp, ac, initiative, abilities, passives);

            JsonHandler.Save(creatureTest, JsonHandler.SAVE_FOLDER + "test.json");
            string json = JsonUtility.ToJson(creatureTest, true);
            string saveString = File.ReadAllText(JsonHandler.SAVE_FOLDER + "test.json");
            Assert.AreEqual(json, saveString);
        }
        
        // Should fail if test is not written to despite having a save file to read from
        [Test]
        public void LoadFromFileSucceeds() 
        {  
            JsonHandler.Init();
            string name = "test";
            int hp = 120, ac = 21, initiative = 7;
            int[,] abilities = new int[6, 3] {{10,0,1}, {12,1,2}, {14,2,3}, {16,3,4}, {18,4,5}, {20,5,6}};
            int[] passives = new int[3] {15,17,19};
            var holder =  new GameObject();
            var creatureTest = holder.AddComponent<CreatureStats>();
            creatureTest.SetValues(name, hp, ac, initiative, abilities, passives);
            var data = new StatsData(creatureTest);

            StatsData loadTest = JsonHandler.Load(JsonHandler.SAVE_FOLDER + "test.json");
            string json1 = JsonUtility.ToJson(data, true);
            string json2 = JsonUtility.ToJson(loadTest, true);
            Assert.AreEqual(json1, json2);
        }
        
    }
}
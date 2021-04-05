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
        [Test]
        public void SaveAndLoadCreatureInfo() 
        {  
            // Check that the save file exists and has the properly converted JSON format
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

            Assert.AreEqual(test, json);           
        }
    }
}

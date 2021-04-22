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
        // Should fail if test is not written to despite having a save file to read from
        [UnityTest]
        public IEnumerator LoadFromFileSucceeds() 
        {  
            SaveSystem.Init();
            yield return null;
            string test = SaveSystem.Load();
            Assert.IsTrue(test != null);           
        }

        // Should fail if JsonHandler does not get called during OnCreatureFinish
        [UnityTest]
        public IEnumerator SaveCreatureToJson()
        {
            SceneManager.LoadScene("CreatureCreationMenu");
            yield return null;
            var inputs = Object.FindObjectsOfType<InputField>();
            for(int i = 0; i < inputs.Length; i++) // Manually insert inputs on the menu
            {
                switch (inputs[i].transform.parent.name)
                {
                    case "creatureName":
                        inputs[i].text = "intput";
                        break;
                    case "creatureHealth":
                        inputs[i].text = "69";
                        break;
                    case "armorClass":
                        inputs[i].text = "21";
                        break;
                    case "initiative":
                        inputs[i].text = "7";
                        break;
                    case "strength":
                        if (inputs[i].name == "AbilityScoreInputScore")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "dexterity":
                        if (inputs[i].name == "AbilityScoreInputScore")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "constitution":
                        if (inputs[i].name == "AbilityScoreInputScore")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "wisdom":
                        if (inputs[i].name == "AbilityScoreInputScore")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "intelligence":
                        if (inputs[i].name == "AbilityScoreInputScore")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "charisma":
                        if (inputs[i].name == "AbilityScoreInputScore")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "perception":
                        inputs[i].text = "15";
                        break;
                    case "investigation":
                        inputs[i].text = "17";
                        break;
                    case "insight":
                        inputs[i].text = "19";
                        break;
                }
            }

            GameObject.Find("completeCreation").GetComponent<FinishCreation>().OnCreatureFinish();
            yield return null;
            
            // Load the file we saved to, check that data is the same
            var stats = Object.FindObjectOfType<CreatureStats>();
            string json1 = JsonUtility.ToJson(stats, true);
            string json2 = SaveSystem.Load();
            Assert.AreEqual(json1, json2);
        }

        // Test similar to above, but on Save button 
    }
}
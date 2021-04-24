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
        // Should fail if JsonHandler does not get called during OnCreatureFinish
        [UnityTest]
        public IEnumerator SaveCreatureToJson()
        {
            DeleteSaveFolderBeforeTest();
            yield return null;
            SceneManager.LoadScene("CreatureCreationMenu");
            yield return null;
            var inputs = Object.FindObjectsOfType<InputField>();
            for(int i = 0; i < inputs.Length; i++)
            {
                switch (inputs[i].transform.parent.name)
                {
                    case "creatureName":
                        inputs[i].text = "intput";
                        break;
                    case "creatureHealth":
                        inputs[i].text = "120";
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
            Assert.IsTrue(Directory.Exists(Application.dataPath + "/Saves/"));
        }

        public void DeleteSaveFolderBeforeTest()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath + "/Saves/");
            directoryInfo.Delete(true);
        }
    }
}

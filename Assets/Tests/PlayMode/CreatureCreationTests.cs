using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Tests
{
    public class CreatureCreationTests
    {
        //should fail if a creature is still created despite not having all inputs
        [UnityTest]
        public IEnumerator FailToCreateCreature()
        {
            SceneManager.LoadScene("CreatureCreationMenu");
            yield return null;
            GameObject.Find("completeCreation").GetComponent<FinishCreation>().OnCreatureFinish();
            Scene CreatureDump = SceneManager.GetSceneByName("CreatureDump");
            Assert.AreEqual(CreatureDump.GetRootGameObjects().Length, 0);
        }

        //should fail if a creature isn't created despite having all inputs
        [UnityTest]
        public IEnumerator SucceedToCreateCreature()
        {
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
                        if (inputs[i].name == "AbilityScoreInputField")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "dexterity":
                        if (inputs[i].name == "AbilityScoreInputField")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "constitution":
                        if (inputs[i].name == "AbilityScoreInputField")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "wisdom":
                        if (inputs[i].name == "AbilityScoreInputField")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "intelligence":
                        if (inputs[i].name == "AbilityScoreInputField")
                            inputs[i].text = "10";
                        else if (inputs[i].name == "AbilityBonusInputField")
                            inputs[i].text = "0";
                        else
                            inputs[i].text = "1";
                        break;
                    case "charisma":
                        if (inputs[i].name == "AbilityScoreInputField")
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
            Scene CreatureDump = SceneManager.GetSceneByName("CreatureDump");
            GameObject newCreature = CreatureDump.GetRootGameObjects()[0];
            int passes = 0;
            if (newCreature.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text == "intput") passes++;
            else Debug.Log("NameAndShowStatsOpen failed");

            if (newCreature.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text == "intput") passes++;
            else Debug.Log("NameAndShowStatsClose failed");

            if (newCreature.transform.GetChild(3).GetChild(1).GetComponent<TMP_InputField>().text == "120") passes++;
            else Debug.Log("Health Input Field failed");

            if (newCreature.transform.GetChild(3).GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text == "120") passes++;
            else Debug.Log("Health PlaceHolder Text failed");

            if (newCreature.transform.GetChild(4).GetChild(1).GetComponent<TMP_InputField>().text == "21") passes++;
            else Debug.Log("AC Input Field failed");

            if (newCreature.transform.GetChild(4).GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text == "21") passes++;
            else Debug.Log("AC PlaceHolder Text failed");

            GameObject dropDown = newCreature.transform.GetChild(7).gameObject;
            for(int i = 0; i < 6; i++)
            {
                if (dropDown.transform.GetChild(0).GetChild(8 + i).GetComponent<TextMeshProUGUI>().text == "10") passes++;
                if (dropDown.transform.GetChild(0).GetChild(15 + i).GetComponent<TextMeshProUGUI>().text == "0") passes++;
                if (dropDown.transform.GetChild(0).GetChild(22 + i).GetComponent<TextMeshProUGUI>().text == "1") passes++;
            }

            if (dropDown.transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>().text == "15") passes++;
            if (dropDown.transform.GetChild(1).GetChild(4).GetComponent<TextMeshProUGUI>().text == "17") passes++;
            if (dropDown.transform.GetChild(1).GetChild(5).GetComponent<TextMeshProUGUI>().text == "19") passes++;
            Assert.AreEqual(27, passes);
        }
    }
}

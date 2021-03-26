using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishCreation : MonoBehaviour
{
	[SerializeField] private Creature newCreature;
	Scene creatureDump;

    public void onCreatureFinish()
	{
		InputField[] test = Object.FindObjectsOfType<InputField>();
		if (SceneManager.GetSceneByName("creatureDump").name == null)
			creatureDump = SceneManager.CreateScene("creatureDump");
		else
			creatureDump = SceneManager.GetSceneByName("creatureDump");
		SceneManager.MoveGameObjectToScene(GameObject.Find("toMove"), creatureDump);
	}
}

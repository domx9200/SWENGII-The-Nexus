using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCreation : MonoBehaviour
{
	[SerializeField] private GameObject creature;

    public void onCreatureFinish()
	{
		SceneManager.LoadScene("CombatMenu");
	}

	public void AddCreatureToList()
    {

    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OnStartClick()
    {
        SceneManager.LoadScene("CombatMenu");
    }

    public void OnCreateClick()
    {
        SceneManager.LoadScene("CharacterCreationScene");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

}

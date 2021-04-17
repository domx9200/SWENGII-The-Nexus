using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMenusScript : MonoBehaviour
{
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnAddCreatureClick()
    {
        SceneManager.LoadScene("CreatureCreationMenu");
    }
}

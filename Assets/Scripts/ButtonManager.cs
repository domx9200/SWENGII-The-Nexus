using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string CurrentScene = null, NewScene = null;
    public GameObject init;
    public void SceneChange()
    {
        if (CurrentScene == "CombatMenu")
        {
            if (SceneManager.GetSceneByName("CreatureDump").name == null)
            {
                SceneManager.LoadScene("CreatureDump", LoadSceneMode.Additive);
            }
            
            init.AddComponent<ControlCombatScript>();
            var temp = init.GetComponent<ControlCombatScript>();
            var CurrentTurn = init.transform.parent.GetChild(0).GetComponent<ControlCombatScript>();

            temp.TurnIndex = CurrentTurn.TurnIndex;
            temp.RoundCount = CurrentTurn.RoundCount;
            init.transform.parent = null;
            SceneManager.MoveGameObjectToScene(init, SceneManager.GetSceneByName("CreatureDump"));
        }
        SceneManager.LoadScene(NewScene, LoadSceneMode.Additive);
        StartCoroutine(UnloadCo());
        
    }

    IEnumerator UnloadCo()
    {
        yield return new WaitForSeconds(.01f);
        SceneManager.UnloadSceneAsync(CurrentScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMenusScript : MonoBehaviour
{
    private Scene _creatureDump;
    [SerializeField] private GameObject _initiativeList = null;

    public void OnAddCreatureClick()
    {
        if (SceneManager.GetSceneByName("CreatureDump").name == null)
            _creatureDump = SceneManager.CreateScene("CreatureDump");
        else
            _creatureDump = SceneManager.GetSceneByName("CreatureDump");

        for (int i = 0; i < _initiativeList.transform.childCount; i++)
        {
            for (int j = 0; j < _initiativeList.transform.GetChild(i).GetChild(7).childCount; j++)
            {
                _initiativeList.transform.GetChild(i).GetChild(7).GetChild(j).gameObject.SetActive(false);
            }
            _initiativeList.transform.GetChild(i).GetChild(7).gameObject.SetActive(false);

            _initiativeList.transform.GetChild(i).GetComponent<CreatureMoveController>().updateMoveTo(-31.6206f * i);
            _initiativeList.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
            _initiativeList.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
        }

        _initiativeList.AddComponent<ControlCombatScript>();
        ControlCombatScript temp = _initiativeList.GetComponent<ControlCombatScript>();
        ControlCombatScript CurrentTurn = _initiativeList.transform.parent.GetChild(0).GetComponent<ControlCombatScript>();
        Debug.Log(temp);
        Debug.Log(CurrentTurn);
        temp.TurnIndex = CurrentTurn.TurnIndex;
        temp.RoundCount = CurrentTurn.RoundCount;

        _initiativeList.transform.parent = null;
        SceneManager.MoveGameObjectToScene(_initiativeList, _creatureDump);
        SceneManager.LoadScene("CreatureCreationMenu", LoadSceneMode.Additive);
        StartCoroutine(UnloadCurrentScene());
    }

    IEnumerator UnloadCurrentScene()
    {
        yield return new WaitForSeconds(.01f);
        SceneManager.UnloadSceneAsync("CombatMenu");
    }
}

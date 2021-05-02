using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddCreatures : MonoBehaviour
{
    private Scene _CreatureDump;
    [SerializeField] private GameObject _InitiativeList;
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _CurrentTurn;
    private float _CreatureHeight = 31.61026f;

    private void Awake()
    {
        _CreatureDump = SceneManager.GetSceneByName("CreatureDump");
        
        if (_CreatureDump.name == null)
        {
            Debug.Log("AddCreature:: creatureDump is null");
            if(_InitiativeList.transform.childCount == 0)
            {
                _InitiativeList.transform.parent.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                _InitiativeList.transform.parent.GetChild(0).gameObject.SetActive(true);
            }
        }
        else if(_CreatureDump.GetRootGameObjects().Length > 1)
        {
            _InitiativeList.transform.parent.GetChild(0).gameObject.SetActive(true);
            AddCreaturesMethod();
        }
        else if(_CreatureDump.GetRootGameObjects().Length == 1)
        {
            if(_CreatureDump.GetRootGameObjects()[0].transform.childCount != 0)
            {
                _InitiativeList.transform.parent.GetChild(0).gameObject.SetActive(true);
                AddCreaturesMethod();
            }
            else
            {
                _InitiativeList.transform.parent.GetChild(0).gameObject.SetActive(false);
                Destroy(_CreatureDump.GetRootGameObjects()[0]);
                
            }
        }
        else
        {
            _InitiativeList.transform.parent.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void AddCreaturesMethod()
    {
        GameObject[] Creatures = _CreatureDump.GetRootGameObjects();
        int j = 0;

        if (Creatures.Length != 0)
        {
            GameObject[] newCreatures;
            if (Creatures[0].name == "InitiativeList")
            {
                newCreatures = new GameObject[Creatures[0].transform.childCount + Creatures.Length - 1];
                Debug.Log("newcreatures length: " + newCreatures.Length);

                for (int i = 0; i < Creatures[0].transform.childCount; i++)
                {
                    newCreatures[i] = Creatures[0].transform.GetChild(i).gameObject;
                    Debug.Log(newCreatures[i].GetComponent<CreatureStats>()._Name);
                }

                for (int i = Creatures[0].transform.childCount; i < newCreatures.Length; i++)
                {
                    newCreatures[i] = Creatures[i - Creatures[0].transform.childCount + 1];
                }
                j = 1;
            }
            else
            {
                newCreatures = new GameObject[Creatures.Length];
                for(int i = 0; i < newCreatures.Length; i++)
                {
                    newCreatures[i] = Creatures[i];
                }
            }

            for (int i = 0; i < newCreatures.Length; i++)
            {
                if (_InitiativeList.transform.childCount == 0)
                {
                    newCreatures[i].transform.SetParent(_InitiativeList.transform);
                    newCreatures[i].GetComponent<CreatureMoveController>().updatePosAndMoveTo(0f);
                }
                else
                {
                    Vector2 LastChildPos = _InitiativeList.transform.GetChild(_InitiativeList.transform.childCount - 1).transform.localPosition;
                    LastChildPos.y -= _CreatureHeight;
                    newCreatures[i].transform.SetParent(_InitiativeList.transform);
                    Debug.Log(newCreatures[i].transform.localPosition);
                    newCreatures[i].GetComponent<CreatureMoveController>().updatePosAndMoveTo(LastChildPos.y);
                }
            }

            if (j == 1)
            {
                var temp = Creatures[0].GetComponent<ControlCombatScript>();
                Debug.Log(temp);
                ControlCombatScript CurrentTurnScript = _CurrentTurn.GetComponent<ControlCombatScript>();
                Debug.Log(CurrentTurnScript);
                CurrentTurnScript.TurnIndex = temp.TurnIndex - 1;
                CurrentTurnScript.RoundCount = temp.RoundCount;
                if (CurrentTurnScript.TurnIndex < 0)
                    CurrentTurnScript.TurnIndex = 0;
                else
                    CurrentTurnScript.NextTurn();
                Destroy(Creatures[0]);
            }

            if (newCreatures.Length > 9)
            {
                int diff = newCreatures.Length - 9;
                for (var i = 0; i < diff; i++)
                {
                    _content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, _content.GetComponent<RectTransform>().rect.height + 31.62016f);
                }
            }
        }
    }
}
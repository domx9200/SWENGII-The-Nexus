using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddCreatures : MonoBehaviour
{
    private Scene _CreatureDump;
    [SerializeField] private GameObject _InitiativeList;
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
        else
        {
            _InitiativeList.transform.parent.GetChild(0).gameObject.SetActive(true);
            AddCreaturesMethod();
        }
    }

    private void AddCreaturesMethod()
    {
        GameObject[] Creatures = _CreatureDump.GetRootGameObjects();

        for (int i = 0; i < Creatures.Length; i++)
        {
            if(_InitiativeList.transform.childCount == 0) 
            {
                Creatures[i].transform.SetParent(_InitiativeList.transform);
                Creatures[i].transform.localPosition = Vector2.zero;
            } 
            else
            {
                Vector2 LastChildPos = _InitiativeList.transform.GetChild(_InitiativeList.transform.childCount - 1).transform.localPosition;
                LastChildPos.y -= _CreatureHeight;
                Creatures[i].transform.SetParent(_InitiativeList.transform);
                Creatures[i].transform.localPosition = LastChildPos;
                Creatures[i].GetComponent<CreatureMoveController>().updatePosAndMoveTo(LastChildPos.y);
            }
        }
    }
}
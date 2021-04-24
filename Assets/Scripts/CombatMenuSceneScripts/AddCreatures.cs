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
        int j = 0;

        GameObject[] newCreatures = new GameObject[Creatures[0].transform.childCount + Creatures.Length - 1];
        Debug.Log("newcreatures length: " + newCreatures.Length);

        if (Creatures[0].name == "InitiativeList")
        {
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

        for (int i = 0; i <  newCreatures.Length; i++)
        {
            if(_InitiativeList.transform.childCount == 0) 
            {
                newCreatures[i].transform.SetParent(_InitiativeList.transform);
                newCreatures[i].GetComponent<CreatureMoveController>().updatePosAndMoveTo(0f);
            } 
            else
            {
                Vector2 LastChildPos = _InitiativeList.transform.GetChild(_InitiativeList.transform.childCount - 1).transform.localPosition;
                LastChildPos.y -= _CreatureHeight;
                newCreatures[i].transform.SetParent(_InitiativeList.transform);
                newCreatures[i].transform.localPosition = LastChildPos;
                newCreatures[i].GetComponent<CreatureMoveController>().updatePosAndMoveTo(LastChildPos.y);
            }
        }

        if (j == 1)
        {
            Destroy(Creatures[0]);
        }
    }
}
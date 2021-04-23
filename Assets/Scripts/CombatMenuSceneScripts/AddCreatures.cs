using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddCreatures : MonoBehaviour
{
    private Scene _creatureDump;
    [SerializeField] private GameObject _initiativeList;
    private float _creatureHeight = 31.61026f;

    private void Awake()
    {
        _creatureDump = SceneManager.GetSceneByName("CreatureDump");
        
        if (_creatureDump.name == null)
        {
            Debug.Log("AddCreature:: creatureDump is null");
        }
        else
        {
            AddCreaturesMethod();
        }
    }

    private void AddCreaturesMethod()
    {
        GameObject[] creatures = _creatureDump.GetRootGameObjects();

        for (int i = 0; i < creatures.Length; i++)
        {
            if (_initiativeList.transform.childCount == 0)
            {
                Debug.Log("First creature in list: " + creatures[i]);
                creatures[i].transform.SetParent(_initiativeList.transform);
                creatures[i].transform.localPosition = Vector2.zero;
            }
            else
            {
                Debug.Log("Previous creatures: " + _initiativeList.transform.GetChild(_initiativeList.transform.childCount-1));
                Vector2 lastChildPos = _initiativeList.transform.GetChild(_initiativeList.transform.childCount - 1).position;
                Debug.Log("Position " +lastChildPos);
                Debug.Log("old y: " + lastChildPos.y);
                lastChildPos.y -= _creatureHeight;
                Debug.Log("new y: " + lastChildPos.y);
                creatures[i].transform.SetParent(_initiativeList.transform);
                creatures[i].transform.position = lastChildPos;

                // Change size of content to fit new creature
                float childHeight = _initiativeList.transform.GetChild(_initiativeList.transform.childCount - 1).GetComponent<RectTransform>().rect.height;
                RectTransform contentRectTransform = _initiativeList.transform.parent.gameObject.GetComponent<RectTransform>();
                contentRectTransform.sizeDelta = new Vector2(contentRectTransform.rect.width, contentRectTransform.rect.height + childHeight);
            }
        }
    }
}

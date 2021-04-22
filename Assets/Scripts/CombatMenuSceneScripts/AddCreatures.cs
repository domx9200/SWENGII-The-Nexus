using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddCreatures : MonoBehaviour
{
    private Scene creatureDump;
    [SerializeField] private GameObject initiativeList;

    private void Awake()
    {
        creatureDump = SceneManager.GetSceneByName("CreatureDump");
        
        if (creatureDump.name == null)
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
        GameObject[] creatures = creatureDump.GetRootGameObjects();

        for (int i = 0; i < creatures.Length; i++)
        {
            // Set position of new creature
            if (initiativeList.transform.childCount == 1)
            {
                creatures[i].transform.SetParent(initiativeList.transform);
                Debug.Log(initiativeList.transform.childCount);
                creatures[i].transform.position = initiativeList.transform.GetChild(0).position;
            }
            else
            {
                Debug.Log("More than 1 creature in list: " + initiativeList.transform.childCount);
                // Change transform of new child
                Transform lastChild = initiativeList.transform.GetChild(initiativeList.transform.childCount - 1);
                Debug.Log("lastChild: " + lastChild.name);
                creatures[i].transform.SetParent(initiativeList.transform);
                Vector2 newChildSize = new Vector2(lastChild.position.x, lastChild.position.y - lastChild.GetComponent<RectTransform>().rect.height);
                Debug.Log("newchild og pos " + creatures[i].transform.position);
                creatures[i].transform.position = newChildSize;
                Debug.Log("newchild new pos " + creatures[i].transform.position);

                // Change size of content to fit new creature
                float childHeight = lastChild.GetComponent<RectTransform>().rect.height;
                RectTransform contentRectTransform = initiativeList.transform.parent.gameObject.GetComponent<RectTransform>();
                contentRectTransform.sizeDelta = new Vector2(contentRectTransform.rect.width, contentRectTransform.rect.height + childHeight);

                Debug.Log("newchild end pos " + creatures[i].transform.position);
            }
        }
    }
}

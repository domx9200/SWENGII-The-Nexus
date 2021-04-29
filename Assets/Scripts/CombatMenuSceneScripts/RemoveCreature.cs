using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCreature : MonoBehaviour
{
    [SerializeField] private GameObject _debugText;
    public GameObject Initiative = null;

    public void errorCheck()
    {
        if(Initiative.transform.childCount == 0)
        {
            StartCoroutine(ShowDebugMessage());
        }
    }

    IEnumerator ShowDebugMessage()
    {
        _debugText.SetActive(true);
        yield return new WaitForSeconds(3);
        _debugText.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string CurrentScene = null, NewScene = null;
    public void SceneChange()
    {
        SceneManager.LoadScene(NewScene, LoadSceneMode.Additive);
        StartCoroutine(UnloadCo());
    }

    IEnumerator UnloadCo()
    {
        yield return new WaitForSeconds(.01f);
        SceneManager.UnloadSceneAsync(CurrentScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCreatureDump : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if(!SceneManager.GetSceneByName("CreatureDump").isLoaded)
            SceneManager.LoadScene("CreatureDump", LoadSceneMode.Additive);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Input.GetKeyDown(KeyCode.Equals))
        {
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextScene >= SceneManager.sceneCountInBuildSettings) nextScene = 0;
            SceneManager.LoadScene(nextScene);
        }
    }
}

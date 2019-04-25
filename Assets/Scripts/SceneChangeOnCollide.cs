using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeOnCollide : MonoBehaviour
{
    public string scene = "KongCity";

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<VRTK.VRTK_PlayerObject>() != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}

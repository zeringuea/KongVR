using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSoundController : MonoBehaviour
{

    public AudioClip crashNoise;
    public float speedThreshold;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = crashNoise;
    }
    
    void OnCollisionEnter()
    {
        Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
        if (GetComponent<Rigidbody>().velocity.magnitude >= speedThreshold)
        {
            Debug.Log("Crash!");
            GetComponent<AudioSource>().Play();
        }
    }
}

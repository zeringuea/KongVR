using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SizeLimit : MonoBehaviour
{

    public VRTK.PlayerMovement Script;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<VRTK.VRTK_PlayerObject>() != null)
        {
            if (tag == "Smalltag")
                Script.setSmallTrue();
            else if (tag == "Mediumtag")
                Script.setMediumTrue();
            else if (tag == "Largetag")
                Script.setLargeTrue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<VRTK.VRTK_PlayerObject>() != null)
        {
            if (tag == "Smalltag")
                Script.setSmallFalse();
            else if (tag == "Mediumtag")
                Script.setMediumFalse();
            else if (tag == "Largetag")
                Script.setLargeFalse();
        }
    }
}



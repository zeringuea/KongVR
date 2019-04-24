using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (name == "SmallLimit")
            Script.setSmallTrue();
        else if (name == "MediumLimit")
            Script.setMediumTrue();
        else if (name == "LargeLimit")
            Script.setLargeTrue();
    }

    void OnTriggerExit(Collider other)
    {
        if (name == "SmallLimit")
            Script.setSmallFalse();
        else if (name == "MediumLimit")
            Script.setMediumFalse();
        else if (name == "LargeLimit")
            Script.setLargeFalse();
    }
}

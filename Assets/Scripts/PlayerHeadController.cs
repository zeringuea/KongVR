using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadController : MonoBehaviour
{
    protected int foodCounter;

    // Start is called before the first frame update
    void Start()
    {
        foodCounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food") && other.GetComponent<VRTK.InteractableBanana>().IsHeld())
        {
            other.gameObject.GetComponent<VRTK.InteractableBanana>().Eat();
            foodCounter++;
            Debug.Log("Food Count Up: " + foodCounter);
        }
    }

    public int getFoodCounter()
    {
        return foodCounter;
    }
}

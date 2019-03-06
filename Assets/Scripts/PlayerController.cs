using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int count = 0;

    public Text countText;
    public Text winText;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetCountText();
        winText.text = "";
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
            winText.text = "You Win";
    }
}

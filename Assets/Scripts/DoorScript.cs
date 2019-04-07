using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Vector3 closedPosition, openedPosition;
    public float speed;
    public enum ToggleMode { Proximity, Spacebar, CodeOnly };
    // Proximity requires an additional collider with trigger enabled, toggles open when player is in proximity, false otherwise
    // Spacebar toggles when spacebar is pressed
    // CodeOnly removes proximity and spacebar triggers but still allows use of public functions Toggle, Open, and Close
    public ToggleMode toggleMode;

    private IEnumerator currentCoroutine;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = closedPosition;
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleMode == ToggleMode.Spacebar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Toggle();
        }
    }

    // Toggles open/close status of the door
    public void Toggle()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        if (open)
            currentCoroutine = Move(closedPosition, speed);
        else
            currentCoroutine = Move(openedPosition, speed);
        open = !open;
        StartCoroutine(currentCoroutine);
    }

    // Opens the door if it is not already open
    public void Open()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = Move(openedPosition, speed);
        open = true;
        StartCoroutine(currentCoroutine);
    }

    // Closes the door if it is not already closed
    public void Close()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = Move(closedPosition, speed);
        open = false;
        StartCoroutine(currentCoroutine);
    }

    private IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (toggleMode == ToggleMode.Proximity && other.CompareTag("Head"))
        {
            Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (toggleMode == ToggleMode.Proximity && other.CompareTag("Head"))
        {
            Close();
        }
    }
}

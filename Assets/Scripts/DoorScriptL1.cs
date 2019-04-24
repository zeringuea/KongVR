using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptL1 : MonoBehaviour
{
    public Vector3 closedPosition, openedPosition;
    public Quaternion closedRotation, openedRotation;
    public float moveSpeed;
    public enum ToggleMode { Proximity, Spacebar, CodeOnly };
    // Proximity requires an additional collider with trigger enabled, toggles open when player is in proximity, false otherwise
    // Spacebar toggles when spacebar is pressed
    // CodeOnly removes proximity and spacebar triggers but still allows use of public functions Toggle, Open, and Close
    public ToggleMode toggleMode;

    private IEnumerator currentCoroutine;
    private bool open;
	private int bananaCount;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = closedPosition;
        transform.rotation = closedRotation;
        open = false;
		bananaCount=0;
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
            currentCoroutine = Move(closedPosition, closedRotation, moveSpeed);
        else
            currentCoroutine = Move(openedPosition, openedRotation, moveSpeed);
        open = !open;
        StartCoroutine(currentCoroutine);
    }

    // Opens the door if it is not already open
    public void Open()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = Move(openedPosition, openedRotation, moveSpeed);
        open = true;
        StartCoroutine(currentCoroutine);
    }

    // Closes the door if it is not already closed
    public void Close()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = Move(closedPosition, closedRotation, moveSpeed);
        open = false;
        StartCoroutine(currentCoroutine);
    }

    private IEnumerator Move(Vector3 destination, Quaternion rotation, float moveSpeed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, moveSpeed * Time.deltaTime);
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

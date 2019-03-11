using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    private bool paused;

    public GameObject[] musicNotePrefabs;
    private GameObject[] myNotes = new GameObject[3];
    private IEnumerator[] myNoteRoutines = new IEnumerator[3];
    private int noteIter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        paused = false;
        StartCoroutine(AddNotes());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            if (paused)
                MusicSource.Pause();
            else
                MusicSource.UnPause();
        }
    }

    IEnumerator AddNotes()
    {
        while (!paused)
        {
            ResetNote();

            noteIter++;
            if (noteIter >= myNotes.Length) noteIter = 0;

            yield return new WaitForSeconds(1f);
        }
    }

    /*IEnumerator AnimateNote(GameObject note)
    {
        while(true)
        {
            Vector3 destination = new Vector3(note.transform.position.x,
                                                note.transform.position.y + 1f,
                                                note.transform.position.z);
            float speed = 3f;
            
            yield return new WaitForSeconds(0.1f);
        }
    }*/

    IEnumerator MoveNote(GameObject note, Vector3 offset, float speed)
    {
        while (true)
        {
            note.transform.position = Vector3.MoveTowards(note.transform.position, note.transform.position + offset, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void ResetNote()
    {
        if (myNoteRoutines[noteIter] != null)
            StopCoroutine(myNoteRoutines[noteIter]);
        if (myNotes[noteIter] != null)
            Destroy(myNotes[noteIter]);

        int noteNum = (int)(Random.value * 10) % musicNotePrefabs.Length;
        myNotes[noteIter] = Instantiate(musicNotePrefabs[noteNum]);
        //myNotes[noteIter].transform.parent = gameObject.transform;
        //myNotes[noteIter].transform.localPosition = new Vector3(Random.value/4 - 0.125f, 0.05f, 0f);
        myNotes[noteIter].transform.position = gameObject.transform.position + new Vector3(Random.value / 4 - 0.125f, 0.05f, 0f);
        //myNotes[noteIter].transform.localEulerAngles = Vector3.zero;
        myNotes[noteIter].transform.eulerAngles = Vector3.Scale(gameObject.transform.eulerAngles, Vector3.up);

        myNoteRoutines[noteIter] = MoveNote(myNotes[noteIter], Vector3.up, 1f);
        StartCoroutine(myNoteRoutines[noteIter]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvasScript : MonoBehaviour
{
    public GameObject NoteReader;
    bool displayingNote;
    public void DisplayNote(string text)
    {
        Debug.Log("display note NOW!!");
        NoteReader.SetActive(true);
        NoteReader.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        displayingNote = true;
    }
    private void Update()
    {
        if(displayingNote)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                NoteReader.SetActive(false);
            }
        }
    }
}
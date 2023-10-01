using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCanvasScript : MonoBehaviour
{
    private GameObject NoteReader;
    public GameObject DeathScreen;
    public GameObject YouDiedScreen;
    float alpha;
    bool displayingNote;
    private void Start()
    {
        NoteReader = GameObject.Find("NoteReader");
        NoteReader.SetActive(false);
    }
    public void DisplayNote(string text)
    {
        Debug.Log("enable gameobj");
        NoteReader.SetActive(true);
        NoteReader.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        displayingNote = true;
    }
    public void StartDying()
    {
        alpha = 0;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayASound("HeavyBreating", false);
        StartCoroutine(IncreseImageAlpha());
    }
    IEnumerator IncreseImageAlpha()
    {
        yield return new WaitForSeconds(0.5f);
        DeathScreen.transform.GetChild(0).GetComponent<RawImage>().color = new Color(0,0,0,alpha);
        alpha += 0.01f;
        Debug.Log(alpha);
        if(alpha > 1)
        {
            Debug.Log("You died");
            YouDiedScreen.SetActive(true);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().StopASound("HeavyBreating");
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayASound("DemonSound",false);
        }
        else
        {
            StartCoroutine(IncreseImageAlpha());
        }
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
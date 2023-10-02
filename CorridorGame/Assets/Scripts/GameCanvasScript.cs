using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameCanvasScript : MonoBehaviour
{
    public GameObject NoteReader;
    public GameObject DeathScreen;
    public GameObject YouDiedScreen;
    float alpha;
    bool displayingNote;
    private void Update()
    {
        if(YouDiedScreen.activeInHierarchy)
        {
            Cursor.visible = true;
        }
        if (displayingNote)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                NoteReader.SetActive(false);
            }
        }
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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().StopASound("HeavyBreating");
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayASound("DemonSound",false);
        }
        else
        {
            StartCoroutine(IncreseImageAlpha());
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoBack()
    {
        SceneManager.LoadScene("GameLobby");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
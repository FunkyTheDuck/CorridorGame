using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyCanvasScript : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayASound("LobbyMusic");
    }

    public void StartGame()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().StopAllSounds();
        SceneManager.LoadScene("GameScene");
    }
    public void Settings()
    {
        Debug.Log("Doing nothing for now");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;
    GameObject player;
    private void Start()
    {
        try
        {
            soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        }
        catch
        {

        }
        player = GameObject.Find("Player");
        StartCoroutine(FloorCraking());
    }
    IEnumerator FloorCraking()
    {
        yield return new WaitForSeconds(5);
        soundManager.gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,(player.transform.position.z - -5));
        soundManager.PlayASound("WoodenFloorCracking", true);
    }
}
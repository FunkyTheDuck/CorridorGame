using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public Texture2D cursor;
    GameManager myGM;
    private void Start()
    {
         myGM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.GetChild(0).position, myGM.player.transform.position) > 3)
        {
            return;
        }
        Cursor.visible = true;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            if (name.Contains("Door"))
            {
                
                int random = Random.Range(0,21);
                if(!myGM.GetheardCrying() && random == 1)
                {
                    soundManager.GetComponent<SoundManager>().PlayASound("GirlCrying", true);
                    myGM.SetHeardCrying(true);
                } 
                else if (!myGM.GetHeardSiren() && random == 20)
                {
                    myGM.SetHeardSiren(true);
                    soundManager.GetComponent<SoundManager>().PlayASound("DistantPoliceSiren", false);
                }
                soundManager.transform.position = transform.GetChild(0).position;
                soundManager.GetComponent<SoundManager>().PlayASound("DoorLocked", true);
                return;
            }
            else if(name.Contains("Letter"))
            {

            } 
            else if(name.Contains("Paper"))
            {
                Debug.Log("Paper picked up");
                myGM.CluePickedUp();
            }
            Debug.Log("You've picked up an item");
            Cursor.visible = false;
            Destroy(gameObject);
        }
    }
    private void OnMouseExit()
    {
        Cursor.visible = false;
    }

}
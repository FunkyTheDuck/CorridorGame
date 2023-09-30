using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public Texture2D cursor;
    private void OnMouseOver()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
            if(gameObject.name.Contains("Door"))
            {
                Debug.Log("Play door sound");
                GameObject soundManager = GameObject.Find("SoundManager");
                soundManager.transform.position = gameObject.transform.position;
                soundManager.GetComponent<SoundManager>().PlayASound("DoorLocked", true);
                return;
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
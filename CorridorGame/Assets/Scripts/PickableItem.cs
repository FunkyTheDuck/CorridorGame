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
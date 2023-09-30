using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("You've picked up an item");
            Destroy(gameObject);
        }
    }

}
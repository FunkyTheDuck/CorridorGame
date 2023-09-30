using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosotion;
    void Update()
    {
        transform.position = cameraPosotion.position;
    }
}
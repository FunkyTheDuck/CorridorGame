using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorridor : MonoBehaviour
{
    public GameObject Corridor;
    public GameObject Player;
    private GameObject newInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreatePrefab();
        DestroyPrefab();
        //if (distance > 10)
        //{
        //    Destroy(newInstance);
        //    Debug.Log("Something Destroyed1");
        //}
    }
    public void CreatePrefab()
    {
        float radius = 2f;

        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 5; j++)
            {
                Vector3 playerPos = Player.transform.position;
                float gridX = playerPos.x / 10;
                float gridZ = playerPos.z / 10;
                gridX = Mathf.RoundToInt(gridX);
                gridZ = Mathf.RoundToInt(gridZ);
                playerPos.x = (gridX + i - 2) * 10;
                playerPos.z = (gridZ + j - 2) * 10;
                if (!Physics.CheckSphere(playerPos, radius))
                {
                    newInstance = Instantiate(Corridor, new Vector3(playerPos.x, 0, playerPos.z), Player.transform.rotation);
                }
            }
        }


        //float distance = Vector3.Distance(Player.transform.position, Corridor.transform.position);
        //Debug.Log(Corridor.transform.position);
        //if (distance > 4)
        //{
            
        //    playerPos.y -= 1;

        //    newInstance = Instantiate(Corridor, playerPos, Player.transform.rotation);
        //    Corridor.transform.position = newInstance.transform.position;
        //}
    }
    public void DestroyPrefab()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject gameObject in gameObjects)
        {
            if (Vector3.Distance(gameObject.transform.position, Player.transform.position) > 30) 
            {
                Destroy(gameObject);
            }
        }
    }
}

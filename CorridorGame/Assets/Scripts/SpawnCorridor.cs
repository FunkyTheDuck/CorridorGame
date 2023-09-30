using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class SpawnCorridor : MonoBehaviour
{
    public GameObject Corridor;
    public GameObject Player;
    private GameObject newInstance;
    float oldScale = 1f;
    float sizeX;
    float sizeZ;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CreatePrefab();
        DestroyPrefab();
    }
    public void CreatePrefab()
    {
        float radius = Corridor.GetComponent<MeshRenderer>().bounds.size.x/2;

        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 5; j++)
            {
                Vector3 CheckPos = Player.transform.position;
                sizeX = Corridor.GetComponent<MeshRenderer>().bounds.size.x;
                sizeZ = Corridor.GetComponent<MeshRenderer>().bounds.size.z;
                CheckPos.x = CheckPos.x + (sizeX * (i - 2));
                CheckPos.z = CheckPos.z + (sizeX * (j - 2));
                if (!Physics.CheckSphere(CheckPos, radius))
                {
                    newInstance = Instantiate(Corridor, new Vector3(CheckPos.x, 0, CheckPos.z), Quaternion.identity);
                }
            }
        }
    }
    public void DestroyPrefab()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject gameObject in gameObjects)
        {
            if (Vector3.Distance(gameObject.transform.position, Player.transform.position) > 30 * Corridor.transform.localScale.x) 
            {
                
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class SpawnCorridor : MonoBehaviour
{
    public GameObject Corridor;
    public GameObject Player;
    private GameObject[] AllCorridor;
    float oldScale = 1f;
    float sizeX;
    float sizeZ;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Corridor, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log(Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size);
    }

    // Update is called once per frame
    void Update()
    {
        CreatePrefab();
        DestroyPrefab();
    }
    public void CreatePrefab()
    {
        float radius = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.z / 4;

        //Debug.Log(Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.z / 2);

        AllCorridor = GameObject.FindGameObjectsWithTag("Floor");
        sizeX = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
        sizeZ = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;
        //CheckPos.x = sizeX * i;
        Vector3 CheckPosPlusZ = Player.transform.position;
        CheckPosPlusZ.z += sizeZ;
        if (!Physics.CheckSphere(CheckPosPlusZ, radius))
        {
            float FurthestDistance = 0;
            GameObject furthestObject = null;
            foreach (GameObject Object in AllCorridor)
            {
                if (Object.transform.position.z > Player.transform.position.z || AllCorridor.Length < 3)
                {
                    float ObjectDistance = Vector3.Distance(Player.transform.position, Object.transform.position);

                    if (ObjectDistance > FurthestDistance)
                    {
                        furthestObject = Object;
                        FurthestDistance = ObjectDistance;
                    }
                }
            }
            Debug.Log(furthestObject.transform.position.z);
            Instantiate(Corridor, new Vector3(0, 0, furthestObject.transform.position.z + Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.z), Quaternion.identity);
        }
        Vector3 CheckPosMinusZ = Player.transform.position;
        CheckPosMinusZ.z -= sizeZ;
        if (!Physics.CheckSphere(CheckPosMinusZ, radius))
        {
            float FurthestDistance = 0;
            GameObject furthestObject = null;
            foreach (GameObject Object in AllCorridor)
            {
                if (Object.transform.position.z < Player.transform.position.z || AllCorridor.Length < 3)
                {
                    float ObjectDistance = Vector3.Distance(Player.transform.position, Object.transform.position);

                    if (ObjectDistance > FurthestDistance)
                    {
                        furthestObject = Object;
                        FurthestDistance = ObjectDistance;
                    }
                }
            }
            Debug.Log(furthestObject.transform.position.z);
            Instantiate(Corridor, new Vector3(0, 0, furthestObject.transform.position.z - Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.z), Quaternion.identity);
        }
        //if (AllCorridor.Length < 10)
        //{
        //    //for (int i = 0; i < 6; i++)
        //    //{
        //    //    Vector3 CheckPos = Player.transform.position;
        //    //    sizeX = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
        //    //    sizeZ = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;
        //    //    //CheckPos.x = sizeX * i;
        //    //    CheckPos.z += sizeZ * i;
        //    //    if (!Physics.CheckSphere(CheckPos, radius))
        //    //    {
        //    //        Instantiate(Corridor, new Vector3(0, 0, CheckPos.z), Quaternion.identity);
        //    //    }
        //    //}
        //    //for (int i = 0; i < 6; i++)
        //    //{
        //    //    Vector3 CheckPos = Player.transform.position;
        //    //    sizeX = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
        //    //    sizeZ = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;
        //    //    //CheckPos.x = sizeX * i;
        //    //    CheckPos.z += sizeZ * -i;
        //    //    if (!Physics.CheckSphere(CheckPos, radius))
        //    //    {
        //    //        Instantiate(Corridor, new Vector3(0, 0, CheckPos.z), Quaternion.identity);
        //    //    }
        //    //}

        //}


        //if (AllCorridor.Length < 5) 
        //{
        //    Vector3 CheckPos = Player.transform.position;
        //    sizeX = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
        //    sizeZ = Corridor.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;
        //    CheckPos.x = CheckPos.x + (sizeX * 2);
        //    CheckPos.z = CheckPos.z + (sizeZ * 2);
        //    if (!Physics.CheckSphere(CheckPos, radius))
        //    {
        //        Instantiate(Corridor, new Vector3(CheckPos.x, 0, CheckPos.z), Quaternion.identity);
        //    }
        //}

        //GameObject currentCorridor = null;

        //foreach (var corridors in allCorridor)
        //{
        //    float afstand = Vector3.Distance(corridors.transform.position, Player.transform.position);
        //    if (afstand < Corridor.GetComponent<MeshRenderer>().bounds.size.x)
        //    {
        //        currentCorridor = corridors;
        //    }
        //}

        //Instantiate(Corridor, new Vector3(currentCorridor.transform.position.x + 1, currentCorridor.transform.position.y + currentCorridor.GetComponent<MeshRenderer>().bounds.size.y, currentCorridor.transform.position.z + currentCorridor.GetComponent<MeshRenderer>().bounds.size.z), Quaternion.identity);






        //for (int i = 0; i < 5; i++) 
        //{
        //    for (int j = 0; j < 5; j++)
        //    {
        //        Vector3 CheckPos = Player.transform.position;
        //        sizeX = Corridor.GetComponent<MeshRenderer>().bounds.size.x;
        //        sizeZ = Corridor.GetComponent<MeshRenderer>().bounds.size.z;
        //        CheckPos.x = CheckPos.x + (sizeX * (i - 2));
        //        CheckPos.z = CheckPos.z + (sizeX * (j - 2));
        //        if (!Physics.CheckSphere(CheckPos, radius))
        //        {
        //            newInstance = Instantiate(Corridor, new Vector3(CheckPos.x, 0, CheckPos.z), Quaternion.identity);
        //        }
        //    }
        //}
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

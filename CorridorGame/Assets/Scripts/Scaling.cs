using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    public GameObject Corridor;
    public GameObject Player;// Start is called before the first frame update
    public float ScaleAmount = 0.1f; 
    float timer = 10f;
    float sizeX;
    float sizeZ;
    void Start()
    {
        Corridor.transform.localScale = new Vector3(1f, 1f, 1f);
        sizeX = Corridor.GetComponent<MeshRenderer>().bounds.size.x;
        sizeZ = Corridor.GetComponent<MeshRenderer>().bounds.size.z;
        Debug.Log("X: " + sizeX + ", Y: " + sizeZ);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("Neger");
            timer = 10f;
            //ScalingGround();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ScalingGround();
        }
    }
    public void ScalingGround()
    {
        Corridor.transform.localScale -= new Vector3(Corridor.transform.localScale.x * ScaleAmount, 0, Corridor.transform.localScale.z * ScaleAmount);
        GameObject[] test = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject test2 in test)
        {
            Vector3 oldScale = test2.GetComponent<MeshRenderer>().bounds.size;
            test2.transform.localScale -= new Vector3(test2.transform.localScale.x * ScaleAmount, 0, test2.transform.localScale.z * ScaleAmount);
            float talX = (test2.transform.position.x - Player.transform.position.x) / test2.GetComponent<MeshRenderer>().bounds.size.x;
            int tal2X = Mathf.RoundToInt(talX);
            Debug.Log(tal2X);
            test2.transform.position -= new Vector3((oldScale.x - test2.GetComponent<MeshRenderer>().bounds.size.x) * tal2X, 0, 0);
            float talZ = (test2.transform.position.z - Player.transform.position.z) / test2.GetComponent<MeshRenderer>().bounds.size.z;
            int tal2Z = Mathf.RoundToInt(talZ);
            Debug.Log(tal2Z);
            test2.transform.position -= new Vector3(0, 0, (oldScale.z - test2.GetComponent<MeshRenderer>().bounds.size.z) * tal2Z);
            //if (test2.transform.position.x < Player.transform.position.x)
            //{
            //    test2.transform.position = new Vector3(test2.transform.position.x / oldScale.x, 0, test2.transform.position.z); 
            //    if (test2.transform.position.x < 0)
            //    {
            //        test2.transform.position -= new Vector3(test2.transform.position.x * (1f - test2.transform.localScale.x), 0, 0);
            //    }
            //    else
            //    {
            //        test2.transform.position += new Vector3(test2.transform.position.x * (1f - test2.transform.localScale.x), 0, 0);
            //    }
            //}
            //if (test2.transform.position.z > Player.transform.position.z)
            //{
            //    test2.transform.position = new Vector3(test2.transform.position.x, 0, test2.transform.position.z / oldScale.z);
            //    if (test2.transform.position.z < 0)
            //    {
            //        test2.transform.position += new Vector3(0, 0, test2.transform.position.z * (1f - test2.transform.localScale.z));
            //    }
            //    else
            //    {
            //        test2.transform.position -= new Vector3(0, 0, test2.transform.position.z * (1f - test2.transform.localScale.z));
            //    }
            //}
            //if (test2.transform.position.z < Player.transform.position.z)
            //{
            //    test2.transform.position = new Vector3(test2.transform.position.x, 0, test2.transform.position.z / oldScale.z);
            //    if (test2.transform.position.z < 0)
            //    {
            //        test2.transform.position -= new Vector3(0, 0, test2.transform.position.z * (1f - test2.transform.localScale.z));
            //    }
            //    else
            //    {
            //        test2.transform.position += new Vector3(0, 0, test2.transform.position.z * (1f - test2.transform.localScale.z));
            //    }
            //}
        }
    }
}

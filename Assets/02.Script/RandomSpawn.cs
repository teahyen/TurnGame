using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public string  name;
    public GameObject spawnObj;
    public List<Transform> spawnPos = new List<Transform>();
    public GameObject parentObj;
    

    void Start()
    {
        int ran = Random.Range(0, spawnPos.Count);
        Instantiate(spawnObj, spawnPos[ran].position,Quaternion.identity,parentObj.transform);
    }

}

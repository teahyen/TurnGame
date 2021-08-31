using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTest : MonoBehaviour
{
    public GameObject damagePos;
    public List<GameObject> mapPos = new List<GameObject>();
    
    void Start()
    {
    }

    void Update()
    {
        int Ran = Random.Range(0, mapPos.Count);
        Instantiate(damagePos, mapPos[Ran].transform);
    }
}

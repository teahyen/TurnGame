using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GoMovePos : MonoBehaviour
{

    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void moving()
    {
        player.transform.position = gameObject.transform.position;
    }

    void Update()
    {
        
    }
}

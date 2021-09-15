using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHideBox : MonoBehaviour
{
    public bool isBox = true;


    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "RedZone")
        {
            isBox = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if(col.gameObject.name == "EnemyObj" && !isBox&& col.gameObject.GetComponent<HideScript>() ==null)
        {
            HideScript HS = col.gameObject.GetComponent<HideScript>();
            HS.mySrt.enabled = true;
        }
    }
}

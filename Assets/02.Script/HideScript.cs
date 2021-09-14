using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour
{
    public GameObject Enemy;

    public void OnTriggerStay(Collider2D col)
    {
        if (col.gameObject == Enemy)
        {
            SpriteRenderer spr = col.gameObject.GetComponent<SpriteRenderer>();
            spr.enabled = false;

        }
    }
}

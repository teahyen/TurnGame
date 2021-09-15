using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour
{
    public float sightRange = 3;
    public LayerMask whatIswall;
    public bool bWallInSingRange;
    public SpriteRenderer mySrt;

    private void Start()
    {
        mySrt = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        bWallInSingRange = Physics2D.OverlapBox(gameObject.transform.position, new Vector2(sightRange, sightRange),90f);
        if (bWallInSingRange)
        {
            mySrt.enabled = false;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}

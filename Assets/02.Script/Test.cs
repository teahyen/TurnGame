using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject movePos;

    private float sightRange = 0.4f;
    public LayerMask whatIswall;
    public bool bWallInSingRange;
    public bool isSpawnWall = false;

    void Start()
    {
    }



    void Update()
    {
        bWallInSingRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIswall);

        if (bWallInSingRange && !isSpawnWall)
        {
            Instantiate(movePos,gameObject.transform);
            isSpawnWall = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

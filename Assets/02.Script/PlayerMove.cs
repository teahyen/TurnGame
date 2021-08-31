using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public  List<GameObject> movePos = new List<GameObject>();

    private float sightRange = 0.4f;
    public LayerMask whatIswall;
    public bool bWallInSingRange;

    private void Start()
    {
        foreach (GameObject item in movePos)
        {
            item.SetActive(false);
        }
    }

    private void Update()
    {

        foreach (GameObject item in movePos)
        {
            bWallInSingRange = Physics2D.OverlapCircle(item.transform.position, sightRange, whatIswall);
            if (bWallInSingRange)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}

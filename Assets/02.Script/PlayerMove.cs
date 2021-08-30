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
    public bool isSpawnWall = false;

    public bool bMousePosRange;
    private Vector2 mousePos;
    private void Start()
    {
        foreach (GameObject item in movePos)
        {
            item.SetActive(false);
        }
    }

    private void Update()
    {
        mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapCircle(mousePos, 0.1f,whatIswall);
            Debug.Log(hit.name);
            Debug.Log(mousePos);
            Debug.Log(whatIswall);

            bMousePosRange = hit;
            if(hit ==null)
            {
                return;
            }
            if (bMousePosRange)
            {
                gameObject.transform.position = hit.transform.position;
            }
        }

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

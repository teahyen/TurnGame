using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitTest : MonoBehaviour
{

    private float sightRange = 0.4f;
    public LayerMask whatIswall;
    public bool bWallInSingRange;

    GameObject player;

    
    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        bWallInSingRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIswall);
        if (bWallInSingRange)
        {
            Debug.Log("게임오버");
            SceneManager.LoadScene(0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}

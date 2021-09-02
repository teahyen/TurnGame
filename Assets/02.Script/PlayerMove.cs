using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public  List<GameObject> movePos = new List<GameObject>();

    private float sightRange = 0.5f;
    public LayerMask whatIswall;
    public bool bWallInSingRange;

    public LayerMask whatIsEnemy;
    public bool bAtkPlayer;
    public GameObject Enemy;


    private void Start()
    {
        foreach (GameObject item in movePos)
        {
            item.SetActive(true);
        }
    }

    private void Update()
    {

        foreach (GameObject item in movePos)
        {
            bWallInSingRange = Physics2D.OverlapCircle(item.transform.position, sightRange, whatIswall);
            if ( bWallInSingRange &&GameManager.Instance.myTurn)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
            
        }

        //������ ����� ���
        bAtkPlayer = Physics2D.OverlapCircle(transform.position, sightRange, whatIsEnemy);
        if (bAtkPlayer&&GameManager.Instance.myTurn)
        {
            Debug.Log("�� ���");
            Enemy.SetActive(false);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}

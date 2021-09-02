using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAI : MonoBehaviour
{
    private bool oneMyTurn = true;

    public GameObject damagePos;
    public List<GameObject> mapPos = new List<GameObject>();
    //이동 관련 변수들
    public List<GameObject> movePos = new List<GameObject>();
    private float sightRange = 0.4f;
    public LayerMask whatIswall;
    public bool bWallInSingRange;

    public LayerMask whatIsPlayer;
    public bool bAtkPlayer;
    public GameObject Player;
    void Update()
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
        if (!GameManager.Instance.myTurn&&oneMyTurn)
        {
            oneMyTurn = false;
            StartCoroutine(EnemyTurn());
        }
        //플레이어를 죽이는 조건
        bAtkPlayer = Physics2D.OverlapCircle(transform.position, sightRange, whatIsPlayer);
        if (bAtkPlayer && !GameManager.Instance.myTurn)
        {
            Debug.Log("적 사망");
            //Destroy(Player);
        }
    }
    IEnumerator EnemyTurn()
    {
        int Ran = Random.Range(0, mapPos.Count);
        yield return new WaitForSeconds(0.5f);
        EnemyMove();
        GameObject jotEH = Instantiate(damagePos, mapPos[Ran].transform);
        yield return new WaitForSeconds(0.7f);
        Destroy(jotEH);


        GameManager.Instance.turnCount++;
        oneMyTurn = true;
        GameManager.Instance.myTurn = true;

    }


    void EnemyMove()
    {
        
        int ranMove = Random.Range(1, movePos.Count);
        if (!movePos[ranMove].activeSelf)
        {
            Debug.Log("길이 없음");
            EnemyMove();
            return;
        }
        else
        {
            gameObject.transform.DOMove(movePos[ranMove].transform.position, 0.7f);
            //gameObject.transform.position = movePos[ranMove].transform.position;
        }
    }
}

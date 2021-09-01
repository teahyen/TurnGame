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
    }
    IEnumerator EnemyTurn()
    {
        int Ran = Random.Range(0, mapPos.Count);
        GameObject jotEH = Instantiate(damagePos, mapPos[Ran].transform);
        EnemyMove();
        yield return new WaitForSeconds(1f);
        GameManager.Instance.turnCount++;
        oneMyTurn = true;
        GameManager.Instance.myTurn = true;
        Destroy(jotEH);
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
            gameObject.transform.DOMove(movePos[ranMove].transform.position, 0.5f);
            //gameObject.transform.position = movePos[ranMove].transform.position;
        }
    }
}

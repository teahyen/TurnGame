using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private bool oneMyTurn = true;

    void Update()
    {
        if (!GameManager.Instance.myTurn&&oneMyTurn)
        {
            oneMyTurn = false;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.turnCount++;
        oneMyTurn = true;
        GameManager.Instance.myTurn = true;
        


    }
}

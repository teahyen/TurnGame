using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private bool oneMyTurn = true;

    public GameObject damagePos;
    public List<GameObject> mapPos = new List<GameObject>();

    
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
        int Ran = Random.Range(0, mapPos.Count);
        GameObject jotEH = Instantiate(damagePos, mapPos[Ran].transform);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.turnCount++;
        oneMyTurn = true;
        GameManager.Instance.myTurn = true;
        Destroy(jotEH);
    }
}

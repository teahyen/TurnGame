using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class GoMovePos : MonoBehaviour
{
    //Image myImg;
    public GameObject player;
    private void Awake()
    {
        //myImg = gameObject.GetComponent<Image>();
    }

    public void moving()
    {
        if (GameManager.Instance.myTurn)
        {
            GameManager.Instance.turnCount++;
            player.transform
                .DOMove(gameObject.transform.position, 0.5f)
                .OnComplete(() => GameManager.Instance.myTurn = false);
            //
            //player.transform.position = gameObject.transform.position;
        }

    }
}

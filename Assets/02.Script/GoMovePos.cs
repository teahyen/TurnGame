using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class GoMovePos : MonoBehaviour
{
    Image myImg;
    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
        myImg = gameObject.GetComponent<Image>();
    }

    public void moving()
    {
        if (GameManager.Instance.myTurn)
        {
            GameManager.Instance.turnCount++;

            player.transform
                .DOMove(gameObject.transform.position, 0.5f)
                .OnComplete( () => GameManager.Instance.myTurn = false );
            //
            //player.transform.position = gameObject.transform.position;
        }

    }

    void Update()
    {
        if (!GameManager.Instance.myTurn)
        {
            myImg.enabled = false;
        }
        else
        {
            myImg.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region 싱글톤
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject temp = new GameObject("GameManager");
                    instance = temp.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    public bool myTurn = true;
    public Text turnTex;
    public int turnCount;
    public void Start()
    {
        turnTex = GameObject.Find("Text").GetComponent<Text>();
    }

    private void Update()
    {
        if(turnTex != null)
        {
            if (myTurn)
            {
                turnTex.text = $"내 턴\n{turnCount}턴째";
            }
            else
            {
                turnTex.text = $"상대 턴\n{turnCount}턴째";
            }
        }

    }

}
